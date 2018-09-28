using CommitteesManager.AppUIClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;
using CommitteesManager.DAL.Model;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class IssuesViewModel : ViewModelSection
    {
        public IssuesViewModel(IServiceProvider inServiceProvider):base(inServiceProvider)
        {
            ProtocolDate = DateTime.Today;
        }

        public override ViewModelSection Filter { get => null; set { } }

        private DateTime? _protocolDate;
        public DateTime? ProtocolDate
        {
            get
            {
                return _protocolDate;
            }
            set
            {
                _protocolDate = value;
                ShowedDeals = new ObservableCollection<Protocol>(_services.ProtocolService.FindBy(d => d.Protocol_date == value.Value));
                OnPropertyChanged("ProtocolDate");
            }
        }

        private ObservableCollection<Protocol> _showedDeals;
        public ObservableCollection<Protocol> ShowedDeals
        {
            get
            {
                return _showedDeals;
            }
            set
            {
                _showedDeals = value;
                OnPropertyChanged("ShowedDeals");
            }
        }
    }
}
