using FruitsManagementAPI.Models;
using Google.Cloud.Firestore;

namespace FruitsManagementAPI.Services
{

    public interface IFirebaseEntity
    {
        public int id { get; set; }
    }


    public interface IFirestoreProvider
    {
        Task AddOrUpdate<T>(T entity, CancellationToken ct) where T : IFirebaseEntity;
        Task<T> Get<T>(string id, CancellationToken ct) where T : IFirebaseEntity;
        Task<IReadOnlyCollection<T>> GetAll<T>(CancellationToken ct) where T : IFirebaseEntity;
        Task<IReadOnlyCollection<T>> WhereEqualTo<T>(string fieldPath, object value, CancellationToken ct) where T : IFirebaseEntity;
        Task AddBenefit<T>(T entity, int id, CancellationToken ct) where T : IFirebaseEntity;
        Task<IReadOnlyCollection<T>> GetBenefitsById<T>(int id, CancellationToken ct) where T : IFirebaseEntity;
        Task DeleteBenefitById<T>(int id, CancellationToken ct) where T : IFirebaseEntity;
        Task Update<T>(T entity,string desc, CancellationToken ct) where T : IFirebaseEntity;

        Task UpdatePhoto<T>(T entity, string url, CancellationToken ct) where T : IFirebaseEntity;



        public class FirestoreProvider : IFirestoreProvider
        {

            private readonly FirestoreDb _fireStoreDb = null!;

            public FirestoreProvider(FirestoreDb fireStoreDb)
            {
                _fireStoreDb = fireStoreDb;
            }

            public async Task AddOrUpdate<T>(T entity, CancellationToken ct) where T : IFirebaseEntity
            {
                var document = _fireStoreDb.Collection("Fruits").Document(Convert.ToString(entity.id));
                await document.SetAsync(entity, cancellationToken: ct);
            }

            public async Task Update<T>(T entity,string desc, CancellationToken ct) where T : IFirebaseEntity
            {
                var document = _fireStoreDb.Collection("Fruits").Document(Convert.ToString(entity.id));

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("desc", desc);
                await document.UpdateAsync(dic, cancellationToken: ct);
            }


            public async Task UpdatePhoto<T>(T entity, string url, CancellationToken ct) where T : IFirebaseEntity
            {
                var document = _fireStoreDb.Collection("Fruits").Document(Convert.ToString(entity.id));

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("url", url);
                await document.UpdateAsync(dic, cancellationToken: ct);
            }



            public async Task AddBenefit<T>(T entity, int id, CancellationToken ct) where T : IFirebaseEntity
            {
                var document = _fireStoreDb.Collection("Fruits").Document(Convert.ToString(id)).Collection("Benefits").Document(Guid.NewGuid().ToString());
                await document.SetAsync(entity, cancellationToken: ct);
            }

            public async Task<IReadOnlyCollection<T>> GetBenefitsById<T>(int id, CancellationToken ct) where T : IFirebaseEntity
            {
                var collection = _fireStoreDb.Collection("Fruits").Document(Convert.ToString(id)).Collection("Benefits");
                var snapshot = await collection.GetSnapshotAsync(ct);
                var data = snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
                return data;
            }

            public async Task<T> Get<T>(string id, CancellationToken ct) where T : IFirebaseEntity
            {
                var document = _fireStoreDb.Collection("Fruits").Document(id);
                var snapshot = await document.GetSnapshotAsync(ct);
                return snapshot.ConvertTo<T>();
            }

            public async Task<IReadOnlyCollection<T>> GetAll<T>(CancellationToken ct) where T : IFirebaseEntity
            {
                var collection = _fireStoreDb.Collection("Fruits");
                var snapshot = await collection.GetSnapshotAsync(ct);

                var data = snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
                return data;
            }

            public async Task DeleteBenefitById<T>(int id, CancellationToken ct) where T : IFirebaseEntity
            {
                var document = _fireStoreDb.Collection("Fruits").Document(Convert.ToString(id)).Collection("Benefits");
                var snapshot = await document.GetSnapshotAsync(ct);

            }

            public async Task<IReadOnlyCollection<T>> WhereEqualTo<T>(string fieldPath, object value, CancellationToken ct) where T : IFirebaseEntity
            {
                return await GetList<T>(_fireStoreDb.Collection(typeof(T).Name).WhereEqualTo(fieldPath, value), ct);
            }

            private static async Task<IReadOnlyCollection<T>> GetList<T>(Query query, CancellationToken ct) where T : IFirebaseEntity
            {
                var snapshot = await query.GetSnapshotAsync(ct);
                return snapshot.Documents.Select(x => x.ConvertTo<T>()).ToList();
            }

        }
    }
}
