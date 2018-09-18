using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.AppUIClient.Infrastructure;
using CommitteesManager.BLL.Abstract;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;

namespace CommitteesManager.AppUIClient.ViewModel
{
    internal class CreateMeetingViewModel : ViewModelSection
    {
        internal CreateMeetingViewModel(IServiceProvider IncomingServiceProvider) : base(IncomingServiceProvider)
        {
        }
        public override ViewModelSection Filter { get => null; set { } }

        public DateTime? CommeetteeDate { get; set; }
        public DateTime? AdmissionStartDate { get; set; }
        public DateTime? AdmissionStartTime { get; set; }
        public DateTime? AdmissionStopDate { get; set; }
        public DateTime? AdmissionStopTime { get; set; }
        private bool _isSaveCompleted;
        public bool IsSaveCompleted
        {
            get { return _isSaveCompleted; }
            private set
            {
                _isSaveCompleted = value;
                OnPropertyChanged("IsSaveCompleted");
            }
        }

        private RelayCommand _createMeeting;
        public RelayCommand CreateMeeting
        {
            get
            {
                if (_createMeeting == null)
                    _createMeeting = new RelayCommand(saveMeeting, obj =>
                    {
                        return CommeetteeDate != null &&
                            AdmissionStartDate != null &&
                            AdmissionStartTime != null &&
                            AdmissionStopDate != null &&
                            AdmissionStopTime != null;
                    });

                return _createMeeting;
            }
        }

        private void saveMeeting(object obj)
        {
            IScheduleService service = _services.ScheduleService;
            service.CommitteeDate = CommeetteeDate;
            service.AdmissionStartDate = AdmissionStartDate.Value.AddTicks(AdmissionStartTime.Value.Ticks);
            service.AdmissionStopDate = AdmissionStopDate.Value.AddTicks(AdmissionStopTime.Value.Ticks);
            IsSaveCompleted = service.OpenSchedule();
        }
    }
}
