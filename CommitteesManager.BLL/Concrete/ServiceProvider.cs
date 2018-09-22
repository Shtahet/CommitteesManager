using CommitteesManager.DAL.Abstract;
using CommitteesManager.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Concrete
{
    public class ServiceProvider : Abstract.IServiceProvider
    {
        private readonly IDataProvider _dataProvider;
        private IScheduleService _schedule;
        private ICommitteeService _committee;
        public ServiceProvider(IDataProvider provider)
        {
            _dataProvider = provider;
        }

        public IScheduleService ScheduleService
        {
            get
            {
                if (_schedule == null)
                    _schedule = new ScheduleProvider(_dataProvider);
                return _schedule;
            }
        }
        public ICommitteeService CommitteeService
        {
            get
            {
                if (_committee == null)
                {
                    _committee = new CommitteeProvider(_dataProvider);
                }
                return _committee;
            }
        }
    }
}
