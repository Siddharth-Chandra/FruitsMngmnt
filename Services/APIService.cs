using FruitsManagementAPI.Models;
using Google.Type;
using RestSharp;
using static FruitsManagementAPI.Models.FruitsModel;

namespace FruitsManagementAPI.Services
{

    public interface IAPIService
    {

        List<FruitsResponseModel> GetAllFruits();

        FruitsResponseModel GetFruitById(int id);

        FruitsResponseModel UpdateDescription(int id, string desc);

        List<FireBenefit> AddBenefit(Benefits benefits);

        List<FireBenefit> GetBenefitsById(int id);

        List<FireBenefit> DeleteBenefitById(int id);





        }

    public class APIService : IAPIService
    {
        private readonly IFirestoreProvider _firebaseService;

        public APIService(IFirestoreProvider firebaseService) { _firebaseService = firebaseService;

        }

        public List<FruitsResponseModel> GetAllFruits()
        {
            FruitsResponseModel firebaseData = new FruitsResponseModel();
            Task <IReadOnlyCollection<FruitsResponseModel>> responseData = null;
            var client = new RestClient("https://fruityvice.com/api/fruit/all");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute<List<Fruits>>(request).Data;


           responseData = _firebaseService.GetAll<FruitsResponseModel>(CancellationToken.None);
            foreach (var data in response)
            {
                firebaseData = new FruitsResponseModel
                {
                    id = data.id,
                    family = data.family,
                    desc = responseData.Result.FirstOrDefault(x=>x.id==data.id).desc,
                    name = data.name,
                    url = responseData.Result.FirstOrDefault(x => x.id == data.id).url,
                    genus = data.genus,
                    order = data.order,
                    protein = data.nutritions.protein,
                    sugar = data.nutritions.sugar,
                    fat = data.nutritions.fat,
                    calories = data.nutritions.calories,
                    carbohydrates = data.nutritions.carbohydrates
                };

                _firebaseService.AddOrUpdate(firebaseData, CancellationToken.None);

            }


            responseData = _firebaseService.GetAll<FruitsResponseModel>(CancellationToken.None);
            var data1 = responseData.Result;


            return data1.OrderBy(x => x.id).ToList();
        }

        public FruitsResponseModel GetFruitById(int id)
        {

            Task<FruitsResponseModel> responseData=null;
            var url = "https://fruityvice.com/api/fruit/";
            var client = new RestClient(url + id);
            var request = new RestRequest("", Method.Get);
            var response = client.Execute<Fruits>(request).Data;

             responseData = _firebaseService.Get<FruitsResponseModel>(Convert.ToString(id), CancellationToken.None);

            var firebaseData = new FruitsResponseModel
            {
                id = response.id,
                family = response.family,
                desc = responseData.Result.desc,
                name = response.name,
                genus = response.genus,
                order = response.order,
                url= responseData.Result.url,
                protein = response.nutritions.protein,
                sugar = response.nutritions.sugar,
                fat = response.nutritions.fat,
                calories = response.nutritions.calories,
                carbohydrates = response.nutritions.carbohydrates
            };


            _firebaseService.AddOrUpdate(firebaseData, CancellationToken.None);
            responseData = _firebaseService.Get<FruitsResponseModel>(Convert.ToString(id), CancellationToken.None);

            if (response == null)
            {
                return null;
            }
            return responseData.Result;
        }


        public FruitsResponseModel UpdateDescription(int id, string desc)
        {
            var client = new RestClient("https://fruityvice.com/api/fruit/all");
            var request = new RestRequest("", Method.Get);
            var response = client.Execute<List<Fruits>>(request).Data;
            var data = response.Find(x => x.id == id);

            var firebaseData = new FruitsResponseModel
            {
                id = id,
 
            };
            var res = _firebaseService.Update(firebaseData, desc,CancellationToken.None);
            res.Wait();
            if (res.IsCompletedSuccessfully)
            {
                var responseData = _firebaseService.Get<FruitsResponseModel>(Convert.ToString(id), CancellationToken.None);
                return responseData.Result;
            }
            else
            {
                return null;
            }

        }

      

        public List<FireBenefit> AddBenefit(Benefits benefits)
        {

            int idMax;
            Task resp =null;
            var response = _firebaseService.GetBenefitsById<FireBenefit>(benefits.id, CancellationToken.None);
            if(response.Result.Count == 0)
            {
                idMax = 0;
            }
            else
            {
                idMax = response.Result.Max(x => x.id);
            }
           
            
            foreach (var data in benefits.benefits)
            {
                idMax = idMax + 1;
                var dbData = new FireBenefit
                {
                    id = idMax,
                    benefit = data.benefit
                };



                resp =  _firebaseService.AddBenefit(dbData, benefits.id, CancellationToken.None);
            }

            resp.Wait();

            var responseData = _firebaseService.GetBenefitsById<FireBenefit>(benefits.id, CancellationToken.None);
            //return responseData.Result.ToList();

            var res = responseData.Result;

            return res.OrderBy(x=>x.id).ToList();
        }


        public List<FireBenefit> GetBenefitsById(int id)
        {

            var responseData = _firebaseService.GetBenefitsById<FireBenefit>(id, CancellationToken.None);
            //return responseData.Result.ToList();

            var res = responseData.Result;

            return res.ToList();
        }

        public List<FireBenefit> DeleteBenefitById(int id)
        {

            var responseData = _firebaseService.DeleteBenefitById<FireBenefit>(id, CancellationToken.None);
            //return responseData.Result.ToList();

            //var res = responseData.Result;

            return null;
        }










    }







}
