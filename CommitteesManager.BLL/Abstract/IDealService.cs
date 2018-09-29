using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Abstract
{
    public interface IDealService:ITemplateService<Deal>
    {
        Deal Get(int Id);
        void Delete(int Id);
        int GetNextId();
    }
}
