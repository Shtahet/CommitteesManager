using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
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

        private const double Interval = 50;         //Milliseconds
        private const int SaveTime = 600;           //Milliseconds

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
            }
        }
        private double _saveProgress;
        public double SaveProgressRate
        {
            get { return _saveProgress; }
            private set
            {
                _saveProgress = value;
                OnPropertyChanged("SaveProgressRate");
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

        private DispatcherTimer _timer;

        private void RaiseTimer()
        {
            _timer = new DispatcherTimer(
                TimeSpan.FromMilliseconds(Interval),
                DispatcherPriority.Normal,
                new EventHandler( (o,e) =>
                {
                    SaveProgressRate += SaveTime / Interval;

                    if (SaveProgressRate >= 100 && IsSaveCompleted)
                    {
                        ((DispatcherTimer)o).Stop();
                        OnPropertyChanged("IsSaveCompleted");
                        SaveProgressRate = 0;
                    }
                    if (SaveProgressRate >= 100)
                    {
                        SaveProgressRate = 0;
                    }
                }),
                Dispatcher.CurrentDispatcher);
            _timer.Start();
        }

        private void saveMeeting(object obj)
        {
            RaiseTimer();
            IScheduleService service = _services.ScheduleService;
            service.CommitteeDate = CommeetteeDate;
            service.AdmissionStartDate = AdmissionStartDate.Value.AddTicks(AdmissionStartTime.Value.Ticks);
            service.AdmissionStopDate = AdmissionStopDate.Value.AddTicks(AdmissionStopTime.Value.Ticks);
            IsSaveCompleted = service.OpenSchedule();
        }
    }
}
