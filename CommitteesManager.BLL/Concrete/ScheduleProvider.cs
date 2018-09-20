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
		public const string AdmissionStartDateName = "AdmissionStartDate";
		public const string AdmissionStopDateName = "AdmissionStopDate";
		public const string CommitteeDateName = "ScheduledCommitteeDate";
		public const string LastCommitteeDateName = "LastCommitteeDate";
		public const string StatusName = "StatusCommitteeDate";

		private readonly IDataProvider _dataProvider;

        public ScheduleProvider(IDataProvider provider)
        {
            _dataProvider = provider;
            LoadData();
        }

        public DateTime? AdmissionStartDate { get; set; }
        public DateTime? AdmissionStopDate { get; set; }
        public DateTime? CommitteeDate { get; set; }
        public DateTime? LastCommitteeDate { get; set; }
        public ScheduleStatus Status { get; set; }

        public bool CloseSchedule()
        {
            throw new NotImplementedException();
        }

        public bool OpenSchedule()
        {
            Environment startDate = _dataProvider.Environments.FindBy(x => x.EnvName == AdmissionStartDateName).FirstOrDefault();
			if (startDate == null)
			{
				startDate = new Environment()
				{
					EnvName = AdmissionStartDateName,
				};
			}
			startDate.EnvValue = AdmissionStartDate.ToString();
			_dataProvider.Environments.AddOrUpdate(startDate);
			

			Environment stopDate = _dataProvider.Environments.FindBy(x => x.EnvName == AdmissionStopDateName).FirstOrDefault();
			if (stopDate == null)
			{
				stopDate = new Environment()
				{
					EnvName = AdmissionStopDateName,
				};
			}
			stopDate.EnvValue = AdmissionStopDate.ToString();
			_dataProvider.Environments.AddOrUpdate(stopDate);

			Environment committeeDate = _dataProvider.Environments.FindBy(x => x.EnvName == CommitteeDateName).FirstOrDefault();
			if (committeeDate == null)
			{
				committeeDate = new Environment()
				{
					EnvName = CommitteeDateName,
				};
			}
			committeeDate.EnvValue = CommitteeDate.ToString();
			_dataProvider.Environments.AddOrUpdate(committeeDate);

			Environment lastCommitteeDate = _dataProvider.Environments.FindBy(x => x.EnvName == LastCommitteeDateName).FirstOrDefault();
			if (lastCommitteeDate == null)
			{
				lastCommitteeDate = new Environment()
				{
					EnvName = LastCommitteeDateName
				};
			}
			lastCommitteeDate.EnvValue = LastCommitteeDate.ToString();
			_dataProvider.Environments.AddOrUpdate(lastCommitteeDate);

            Status = (DateTime.Now >= AdmissionStartDate && DateTime.Now <= AdmissionStopDate) ? ScheduleStatus.Preparing : ScheduleStatus.Scheduled;
			Environment dbStatus = _dataProvider.Environments.FindBy(x => x.EnvName == StatusName).FirstOrDefault();
			if (dbStatus == null)
			{
				dbStatus = new Environment()
				{
					EnvName = StatusName
				};
			}
			dbStatus.EnvValue = Status.ToString();
            _dataProvider.Environments.AddOrUpdate(dbStatus);

			return true;
        }
        public bool DismissSchedule()
        {
            bool result = false;
            LoadData();
            if (Status == ScheduleStatus.Preparing || Status == ScheduleStatus.Scheduled)
            {
                Status = ScheduleStatus.Canceled;
                Environment dbStatus = _dataProvider.Environments.FindBy(x => x.EnvName == StatusName).FirstOrDefault();
                if (dbStatus == null)
                {
                    dbStatus = new Environment() { EnvName = StatusName };
                }
                dbStatus.EnvValue = Status.ToString();
                _dataProvider.Environments.AddOrUpdate(dbStatus);
                result = true;
            }

            return result;
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        protected bool LoadData()
        {
            IRepository<Environment> envRepo = _dataProvider.Environments;

            bool loadResult = true;
			bool ParseResult = true;

            loadResult &= ParseResult = DateTime.TryParse(envRepo.FindBy(x => x.EnvName == AdmissionStartDateName).FirstOrDefault()?.EnvValue, out DateTime admStartDate);
			if (ParseResult)
				AdmissionStartDate = admStartDate;

			loadResult &= ParseResult = DateTime.TryParse(envRepo.FindBy(x => x.EnvName == AdmissionStopDateName).FirstOrDefault()?.EnvValue, out DateTime admStopDate);
			if (ParseResult)
				AdmissionStopDate = admStopDate;

			loadResult &= ParseResult = DateTime.TryParse(envRepo.FindBy(x => x.EnvName == CommitteeDateName).FirstOrDefault()?.EnvValue, out DateTime schedDate);
            if (ParseResult)
				CommitteeDate = schedDate.Date;

			loadResult &= ParseResult = DateTime.TryParse(envRepo.FindBy(x => x.EnvName == LastCommitteeDateName).FirstOrDefault()?.EnvValue, out DateTime lastComDate);
			if (ParseResult)
				LastCommitteeDate = lastComDate.Date;

			loadResult &= ParseResult = Enum.TryParse(envRepo.FindBy(x => x.EnvName == StatusName).FirstOrDefault()?.EnvValue, out ScheduleStatus schStatus);
			if (ParseResult)
				Status = schStatus;

            return loadResult;
        }
    }
}
