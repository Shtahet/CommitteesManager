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
    public class RegionProvider:IRegionService
    {
        private IDataProvider _dataProvider;
        public RegionProvider(IDataProvider incomingDataProvider)
        {
            _dataProvider = incomingDataProvider;
        }

        public void AddOrUpdate(Region obj)
        {
            _dataProvider.Regions.AddOrUpdate(obj);
        }

        public void Delete(int Id)
        {
            _dataProvider.Regions.Delete(new Region() { RegionID = Id });
        }

        public void Delete(Region obj)
        {
            _dataProvider.Regions.Delete(obj);
        }

        public IEnumerable<Region> FindBy(Expression<Func<Region, bool>> predicate)
        {
            return _dataProvider.Regions.FindBy(predicate).AsEnumerable();
        }

        public Region Get(int Id)
        {
            return _dataProvider.Regions.Get(Id);
        }

        Region ITemplateService<Region>.Get(object key)
        {
            if(!(key is int))
            {
                return null;
            }
            return Get((int)key);
        }

        public IEnumerable<Region> GetActualAll()
        {
            return _dataProvider.Regions.GetAll().Where(r => r.Is_available == true).AsEnumerable();
        }

        public IEnumerable<Region> GetAll()
        {
            return _dataProvider.Regions.GetAll().AsEnumerable();
        }
    }
}
