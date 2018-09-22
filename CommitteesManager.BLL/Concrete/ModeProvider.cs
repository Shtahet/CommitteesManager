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
    public class ModeProvider : ICommitteModeService
    {
        private IDataProvider _dataProvider;
        public ModeProvider(IDataProvider IncomingProvider)
        {
            _dataProvider = IncomingProvider;
        }
        public void AddOrUpdate(Mode obj)
        {
            _dataProvider.Modes.AddOrUpdate(obj);
        }

        public void Delete(Mode obj)
        {
            _dataProvider.Modes.Delete(obj);
        }

        public void Delete(int Id)
        {
            _dataProvider.Modes.Delete(new Mode() { ModeID = Id });
        }

        public IEnumerable<Mode> FindBy(Expression<Func<Mode, bool>> predicate)
        {
            return _dataProvider.Modes.FindBy(predicate).AsEnumerable();
        }

        public Mode Get(int Id)
        {
            return _dataProvider.Modes.Get(Id);
        }

        Mode ITemplateService<Mode>.Get(object key)
        {
            if (!(key is int))
            {
                return null;
            }
            return Get((int)key);
        }

        public IEnumerable<Mode> GetActualAll()
        {
            return _dataProvider.Modes.GetAll().Where(x => x.Is_available == true).AsEnumerable();
        }

        public IEnumerable<Mode> GetAll()
        {
            return _dataProvider.Modes.GetAll().AsEnumerable();
        }
    }
}
