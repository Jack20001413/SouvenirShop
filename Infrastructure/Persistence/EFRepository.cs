using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public int Create(T entity)
        {
            _db.Add<T>(entity);
            int res = _db.SaveChanges();
            return res;
        }

        public int Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            int res = _db.SaveChanges();
            return res;
        }

        // private bool Find(int id)
        // {
        //     return _db.Set<T>().Any(s => s.Id == id);
        // }

        public T GetById(int id)
        {
            var entity =  _db.Set<T>().Find(id);
            try
            {
                _db.Entry(entity).State = EntityState.Detached;
            }
            catch (System.ArgumentNullException)
            {
                return null;                
            }
           
            return entity;
        }

        public int Update(T entity)
        {
            int res = 0;
            try
            {
                _db.Set<T>().Update(entity);
                res = _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return -1;
            }
            catch (DbException){
                return -1;
            }
            
            return res;
        }

        
    }
}