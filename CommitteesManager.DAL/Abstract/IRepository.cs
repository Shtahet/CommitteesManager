using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.DAL.Abstract
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(object key);
        void AddOrUpdate(T obj);
        void Delete(T obj);
    }
}
