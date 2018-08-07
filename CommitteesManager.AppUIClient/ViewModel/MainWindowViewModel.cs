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
            _openedViews = new ObservableLinkedList<ViewModelSection>();
        }

        private ObservableLinkedList<ViewModelSection> _openedViews;
        public ObservableLinkedList<ViewModelSection> OpenedViews
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
                        ViewModelSection newView = ViewModelBase.GetNewSection(raiseView);
                        newView.CreateView += CreateViewLisener;
                        newView.WantToClose += WantToCloseLisener;
                        OpenedViews.AddLast(newView);
                     });
                return _selectedMenu;
            }
        }

        private void WantToCloseLisener(object sender, ViewModelEventArgs e)
        {
            ViewModelSection callingObj = sender as ViewModelSection;
            if (callingObj == null)
                return;

            do
            {
                var lastNode = _openedViews.Last;
                _openedViews.RemoveLast();

                if (lastNode.Value == callingObj)
                    break;
            } while (_openedViews.Count > 0);
        }

        private void CreateViewLisener(object sender, ViewModelEventArgs e)
        {
            
        }
    }
}
