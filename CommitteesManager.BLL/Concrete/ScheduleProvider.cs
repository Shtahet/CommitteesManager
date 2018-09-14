using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.BLL.Abstract;
using CommitteesManager.DAL.Abstract;
using CommitteesManager.DAL.Model;
using Environment = CommitteesManager.DAL.Model.Environment;

namespace CommitteesManager.BLL.Concrete
{
    class ScheduleProvider: IScheduleService
    {
        private readonly IDataProvider _dataProvider;

        public ScheduleProvider(IDataProvider provider)
        {
            _dataProvider = provider;
            LoadData();
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
            IRepository<Environment> envRepo = _dataProvider.Environments;

            bool loadResult = true;
			bool ParseResult = true;

            loadResult &= ParseResult = DateTime.TryParse(envRepo.FindBy(x => x.EnvName == "AdmissionStartDate").FirstOrDefault()?.EnvValue, out DateTime admStartDate);
			if (ParseResult)
				AdmissionStartDate = admStartDate;

			loadResult &= ParseResult = DateTime.TryParse(envRepo.FindBy(x => x.EnvName == "AdmissionStopDate").FirstOrDefault()?.EnvValue, out DateTime admStopDate);
			if (ParseResult)
				AdmissionStopDate = admStopDate;

			loadResult &= ParseResult = DateTime.TryParse(envRepo.FindBy(x => x.EnvName == "ScheduledCommitteeDate").FirstOrDefault()?.EnvValue, out DateTime schedDate);
            if (ParseResult)
				CommitteeDate = schedDate.Date;

			loadResult &= ParseResult = DateTime.TryParse(envRepo.FindBy(x => x.EnvName == "LastCommitteeDate").FirstOrDefault()?.EnvValue, out DateTime lastComDate);
			if (ParseResult)
				LastCommitteeDate = lastComDate.Date;

			loadResult &= ParseResult = Enum.TryParse(envRepo.FindBy(x => x.EnvName == "StatusCommitteeDate").FirstOrDefault()?.EnvValue, out ScheduleStatus schStatus);
			if (ParseResult)
				Status = schStatus;

            return loadResult;
        }
    }
}
