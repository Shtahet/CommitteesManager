using CommitteesManager.AppUIClient.Infrastructure;
using System.Collections.ObjectModel;

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
        
    }
}
