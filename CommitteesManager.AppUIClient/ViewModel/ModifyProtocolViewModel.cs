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
    internal class ModifyProtocolViewModel : ViewModelSection
    {
        private Protocol _modifyProtocol;
        private bool _infoMode;
        public ModifyProtocolViewModel(IServiceProvider service, Protocol protocol, bool ForInfoOnly) : base(service)
        {
            _modifyProtocol = protocol;
            _infoMode = ForInfoOnly;
        }
        public override ViewModelSection Filter { get => null; set { } }

        #region Properties
        public bool IsReadOnly
        {
            get { return _infoMode; }
            set { _infoMode = value; OnPropertyChanged("IsReadOnly"); }
        }
        public int ProtocolID
        {
            get { return _modifyProtocol.ProtocolID; }
            set { _modifyProtocol.ProtocolID = value; OnPropertyChanged("ProtocolID"); }
        }
        #endregion
        #region Commands
        #endregion
    }
}
