using System.Collections.Generic;
using Domain.Repositories;
using SouvenirShop.Domain.Entities.Common;

namespace Infrastructure.Persistence
{
    public class EFRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly SouvenirShopDbContext _db;

        public EFRepository(SouvenirShopDbContext db)
        {
            _db = db;
        }

        public void Create(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}