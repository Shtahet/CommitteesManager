using CommitteesManager.BLL.Abstract;
using CommitteesManager.DAL.Abstract;
using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Concrete
{
    public class DealProvider : IDealService
    {
        private IDataProvider _dataProvider;
        public DealProvider(IDataProvider incomingDataProvider)
        {
        }
        public void AddOrUpdate(Deal obj)
        {
            _dataProvider.Deals.AddOrUpdate(obj);
        }

        public void Delete(int Id)
        {
            _dataProvider.Deals.Delete(new Deal() { DealID = Id });
        }

        public void Delete(Deal obj)
        {
            _dataProvider.Deals.Delete(obj);
        }

        public IEnumerable<Deal> FindBy(Expression<Func<Deal, bool>> predicate)
        {
            return _dataProvider.Deals.FindBy(predicate);
        }

        public Deal Get(int Id)
        {
            return _dataProvider.Deals.Get(Id);
        }

        Deal ITemplateService<Deal>.Get(object key)
        {
            if (!(key is int))
            {
                return null;
            }
            return Get((int)key);
        }

        IEnumerable<Deal> ITemplateService<Deal>.GetActualAll()
        {
            return _dataProvider.Deals.GetAll().AsEnumerable();
        }

        public IEnumerable<Deal> GetAll()
        {
            return _dataProvider.Deals.GetAll().AsEnumerable();
        }
    }
}
