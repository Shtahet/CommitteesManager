using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.DAL.Model;
using Environment = CommitteesManager.DAL.Model.Environment;

namespace CommitteesManager.DAL.Abstract
{
    public interface IDataProvider
    {
        IRepository<Environment> Environments { get; }
    }
}
