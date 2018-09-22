using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.DAL.Model;

namespace CommitteesManager.BLL.Abstract
{
    public interface ICommitteeService: ITemplateService<Committee>
    {
        Committee Get(int key);
        void Delete(int key);
    }
}
