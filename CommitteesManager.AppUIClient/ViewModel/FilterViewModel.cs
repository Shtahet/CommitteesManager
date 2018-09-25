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

        #region Committe filter implementation
        #region Properties
        public bool FilteredCommitteState
        {
            get
            {
                return _filteredCommittee.Count > 0;
            }
        }
        private bool _showCommitteBtnState = true;
        public bool ShowAllCommitteBtnState {
            get
            {
                return _showCommitteBtnState;
            }
            set
            {
                _showCommitteBtnState = value;
                OnPropertyChanged("ShowAllCommitteBtnState");
            }
        }
        private string _searchCommitteeMask;
        public string SearchCommitteeMask
        {
            get
            {
                return _searchCommitteeMask ?? string.Empty;
            }
            set
            {
                var committeeViewCollection = CollectionViewSource.GetDefaultView(_committees);
                committeeViewCollection.Filter = (x) => { return ((Committee)x).Committee_name_UA.ToLower().Contains(value.ToLower()); };
                _searchCommitteeMask = value;
                OnPropertyChanged("SearchCommitteeMask");
            }
        }
        #endregion
        #region Collection
        private ObservableCollection<Committee> _committees;
        public ObservableCollection<Committee> Committees
        {
            get
            {
                if (_committees == null)
                {
                    _committees = new ObservableCollection<Committee>(_services.CommitteeService.GetAll().Take(5));
                }
                return _committees;
            }
            set
            {
                _committees = value;
                OnPropertyChanged("Committees");
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
        #endregion
        #region Commands
        private RelayCommand _searchAllCommitteeItems;
        public RelayCommand ShowAllCommittees
        {
            get
            {
                if (_searchAllCommitteeItems == null)
                {
                    _searchAllCommitteeItems = new RelayCommand(obj =>
                    {
                        List<Committee> allCommittee = _services.CommitteeService.GetAll().ToList();
                        //Revome filtered committe
                        if (_filteredCommittee != null)
                        {
                            for(int i = 0; i< _filteredCommittee.Count; ++i)
                            {
                                allCommittee.Remove(_filteredCommittee[i]);
                            }
                        }
                        _committees = new ObservableCollection<Committee>(allCommittee);
                        var committeeViewCollection = CollectionViewSource.GetDefaultView(_committees);
                        committeeViewCollection.Filter = (x) => { return ((Committee)x).Committee_name_UA.ToLower().Contains(SearchCommitteeMask.ToLower()); };
                        ShowAllCommitteBtnState = false;
                        OnPropertyChanged("Committees");
                    });
                }
                return _searchAllCommitteeItems;
            }
        }
        private RelayCommand _selectedCom;
        public RelayCommand SelectCommittee
        {
            get
            {
                if (_selectedCom == null)
                {
                    _selectedCom = new RelayCommand(obj =>
                    {
                        var selCommittee = obj as Committee;
                        if (selCommittee == null)
                        {
                            Thread.Sleep(250);
                            return;
                        }
                        _committees.Remove(selCommittee);
                        _filteredCommittee.Add(selCommittee);
                        OnPropertyChanged("FilteredCommitteState");
                    });
                }
                return _selectedCom;
            }
        }
        private RelayCommand _unselectCom;
        public RelayCommand UnselectCommittee
        {
            get
            {
                if (_unselectCom == null)
                {
                    _unselectCom = new RelayCommand(obj =>
                    {
                        var unselCommittee = obj as Committee;
                        if (unselCommittee == null)
                            return;

                        _committees.Add(unselCommittee);
                        _filteredCommittee.Remove(unselCommittee);

                        OnPropertyChanged("FilteredCommitteState");
                    });
                }
                return _unselectCom;
            }
        }
        #endregion
        #endregion
        #region CommitteMode filter implementation
        #region Properties
        public bool FilteredCommitteModeState
        {
            get
            {
                return _filteredCommitteeModes.Count > 0;
            }
        }
        private bool _showCommitteeModeBtnState = true;
        public bool ShowAllCommitteModeBtnState
        {
            get
            {
                return _showCommitteeModeBtnState;
            }
            set
            {
                _showCommitteeModeBtnState = value;
                OnPropertyChanged("ShowAllCommitteModeBtnState");
            }
        }
        private string _searchCommitteeModeMask;
        public string SearchCommitteModeMask
        {
            get
            {
                return _searchCommitteeModeMask ?? string.Empty;
            }
            set
            {
                var committeeModeViewCollection = CollectionViewSource.GetDefaultView(_committeeModes);
                committeeModeViewCollection.Filter = (x) => { return ((Mode)x).Mode_name_UA.ToLower().Contains(value.ToLower()); };
                _searchCommitteeModeMask = value;
                OnPropertyChanged("SearchCommitteModeMask");
            }
        }
        #endregion
        #region Collection
        private ObservableCollection<Mode> _committeeModes;
        public ObservableCollection<Mode> CommitteeModes
        {
            get
            {
                if (_committeeModes == null)
                {
                    _committeeModes = new ObservableCollection<Mode>(_services.CommitteeModeService.GetAll().Take(5));
                }
                return _committeeModes;
            }
            set
            {
                _committeeModes = value;
                OnPropertyChanged("CommitteeModes");
            }
        }
        private ObservableCollection<Mode> _filteredCommitteeModes = new ObservableCollection<Mode>();
        public ObservableCollection<Mode> FilteredCommitteeModes
        {
            get
            {
                return _filteredCommitteeModes;
            }
        }
        #endregion
        #region Commands
        private RelayCommand _searchAllCommitteeModeItems;
        public RelayCommand ShowAllCommitteeModes
        {
            get
            {
                if (_searchAllCommitteeModeItems == null)
                {
                    _searchAllCommitteeModeItems = new RelayCommand(obj =>
                    {
                        List<Mode> allCommitteMode = _services.CommitteeModeService.GetAll().ToList();

                        if (_filteredCommitteeModes != null)
                        {
                            for(int i = 0; i<_filteredCommitteeModes.Count; ++i)
                            {
                                allCommitteMode.Remove(_filteredCommitteeModes[i]);
                            }
                        }
                        CommitteeModes = new ObservableCollection<Mode>(allCommitteMode);
                        var committeModeViewCollection = CollectionViewSource.GetDefaultView(CommitteeModes);
                        committeModeViewCollection.Filter = (x) => { return ((Mode)x).Mode_name_UA.ToLower().Contains(SearchCommitteModeMask.ToLower()); };
                        ShowAllCommitteModeBtnState = false;
                    });
                }
                return _searchAllCommitteeModeItems;
            }
        }
        private RelayCommand _selectedComMode;
        public RelayCommand SelectCommitteeMode
        {
            get
            {
                if (_selectedComMode == null)
                {
                    _selectedComMode = new RelayCommand(obj =>
                    {
                        var selCommitteMode = obj as Mode;
                        if (selCommitteMode == null)
                        {
                            Thread.Sleep(250);
                            return;
                        }
                        _committeeModes.Remove(selCommitteMode);
                        _filteredCommitteeModes.Add(selCommitteMode);
                        OnPropertyChanged("FilteredCommitteModeState");
                    });
                }
                return _selectedComMode;
            }
        }
        private RelayCommand _unselectComMode;
        public RelayCommand UnselectCommitteMode
        {
            get
            {
                if (_unselectComMode == null)
                {
                    _unselectComMode = new RelayCommand(obj =>
                    {
                        var unselCommitteeMode = obj as Mode;
                        if (unselCommitteeMode == null)
                            return;

                        _committeeModes.Add(unselCommitteeMode);
                        _filteredCommitteeModes.Remove(unselCommitteeMode);

                        OnPropertyChanged("FilteredCommitteModeState");
                    });
                }
                return _unselectComMode;
            }
        }
        #endregion
        #endregion
        #region From/To Dates filter implementation
        private DateTime? _fromDate;
        public DateTime? FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                _fromDate = value;
                OnPropertyChanged("FromDate");
            }
        }
        private DateTime? _toDate;
        public DateTime? ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                _toDate = value;
                OnPropertyChanged("ToDate");
            }
        }
        #endregion
    }
}       