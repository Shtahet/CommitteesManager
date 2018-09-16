using CommitteesManager.AppUIClient.ViewModel;
using CommitteesManager.BLL.Abstract;
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
        Filter,
        CreateMeeting
    }
    
    class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ViewModelSection GetNewSection(ViewModels viewType, IServiceProvider _service)
        {
            ViewModelSection retView = null;

            switch (viewType)
            {
                case ViewModels.PlaneMeeting:
                    retView = new PlaneMeetingViewModel(_service);
                    retView.Name = "Інформація про засідання";
                    break;
                case ViewModels.Issues:
                    retView = new IssuesViewModel(_service);
                    retView.Name = "Огляд заявок";
                    break;
                case ViewModels.ReqistryOfDecisions:
                    retView = new RegistryViewModel(_service);
                    retView.Name = "Реєстр рішень";
                    break;
                case ViewModels.Protocols:
                    retView = new ProtocolsViewModel(_service);
                    retView.Name = "Перелік протоколів";
                    break;
                case ViewModels.Filter:
                    retView = new FilterViewModel(_service);
                    retView.Name = "Фільтр";
                    break;
                case ViewModels.CreateMeeting:
                    retView = new CreateMeetingViewModel(_service);
                    retView.Name = "Планування нового засідання";
                    break;
                default:
                    break;
            }

            return retView;
        }
    }
}
