using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Abstract
{
    public interface IProtocolService:ITemplateService<Protocol>
    {
        Protocol Get(int Id);
        void Delete(int Id);
    }
}
