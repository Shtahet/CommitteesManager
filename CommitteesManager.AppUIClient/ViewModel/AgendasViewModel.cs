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
    internal class AgendasViewModel : ViewModelSection
    {
        private Protocol _currentProtocol;
        private bool _infoMode;
        public AgendasViewModel(IServiceProvider incomingService, Protocol protocol, bool ForInfoOnly) : base(incomingService)
        {
            _currentProtocol = protocol;
            _infoMode = ForInfoOnly;
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
        private Agenda _selectedAgenda;
        public Agenda SelectedAgenda
        {
            get { return _selectedAgenda; }
            set { _selectedAgenda = value; OnPropertyChanged("SelectedAgenda"); }
        }
        #endregion
        #region Collection
        private ObservableCollection<Agenda> _linkedAgendas;
        public ObservableCollection<Agenda> LinkedAgendas
        {
            get
            {
                if (_linkedAgendas == null)
                {
                    _linkedAgendas = new ObservableCollection<Agenda>(_currentProtocol.Agendas);
                }
                return _linkedAgendas;
            }
            set
            {
                _linkedAgendas = value;
                OnPropertyChanged("LinkedAgendas");
            }
        }
        #endregion
    }
}
