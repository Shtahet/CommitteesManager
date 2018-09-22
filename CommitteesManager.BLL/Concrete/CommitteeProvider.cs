using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.BLL.Abstract;
using CommitteesManager.DAL.Abstract;
using CommitteesManager.DAL.Model;

namespace CommitteesManager.BLL.Concrete
{
    public class CommitteeProvider : ICommitteeService
    {
        IDataProvider _dataProvider;
        public CommitteeProvider(IDataProvider IncomingProvider)
        {
            _dataProvider = IncomingProvider;
        }
        public void AddOrUpdate(Committee obj)
        {
            _dataProvider.Committees.AddOrUpdate(obj);
        }

        public void Delete(Committee obj)
        {
            _dataProvider.Committees.Delete(obj);
        }

        public void Delete(int Id)
        {
            _dataProvider.Committees.Delete(new Committee() { CommitteeID = Id });
        }

        public IEnumerable<Committee> FindBy(Expression<Func<Committee, bool>> predicate)
        {
            return _dataProvider.Committees.FindBy(predicate);
        }

        public Committee Get(int key)
        {
            return _dataProvider.Committees.Get(key);
        }

        Committee ITemplateService<Committee>.Get(object key)
        {
            if (!(key is int))
            {
                return null;
            }
            return Get((int)key);
        }

        public IEnumerable<Committee> GetActualAll()
        {
            return _dataProvider.Committees.GetAll().Where(x => x.Is_available == true).AsEnumerable();
        }

        public IEnumerable<Committee> GetAll()
        {
            return _dataProvider.Committees.GetAll().AsEnumerable();
        }
    }
}
