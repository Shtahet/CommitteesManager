using CommitteesManager.DAL.Abstract;
using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Environment = CommitteesManager.DAL.Model.Environment;

namespace CommitteesManager.DAL.Concrete
{
    public class DataProvider : IDataProvider
    {
        private CMDB _dbContext;
        private GeneralRepository<Environment> _environmentRepo;
        public DataProvider()
        {
            _dbContext = new CMDB();
        }
        public IRepository<Model.Environment> Environments
        {
            get
            {
                if (_environmentRepo == null)
                {
                    _environmentRepo = new GeneralRepository<Environment>(_dbContext);
                }
                return _environmentRepo;
            }
        }
    }
}
