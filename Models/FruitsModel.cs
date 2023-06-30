using FruitsManagementAPI.Services;
using Google.Cloud.Firestore;
using static FruitsManagementAPI.Models.FruitsModel;

namespace FruitsManagementAPI.Models
{
    public class FruitsModel
    {

        [FirestoreData]
        public class FruitsResponseModel: IFirebaseEntity
        {

            [FirestoreProperty]
            public int id { get; set; }

            [FirestoreProperty]
            public string desc { get; set; }


            [FirestoreProperty]
            public string name { get; set; }


            [FirestoreProperty]
            public string family { get; set; }

            [FirestoreProperty]
            public string order { get; set; }

            [FirestoreProperty]
            public string genus { get; set; }


            [FirestoreProperty]
            public string url { get; set; }

            [FirestoreProperty]
            public int calories { get; set; }

            [FirestoreProperty]
            public double fat { get; set; }

            [FirestoreProperty]
            public double sugar { get; set; }

            [FirestoreProperty]
            public double carbohydrates { get; set; }

            [FirestoreProperty]
            public double protein { get; set; }

        }


      


        public class Fruits
        {

  
            public int id { get; set; }

            public string desc { get; set; }

            public string url { get; set; }

            public string name { get; set; }


           
            public string family { get; set; }

           
            public string order { get; set; }

           
            public string genus { get; set; }

           
            public Nutrition nutritions { get; set; }

           


        }

        public class Nutrition
        {


            public int calories { get; set; }


            public double fat { get; set; }


            public double sugar { get; set; }


            public double carbohydrates { get; set; }


            public double protein { get; set; }
        }



    }


    

}
