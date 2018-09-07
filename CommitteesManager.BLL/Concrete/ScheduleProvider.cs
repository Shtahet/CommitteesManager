using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.BLL.Abstract;
using CommitteesManager.DAL.Abstract;

namespace CommitteesManager.BLL.Concrete
{
    class ScheduleProvider: IScheduleService
    {
        private readonly IDataProvider _dataProvider;

        public ScheduleProvider(IDataProvider provider)
        {
            _dataProvider = provider;
        }
        public DateTime AdmissionStartDate { get; set; }
        public DateTime AdmissionStopDate { get; set; }
        public DateTime CommitteeDate { get; set; }
        public DateTime LastCommitteeDate { get; set; }
        public ScheduleStatus Status { get; set; }

        public bool CloseSchedule()
        {
            throw new NotImplementedException();
        }

        public bool OpenSchedule()
        {
            throw new NotImplementedException();
        }
        public bool DismissSchedule()
        {
            throw new NotImplementedException();
        }

        protected bool SaveChange()
        {
            throw new NotImplementedException();
        }

        protected bool LoadData()
        {
            throw new NotImplementedException();
        }
    }
}
