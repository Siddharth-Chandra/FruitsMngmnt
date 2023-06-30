using FruitsManagementAPI.Services;
using Google.Cloud.Firestore;

namespace FruitsManagementAPI.Models
{
    public class Benefits : IFirebaseEntity
    {
     
        public int id { get; set; }

        public List<Benefit> benefits { get; set; }
    }

    public class Benefit
    {
        public string benefit { get; set; }
    }


    [FirestoreData]
    public class  FireBenefit : IFirebaseEntity
    {

        [FirestoreProperty]
        public int id { get; set; }

        [FirestoreProperty]
        public string benefit { get; set; }
    }


}
