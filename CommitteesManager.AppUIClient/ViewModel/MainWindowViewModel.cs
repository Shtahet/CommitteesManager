using CommitteesManager.AppUIClient.Infrastructure;
using System.Collections.ObjectModel;
using System.Windows;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class MainWindowViewModel: ViewModelBase
    {
        public MainWindowViewModel()
        {
            _openedViews = new ObservableCollection<string>()
            {
                "FirstWindow", "Second Window", "third window"
            };
        }

        private ObservableCollection<string> _openedViews;
        public ObservableCollection<string> OpenedViews
        {
            get { return _openedViews; }
            set { _openedViews = value; }
        }

        private RelayCommand _selectedMenu;
        public RelayCommand SelectMenu
        {
            get
            {
                if (_selectedMenu == null)
                    _selectedMenu = new RelayCommand(obj => MessageBox.Show("Test command"));
                return _selectedMenu;
            }
        }
    }
}
