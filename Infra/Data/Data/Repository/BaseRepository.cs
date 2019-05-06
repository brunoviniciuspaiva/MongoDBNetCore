using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class BaseRepository<T>: IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _context;

        public BaseRepository(IConfiguration configuration)
        {
            _context = new MongoDBContext<T>(configuration)._context;
        }
        
        public void Insert(T obj)
        {
            _context.InsertOne(obj);
        }

        public void Update(T obj)
        {
            _context.ReplaceOne(Filter(obj.Id), obj);
        }

        public T Delete(ObjectId id)
        {
            T result = Select(id);
            _context.DeleteOne(Filter(id));
            return result;
        }

        public IList<T> Select()
        {
            return _context.Find(_ => true).ToList();
        }

        public T Select(ObjectId id)
        {
            return _context.Find(Filter(id)).FirstOrDefault();
        }

        private FilterDefinition<T> Filter(ObjectId id)
        {
            return Builders<T>.Filter.Eq("_id", id);
        }
    }
}
