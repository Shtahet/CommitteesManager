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
        Protocols,
        Filter
    }
    
    class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ViewModelSection GetNewSection(ViewModels viewType)
        {
            ViewModelSection retView = null;

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
                case ViewModels.Filter:
                    retView = new FilterViewModel();
                    retView.Name = "Фільтр";
                    break;
                default:
                    break;
            }

            return retView;
        }
    }
}
