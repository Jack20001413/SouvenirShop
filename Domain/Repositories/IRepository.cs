using System.Collections.Generic;
using SouvenirShop.Domain.Entities.Common;

namespace Domain.Repositories
{
    public interface IRepository<T> where T:IAggregateRoot
    {
        T GetById(int id);
        int Create(T entity);
        int Update(T entity);
        int Delete(T entity);

    }
}