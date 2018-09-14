using CommitteesManager.AppUIClient.Infrastructure;
using CommitteesManager.BLL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class PlaneMeetingViewModel : ViewModelSection
    {
        public PlaneMeetingViewModel(IServiceProvider provider) : base(provider)
        {
        }
        public override ViewModelSection Filter { get => null; set { } }

		public ScheduleStatus MeetingStatus
		{
			get { return _services.ScheduleService.Status; }
		}

		public DateTime LastCommitteeDate
		{
			get { return _services.ScheduleService.LastCommitteeDate.Date; }
		}

		public DateTime AdmissionStartDate
		{
			get { return _services.ScheduleService.AdmissionStartDate; }
		}

		public DateTime AdmissionStopDate
		{
			get { return _services.ScheduleService.AdmissionStopDate; }
		}
	}
}
