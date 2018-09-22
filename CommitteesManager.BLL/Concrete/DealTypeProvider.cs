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
    public class DealTypeProvider : IDealTypeService
    {
        private IDataProvider _dataProvider;
        public DealTypeProvider(IDataProvider IncomingProvider)
        {
            _dataProvider = IncomingProvider;
        }
        public void AddOrUpdate(DealType obj)
        {
            _dataProvider.DealTypes.AddOrUpdate(obj);
        }

        public void Delete(int Id)
        {
            _dataProvider.DealTypes.Delete(new DealType() { Deal_typeID = Id });
        }

        public void Delete(DealType obj)
        {
            _dataProvider.DealTypes.Delete(obj);
        }

        public IEnumerable<DealType> FindBy(Expression<Func<DealType, bool>> predicate)
        {
            return _dataProvider.DealTypes.FindBy(predicate).AsEnumerable();
        }

        public DealType Get(int Id)
        {
            return _dataProvider.DealTypes.Get(Id);
        }

        DealType ITemplateService<DealType>.Get(object key)
        {
            if (!(key is int)){
                return null;
            }
            return Get((int)key);
        }

        public IEnumerable<DealType> GetActualAll()
        {
            return _dataProvider.DealTypes.GetAll().Where(x => x.Is_available == true).AsEnumerable();
        }

        public IEnumerable<DealType> GetAll()
        {
            return _dataProvider.DealTypes.GetAll().AsEnumerable();
        }
    }
}
