using CommitteesManager.AppUIClient.Infrastructure;
using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;

namespace CommitteesManager.AppUIClient.ViewModel
{
    internal class ModifyProtocolViewModel : ViewModelSection
    {
        private Protocol _modifyProtocol;
        private bool _infoMode;
        public ModifyProtocolViewModel(IServiceProvider service, Protocol protocol, bool ForInfoOnly) : base(service)
        {
            _modifyProtocol = protocol;
            IsReadOnly = ForInfoOnly;
        }
        public override ViewModelSection Filter { get => null; set { } }

        #region Properties
        public bool IsReadOnly
        {
            get { return _infoMode; }
            set { _infoMode = value; OnPropertyChanged("IsReadOnly"); }
        }
        public bool IsEnable
        {
            get { return !_infoMode; }
            set { }
        }
        public int ProtocolID
        {
            get { return _modifyProtocol.ProtocolID; }
            set { _modifyProtocol.ProtocolID = value; OnPropertyChanged("ProtocolID"); }
        }
        public User SelectedResponsible
        {
            get { return _modifyProtocol.User1; }
            set { _modifyProtocol.User1 = value; OnPropertyChanged("SelectedResponsible"); }
        }
        public User SelectedReporter
        {
            get { return _modifyProtocol.User; }
            set { _modifyProtocol.User = value; OnPropertyChanged("SelectedResponsible"); }
        }
        public Mode SelectedMode
        {
            get { return _modifyProtocol.Mode; }
            set { _modifyProtocol.Mode = value; OnPropertyChanged("SelectedMode"); }
        }
        public string ProtocolNumber
        {
            get { return _modifyProtocol.Protocol_number; }
            set { _modifyProtocol.Protocol_number = value; OnPropertyChanged("ProtocolNumber"); }
        }
        public Committee SelectedCommittee
        {
            get { return _modifyProtocol.Committee; }
            set { _modifyProtocol.Committee = value; OnPropertyChanged("SelectedCommittee"); }
        }
        public DateTime? ProtocolDate
        {
            get { return _modifyProtocol.Protocol_date; }
            set { _modifyProtocol.Protocol_date = value.Value; OnPropertyChanged("ProtocolDate"); }
        }
        public DateTime? ExpiriodDate
        {
            get { return _modifyProtocol.EXPIRIOD_DATE_DECISION; }
            set { _modifyProtocol.EXPIRIOD_DATE_DECISION = value; OnPropertyChanged("ExpiriodDate"); }
        }
        public string DecisionText
        {
            get { return _modifyProtocol.Decision_text; }
            set { _modifyProtocol.Decision_text = value; OnPropertyChanged("DecisionText"); }
        }
        #endregion
        #region Collection
        private ObservableCollection<User> _usersList;
        public ObservableCollection<User> UsersList
        {
            get
            {
                if (_usersList == null)
                {
                    _usersList = new ObservableCollection<User>(_services.UserService.GetActualAll());
                }
                return _usersList;
            }
        }
        private ObservableCollection<Mode> _modeList;
        public ObservableCollection<Mode> ModesList
        {
            get
            {
                if (_modeList == null)
                {
                    _modeList = new ObservableCollection<Mode>(_services.CommitteeModeService.GetActualAll());
                }
                return _modeList;
            }
        }
        private ObservableCollection<Committee> _committeList;
        public ObservableCollection<Committee> CommitteeList
        {
            get
            {
                if (_committeList == null)
                {
                    _committeList = new ObservableCollection<Committee>(_services.CommitteeService.GetActualAll());
                }
                return _committeList;
            }
        }
        #endregion
        #region Commands
        private RelayCommand _saveProtocol;
        public RelayCommand SaveProtocol
        {
            get
            {
                if (_saveProtocol == null)
                {
                    _saveProtocol = new RelayCommand(obj =>
                    {
                        _services.ProtocolService.AddOrUpdate(_modifyProtocol);
                    });
                }
                return _saveProtocol;
            }
        }
        private RelayCommand _showLinkedAgendas;
        public RelayCommand ShowLinkedAgendas
        {
            get
            {
                if (_showLinkedAgendas == null)
                {
                    _showLinkedAgendas = new RelayCommand(obj =>
                    {
                        AgendasViewModel agendaslVM = new AgendasViewModel(_services, _modifyProtocol, _infoMode);
                        agendaslVM.Name = "Інформація по договорам";
                        InvokeCreateViewEvent(this, new ViewModelEventArgs(JoinDirectionEnum.After, agendaslVM));
                    });
                }
                return _showLinkedAgendas;
            }
        }
        #endregion
    }
}
