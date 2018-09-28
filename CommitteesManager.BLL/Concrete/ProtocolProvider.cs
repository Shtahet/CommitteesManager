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
    public class ProtocolProvider:IProtocolService
    {
        private IDataProvider _dataProvider;
        public ProtocolProvider(IDataProvider incomingDataProvider)
        {
            _dataProvider = incomingDataProvider;
        }

        public void AddOrUpdate(Protocol obj)
        {
            _dataProvider.Protocols.AddOrUpdate(obj);
        }

        public void Delete(int Id)
        {
            _dataProvider.Protocols.Delete(new Protocol() { ProtocolID = Id });
        }

        public void Delete(Protocol obj)
        {
            _dataProvider.Protocols.Delete(obj);
        }

        public IEnumerable<Protocol> FindBy(Expression<Func<Protocol, bool>> predicate)
        {
            return _dataProvider.Protocols.FindBy(predicate);
        }

        public Protocol Get(int Id)
        {
            return _dataProvider.Protocols.Get(Id);
        }

        Protocol ITemplateService<Protocol>.Get(object key)
        {
            if (!(key is int))
            {
                return null;
            }
            return Get((int)key);
        }

        IEnumerable<Protocol> ITemplateService<Protocol>.GetActualAll()
        {
            return _dataProvider.Protocols.GetAll().AsEnumerable();
        }

        public IEnumerable<Protocol> GetAll()
        {
            return _dataProvider.Protocols.GetAll().AsEnumerable();
        }
    }
}
