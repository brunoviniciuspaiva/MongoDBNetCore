using Domain.Entities;
using FluentValidation;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;

        T Put<V>(T obj) where V : AbstractValidator<T>;

        T Delete(string id);

        T Get(string id);

        IList<T> Get();
    }
}
