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
        private Protocol _selectedProtocol;
        public Protocol SelectedProtocol
        {
            get {
                return _selectedProtocol;
            }
            set {
                _selectedProtocol = value;
                OnPropertyChanged("SelectedProtocol");
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

        private RelayCommand _showProtocolInfo;
        public RelayCommand ShowProtocolInfo
        {
            get
            {
                if (_showProtocolInfo == null)
                {
                    _showProtocolInfo = new RelayCommand( obj =>
                    {
                        var protocol = obj as Protocol;
                        if (protocol == null)
                            return;
                        SelectedProtocol = protocol;
                        ModifyProtocolViewModel protocolVM = new ModifyProtocolViewModel(_services, protocol, true);
                        protocolVM.Name = "Інформація про протокол";
                        InvokeCreateViewEvent(this, new ViewModelEventArgs(JoinDirectionEnum.After, protocolVM));
                    });
                }
                return _showProtocolInfo;
            }
        }

        private RelayCommand _addNewProtocol;
        public RelayCommand AddNewProtocol
        {
            get
            {
                if (_addNewProtocol == null)
                {
                    _addNewProtocol = new RelayCommand(obj =>
                    {
                        Protocol newProtocol = new Protocol()
                        {
                            Protocol_date = DateTime.Now.Date,
                            Add_date = DateTime.Now
                        };
                        ModifyProtocolViewModel protocolVM = new ModifyProtocolViewModel(_services, newProtocol, false);
                        protocolVM.Name = "Інформація про протокол";
                        InvokeCreateViewEvent(this, new ViewModelEventArgs(JoinDirectionEnum.After, protocolVM));
                    });
                }
                return _addNewProtocol;
            }
        }
    }
}
