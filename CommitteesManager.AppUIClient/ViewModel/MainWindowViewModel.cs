using CommitteesManager.AppUIClient.Infrastructure;
using System.Collections.ObjectModel;
using System.Windows;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class MainWindowViewModel: ViewModelBase
    {
        public MainWindowViewModel()
        {
            _openedViews = new ObservableLinkedList<ViewModelBase>();
        }

        private ObservableLinkedList<ViewModelBase> _openedViews;
        public ObservableLinkedList<ViewModelBase> OpenedViews
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
                    _selectedMenu = new RelayCommand(obj =>
                    {
                        ViewModels raiseView = (ViewModels)obj;
                        MessageBox.Show($"Create view of {raiseView.ToString()}");

                     });
                return _selectedMenu;
            }
        }
    }
}
