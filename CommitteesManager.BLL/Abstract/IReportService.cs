using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.BLL.Model;

namespace CommitteesManager.BLL.Abstract
{
    public interface IReportService
    {
        IQueryable<RegistryRecord> GetRegistryQuery();
    }
}
