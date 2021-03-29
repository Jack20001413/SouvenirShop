using System.Collections.Generic;
using Domain.Repositories;
using SouvenirShop.Domain.Entities.Common;

namespace Infrastructure.Persistence
{
    public class EFRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected readonly SouvenirShopDbContext _db;

        public EFRepository(SouvenirShopDbContext db)
        {
            _db = db;
        }

        public void Create(T entity)
        {
            _db.Add<T>(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public T GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
        }
    }
}