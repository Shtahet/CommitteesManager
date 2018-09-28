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
        private ICommitteModeService _comMode;
        private IDealTypeService _dealType;
        private IReportService _reports;
        private IDealService _deals;
        private IProtocolService _protocols;
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
        public ICommitteModeService CommitteeModeService
        {
            get
            {
                if(_comMode == null)
                {
                    _comMode = new ModeProvider(_dataProvider);
                }
                return _comMode;
            }
        }
        public IDealTypeService DealTypeService
        {
            get
            {
                if (_dealType == null)
                {
                    _dealType = new DealTypeProvider(_dataProvider);
                }
                return _dealType;
            }
        }
        public IReportService ReportService
        {
            get
            {
                if(_reports == null)
                {
                    _reports = new ReportProvider(_dataProvider);
                }
                return _reports;
            }
        }
        public IDealService DealService
        {
            get
            {
                if (_deals == null)
                {
                    _deals = new DealProvider(_dataProvider);
                }
                return _deals;
            }
        }
        public IProtocolService ProtocolService
        {
            get
            {
                if (_protocols == null)
                {
                    _protocols = new ProtocolProvider(_dataProvider);
                }
                return _protocols;
            }
        }
    }
}
