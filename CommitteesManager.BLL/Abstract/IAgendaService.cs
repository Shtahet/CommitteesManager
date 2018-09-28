using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Abstract
{
    public interface IAgendaService:ITemplateService<Agenda>
    {
        Agenda Get(int Id);
        void Delete(int Id);
    }
}
