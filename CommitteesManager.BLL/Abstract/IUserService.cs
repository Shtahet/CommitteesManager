using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Abstract
{
    public interface IUserService:ITemplateService<User>
    {
        User Get(string Id);
        void Delete(string Id);
    }
}
