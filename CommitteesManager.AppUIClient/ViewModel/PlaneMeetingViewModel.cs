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

		public DateTime? CommitteeDate
		{
			get { return _services.ScheduleService.CommitteeDate?.Date; }
		}

		public DateTime? AdmissionStartDate
		{
			get { return _services.ScheduleService.AdmissionStartDate; }
		}

		public DateTime? AdmissionStopDate
		{
			get { return _services.ScheduleService.AdmissionStopDate; }
		}

        private RelayCommand _dismissScheduleCmd;
        public RelayCommand DismissSchedule
        {
            get
            {
                if (_dismissScheduleCmd == null)
                    _dismissScheduleCmd = new RelayCommand(
                        obj => 
                    {
                        _services.ScheduleService.DismissSchedule();
                    }, 
                        execObj => 
                    {
                        return MeetingStatus == ScheduleStatus.Preparing || MeetingStatus == ScheduleStatus.Scheduled;
                    });

                return _dismissScheduleCmd;
            }
        }

        private RelayCommand _createMeeting;
        public RelayCommand CreateMeeting
        {
            get
            {
                if (_createMeeting == null)
                    _createMeeting = new RelayCommand(obj =>
                    {
                        ViewModelSection createMeeting = ViewModelBase.GetNewSection(ViewModels.CreateMeeting, _services);
                        InvokeCreateViewEvent(this, new ViewModelEventArgs(JoinDirectionEnum.After, createMeeting));
                    });

                return _createMeeting;
            }
        }
	}
}
