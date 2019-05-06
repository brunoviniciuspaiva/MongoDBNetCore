using Data.Repository;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Service.Services
{

    public class BaseService<T>: IService<T> where T : BaseEntity
    {
        private readonly BaseRepository<T> _baseRepository;

        public BaseService(IConfiguration configuration)
        {
            _baseRepository = new BaseRepository<T>(configuration);
        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _baseRepository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _baseRepository.Update(obj);
            return obj;
        }

        public T Delete(string id)
        {
            ValidateId(id);
            return _baseRepository.Delete(ObjectId.Parse(id));
        }

        public IList<T> Get() => _baseRepository.Select();

        public T Get(string id)
        {
            ValidateId(id);
            return _baseRepository.Select(ObjectId.Parse(id));
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new ArgumentException("Uninformed records!");

            validator.ValidateAndThrow(obj);
        }

        private void ValidateId(string id)
        {
            if (id.Equals(0) || id.Length < 24)
                throw new ArgumentException($"Id: {id} is not a valid 24 digit hex string.");
        }
    }
}
