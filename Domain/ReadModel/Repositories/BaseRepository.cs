using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.ReadModel.Repositories.Interfaces;
using MongoDB.Driver;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Domain.ReadModel.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : IId
    {
        protected readonly IMongoCollection<T> Collection;

        protected BaseRepository(IMongoCollection<T> collection)
        {
            Collection = collection;
        }
        
        public async Task Add(T item)
        {
            await Collection.InsertOneAsync(item);
        }

        public async Task<bool> Exists(int id)
        {
            return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync() != null;
        }

        public async Task<T> Get(int id)
        {
            return await Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Collection.Find(FilterDefinition<T>.Empty).ToListAsync();
        }

//        public T Get<T>(string keySuffix)
//        {
//            var serializedObject = _database.StringGet(MakeKey(keySuffix));
//            
//            if (serializedObject.IsNullOrEmpty) 
//                throw new ArgumentNullException(); //Throw a better exception than this, please
//            
//            return JsonConvert.DeserializeObject<T>(serializedObject.ToString());
//        }

        public async Task<IList<T>> GetMany(int[] ids)
        {
            var filter = Builders<T>.Filter.In(x => x.Id, ids);

            return await Collection.Find(filter).ToListAsync();
        }

        public async Task<bool> Save(T item)
        {
            var updateResult = await Collection.UpdateOneAsync(item.FilterDefinition<T>(), item.UpdateDefinition<T>());

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        } 

//        public bool Exists(int id)
//        {
//            return Exists(id.ToString());
//        }
//
//        public bool Exists(string keySuffix)
//        {
//            var serializedObject = _database.StringGet(MakeKey(keySuffix));
//            
//            return !serializedObject.IsNullOrEmpty;
//        }

//        public void Save(int id, object entity)
//        {
//            Save(id.ToString(), entity);
//        }
//
//        public void Save(string keySuffix, object entity)
//        {
//            _database.StringSet(MakeKey(MakeKey(keySuffix)), JsonConvert.SerializeObject(entity));
//        }
//
//        private string MakeKey(string keySuffix)
//        {
//            return keySuffix.StartsWith(_namespace) ? keySuffix : _namespace+ keySuffix;
//        }
    }

    public interface IId
    {
        int Id { get; set; }

        FilterDefinition<T> FilterDefinition<T>();

        UpdateDefinition<T> UpdateDefinition<T>();
    }
}