using CommitteesManager.AppUIClient.Infrastructure;
using CommitteesManager.BLL.Abstract;
using System;
using System.Windows.Threading;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class PlaneMeetingViewModel : ViewModelSection
    {
        private const double Interval = 50;         //Milliseconds
        private const int SaveTime = 600;           //Milliseconds

        private ViewModelSection _createMeetingVM;
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
        public bool IsCanceled { get; private set; }

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

        private RelayCommand _dismissScheduleCmd;
        public RelayCommand DismissSchedule
        {
            get
            {
                if (_dismissScheduleCmd == null)
                    _dismissScheduleCmd = new RelayCommand(
                        obj =>
                    {
                        RaiseTimer();
                        IsCanceled = _services.ScheduleService.DismissSchedule();
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
                        _createMeetingVM = ViewModelBase.GetNewSection(ViewModels.CreateMeeting, _services);
                        _createMeetingVM.WantToClose += GetResultFromSection;
                        InvokeCreateViewEvent(this, new ViewModelEventArgs(JoinDirectionEnum.After, _createMeetingVM));
                    });

                return _createMeeting;
            }
        }

        private void GetResultFromSection(object sender, ViewModelEventArgs e)
        {
            OnPropertyChanged("MeetingStatus");
            OnPropertyChanged("CommitteeDate");
            OnPropertyChanged("AdmissionStartDate");
            OnPropertyChanged("AdmissionStopDate");
            ViewModelSection castSender = sender as ViewModelSection;
            if (castSender != null)
            {
                castSender.WantToClose -= GetResultFromSection;
            }
        }

        private DispatcherTimer _timer;

        private void RaiseTimer()
        {
            _timer = new DispatcherTimer(
                TimeSpan.FromMilliseconds(Interval),
                DispatcherPriority.Normal,
                new EventHandler((o, e) =>
                {
                    SaveProgressRate += SaveTime / Interval;

                    if (SaveProgressRate >= 100 && IsCanceled)
                    {
                        ((DispatcherTimer)o).Stop();
                        OnPropertyChanged("IsCanceled");
                        OnPropertyChanged("MeetingStatus");
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
    }
}
