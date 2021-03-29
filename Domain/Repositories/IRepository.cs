using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace Domain.Repositories
{
    public interface IRepository<T> where T:IAggregateRoot
    {
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}