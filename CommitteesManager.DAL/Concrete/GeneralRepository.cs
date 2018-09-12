using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.DAL.Abstract;

namespace CommitteesManager.DAL.Concrete
{
    public class GeneralRepository<T> : IRepository<T> where T: class, new()
    {
        private DbContext _dbContext;
        private DbSet<T> dbSet;
        public GeneralRepository(DbContext incomingContext)
        {
            _dbContext = incomingContext;
            dbSet = incomingContext.Set<T>();
        }
        public void AddOrUpdate(T obj)
        {
            dbSet.AddOrUpdate(obj);
            _dbContext.SaveChanges();
        }

        public void Delete(object key)
        {
            T efObj = dbSet.Find(key);
            dbSet.Remove(efObj);
            _dbContext.SaveChanges();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public T Get(object key)
        {
            return dbSet.Find(key);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }
}
