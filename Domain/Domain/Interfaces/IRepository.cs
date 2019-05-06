using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        T Delete(ObjectId id);

        T Select(ObjectId id);

        IList<T> Select();
    }
}
