using CommitteesManager.AppUIClient.Infrastructure;
using System.Collections.Generic;
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
                        ViewModelBase newView = ViewModelBase.GetViewModel(raiseView);
                        newView.CreateView += CreateViewLisener;
                        newView.WantToClose += WantToCloseLisener;
                        OpenedViews.AddLast(newView);
                     });
                return _selectedMenu;
            }
        }

        private void WantToCloseLisener(object sender, ViewModelEventArgs e)
        {
            ViewModelBase callingObj = sender as ViewModelBase;
            if (callingObj == null)
                return;

            do
            {
                var lastNode = _openedViews.Last;
                _openedViews.RemoveLast();
            } while (lastNode != null);
        }

        private void CreateViewLisener(object sender, ViewModelEventArgs e)
        {
            
        }
    }
}
