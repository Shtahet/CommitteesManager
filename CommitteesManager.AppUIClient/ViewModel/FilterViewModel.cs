using CommitteesManager.AppUIClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;
using CommitteesManager.DAL.Model;
using System.Windows.Controls;
using System.Windows.Data;
using System.Threading;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class FilterViewModel : ViewModelSection
    {
        public FilterViewModel(IServiceProvider inServiceProvider) : base(inServiceProvider)
        {
            _closeCmd = new RelayCommand(obj => { }, obj => false);
        }

        public override ViewModelSection Filter { get => null; set { } }

        private ObservableCollection<Committee> _committees;
        public ObservableCollection<Committee> Committees
        {
            get
            {
                if (_committees == null)
                {
                    _committees = new ObservableCollection<Committee>(_services.CommitteeService.GetAll().Take(5));
                    SelectedCommitteeIdx = -1;
                }
                return _committees;
            }
            set
            {
                _committees = value;
                OnPropertyChanged("Committees");
            }
        }
        private Committee _selectedCommittee;
        public Committee SelectedCommittee
        {
            get
            {
                return _selectedCommittee;
            }
            set
            {
                if (value != null)
                {
                    _filteredCommittee.Add(value);
                    _committees.Remove(value);
                    SelectedCommitteeIdx = -1;
                    Thread.Sleep(250);
                }
                OnPropertyChanged("SelectedCommittee");
            }
        }
        private int _selectedcommitteIdx;
        public int SelectedCommitteeIdx
        {
            get
            {
                return _selectedcommitteIdx;
            }
            set
            {
                _selectedcommitteIdx = value;
                OnPropertyChanged("SelectedCommitteeIdx");
            }
        }
        private string _serachCommitteeMask;
        public string SearchCommitteeMask
        {
            get
            {
                return _serachCommitteeMask ?? string.Empty;
            }
            set
            {
                var committeeViewCollection = CollectionViewSource.GetDefaultView(_committees);
                committeeViewCollection.Filter = (x) => { return ((Committee)x).Committee_name_UA.Contains(value); };
                _serachCommitteeMask = value;
                if (string.IsNullOrEmpty(_serachCommitteeMask))
                {
                    SearchCommitteState = false;
                }
                else
                {
                    SearchCommitteState = true;
                }
                OnPropertyChanged("SearchCommitteeMask");
            }
        }
        private bool _searchCommitteBtnState;
        public bool SearchCommitteState
        {
            get
            {
                return _searchCommitteBtnState;
            }
            set
            {
                _searchCommitteBtnState = value;
                OnPropertyChanged("SearchCommitteState");
            }
        }

        private RelayCommand _searchAllItems;
        public RelayCommand SearchAndAddCommittees
        {
            get
            {
                if (_searchAllItems == null)
                {
                    _searchAllItems = new RelayCommand(obj => 
                    {
                        var joinedCommittees = _services.CommitteeService.FindBy(com => com.Committee_name_UA.Contains(SearchCommitteeMask)).Union(_committees);
                        _committees = new ObservableCollection<Committee>(joinedCommittees);
                        SelectedCommitteeIdx = -1;
                        SearchCommitteState = false;
                        OnPropertyChanged("Committees");
                    });
                }
                return _searchAllItems;
            }
        }

        private ObservableCollection<Committee> _filteredCommittee = new ObservableCollection<Committee>();
        public ObservableCollection<Committee> FilteredCommitte
        {
            get
            {
                return _filteredCommittee;
            }
        }
    }
}       