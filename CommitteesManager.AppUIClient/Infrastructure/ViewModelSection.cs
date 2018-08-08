using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.AppUIClient.Infrastructure
{
    class ViewModelSection: ViewModelBase
    {
        public string Name { get; set; }
        public bool IsExpanded { get; set; } = true;

        public event EventHandler<ViewModelEventArgs> CreateView;
        public event EventHandler<ViewModelEventArgs> WantToClose;

        protected RelayCommand _expandCmd;
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

        protected RelayCommand _closeCmd;
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
    }
}
