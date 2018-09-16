using CommitteesManager.AppUIClient.Infrastructure;
using CommitteesManager.BLL.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class MainWindowViewModel: ViewModelBase
    {
        private IServiceProvider _serviceProvider;
        public MainWindowViewModel(IServiceProvider services)
        {
            _serviceProvider = services;
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
                        ViewModelSection newView = ViewModelBase.GetNewSection(raiseView, _serviceProvider);
                        newView.CreateView += AddSectionToPipe;
                        newView.WantToClose += CloseOpenedSection;
                        
                        //Clear all open section
                        CloseOpenedSection(this, new ViewModelEventArgs(JoinDirectionEnum.After, null));

                        if (newView.Filter != null)
                            OpenedViews.AddLast(newView.Filter);
                        OpenedViews.AddLast(newView);
                     });
                return _selectedMenu;
            }
        }

        private void CloseOpenedSection(object sender, ViewModelEventArgs e)
        {
            ViewModelSection callingObj = sender as ViewModelSection;

            //return if list of section is empty
            if (_openedViews.Count == 0)
                return;

            do
            {
                var lastNode = _openedViews.Last;
                _openedViews.RemoveLast();
                lastNode.Value.CreateView -= AddSectionToPipe;
                lastNode.Value.WantToClose -= CloseOpenedSection;

                //Delete filter if exists
                if (lastNode.Value.Filter != null)
                    _openedViews.Remove(lastNode.Value.Filter);

                if (lastNode.Value == callingObj)
                    break;
            } while (_openedViews.Count > 0);
        }

        private void AddSectionToPipe(object sender, ViewModelEventArgs e)
        {
            ViewModelSection newView = e.VMObject;
            newView.CreateView += AddSectionToPipe;
            newView.WantToClose += CloseOpenedSection;
            if (e.JoinType == JoinDirectionEnum.First)
            {
                _openedViews.AddFirst(newView);
            }
            else
            {
                _openedViews.AddLast(newView);
            }
        }
    }
}
