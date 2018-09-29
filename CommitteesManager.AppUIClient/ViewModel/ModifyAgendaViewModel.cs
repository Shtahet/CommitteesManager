using CommitteesManager.AppUIClient.Infrastructure;
using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;

namespace CommitteesManager.AppUIClient.ViewModel
{
    internal class ModifyAgendaViewModel : ViewModelSection
    {
        private Agenda _modifyAgenda;
        private bool _infoMode;
        public ModifyAgendaViewModel(IServiceProvider service, Agenda agenda, bool forInfoOnly) : base(service)
        {
            _modifyAgenda = agenda;
            _infoMode = forInfoOnly;
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
        #endregion
        #region Collection
        #endregion
        #region Command
        #endregion
    }
}
