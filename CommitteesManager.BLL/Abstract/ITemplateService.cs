using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Abstract
{
    public interface ITemplateService<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetActualAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(object key);
        void AddOrUpdate(T obj);
        void Delete(T obj);
    }
}
