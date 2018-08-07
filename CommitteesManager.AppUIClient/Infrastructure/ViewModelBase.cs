using CommitteesManager.AppUIClient.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.AppUIClient.Infrastructure
{
    public enum ViewModels
    {
        PlaneMeeting,
        Issues,
        ReqistryOfDecisions,
        Protocols
    }



    class ViewModelBase: INotifyPropertyChanged
    {
        public string Name { get; set; }
        public bool IsExpanded { get; set; } = true;

        public event EventHandler<ViewModelEventArgs> CreateView;
        public event EventHandler<ViewModelEventArgs> WantToClose;

        private RelayCommand _expandCmd;
        public RelayCommand Expand
        {
            get
            {
                if (_expandCmd == null)
                    _expandCmd = new RelayCommand(obj => 
                    {
                        IsExpanded = false;
                        OnPropertyChanged("IsExpanded");
                    });

                return _expandCmd;
            }
        }

        private RelayCommand _closeCmd;
        public RelayCommand Close
        {
            get
            {
                if (_closeCmd == null)
                    _closeCmd = new RelayCommand(obj => 
                    {
                        WantToClose?.Invoke(this, new ViewModelEventArgs(JoinDirectionEnum.After));
                    });

                return _closeCmd;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ViewModelBase GetViewModel(ViewModels viewType)
        {
            ViewModelBase retView = null;

            switch (viewType)
            {
                case ViewModels.PlaneMeeting:
                    retView = new PlaneMeetingViewModel();
                    retView.Name = "Планування засідання";
                    break;
                case ViewModels.Issues:
                    retView = new IssuesViewModel();
                    retView.Name = "Огляд заявок";
                    break;
                case ViewModels.ReqistryOfDecisions:
                    retView = new RegistryViewModel();
                    retView.Name = "Реєстр рішень";
                    break;
                case ViewModels.Protocols:
                    retView = new ProtocolsViewModel();
                    retView.Name = "Перелік протоколів";
                    break;
                default:
                    break;
            }

            return retView;
        }
    }
}
