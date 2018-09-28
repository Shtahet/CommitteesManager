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
    public class AgendaProvider : IAgendaService
    {
        private IDataProvider _dataProvider;
        public AgendaProvider(IDataProvider incomingDataProvider)
        {
            _dataProvider = incomingDataProvider;
        }

        public void AddOrUpdate(Agenda obj)
        {
            _dataProvider.Agendas.AddOrUpdate(obj);
        }

        public void Delete(int Id)
        {
            _dataProvider.Agendas.Delete(new Agenda() { AgendaID = Id });
        }

        public void Delete(Agenda obj)
        {
            _dataProvider.Agendas.Delete(obj);
        }

        public IEnumerable<Agenda> FindBy(Expression<Func<Agenda, bool>> predicate)
        {
            return _dataProvider.Agendas.FindBy(predicate).AsEnumerable();
        }

        public Agenda Get(int Id)
        {
            return _dataProvider.Agendas.Get(Id);
        }

        Agenda ITemplateService<Agenda>.Get(object key)
        {
            if (!(key is int))
            {
                return null;
            }
            return Get((int)key);
        }

        public IEnumerable<Agenda> GetActualAll()
        {
            return _dataProvider.Agendas.GetAll().AsEnumerable();
        }

        public IEnumerable<Agenda> GetAll()
        {
            return _dataProvider.Agendas.GetAll().AsEnumerable();
        }
    }
}
