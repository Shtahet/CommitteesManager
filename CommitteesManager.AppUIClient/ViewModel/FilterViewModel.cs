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
using System.Windows.Threading;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class FilterViewModel : ViewModelSection
    {
        private const double Interval = 50;         //Milliseconds
        private const int SaveTime = 3000;          //Milliseconds
        public FilterViewModel(IServiceProvider inServiceProvider) : base(inServiceProvider)
        {
            _closeCmd = new RelayCommand(obj => { }, obj => false);
        }
        public override ViewModelSection Filter { get => null; set { } }
        public event EventHandler ApplyFilter;

        private bool _filterApplyResult;
        public bool IsFilterApply { get { return _filterApplyResult; } private set { _filterApplyResult = value; OnPropertyChanged("IsFilterApply"); } }
        private double _saveProgress;
        public double SaveProgressRate
        {
            get { return _saveProgress; }
            private set
            {
                _saveProgress = value;
                OnPropertyChanged("SaveProgressRate");
            }
        }
        private RelayCommand _applyFilterCmd;
        public RelayCommand ApplyFilterCommand
        {
            get
            {
                if (_applyFilterCmd == null)
                {
                    _applyFilterCmd = new RelayCommand(async(obj)=>
                    {
                        RaiseTimer();
                        ApplyFilter?.Invoke(this, new EventArgs());
                        IsFilterApply = true;
                    });
                }
                return _applyFilterCmd;
            }
        }

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
                            for (int i = 0; i < _filteredCommittee.Count; ++i)
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
                            for (int i = 0; i < _filteredCommitteeModes.Count; ++i)
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
        #region Question type filter implementation
        #region Porperties
        public bool FilteredQuestionTypeState
        {
            get
            {
                return _filteredQuestionTypes.Count > 0;
            }
        }
        private bool _showQuestionBtnState = true;
        public bool ShowAllQuestionBtnState
        {
            get
            {
                return _showQuestionBtnState;
            }
            set
            {
                _showQuestionBtnState = value;
                OnPropertyChanged("ShowAllQuestionBtnState");
            }
        }
        private string _searchQuestionTypeMask;
        public string SearchQuestionTypeMask
        {
            get
            {
                return _searchQuestionTypeMask ?? string.Empty;
            }
            set
            {
                var questionTypeViewCollection = CollectionViewSource.GetDefaultView(_questionTypes);
                questionTypeViewCollection.Filter = (x) => { return ((string)x).ToLower().Contains(value.ToLower()); };
                _searchQuestionTypeMask = value;
                OnPropertyChanged("SearchQuestionTypeMask");
            }
        }
        #endregion
        #region Collection
        private ObservableCollection<string> _questionTypes;
        public ObservableCollection<string> QuestionTypes
        {
            get
            {
                if (_questionTypes == null)
                {
                    _questionTypes = new ObservableCollection<string>(_services.DealTypeService.GetAll().GroupBy(dt => dt.Question_type_UA).Select(dt => dt.Key).Take(5));
                }
                return _questionTypes;
            }
            set
            {
                _questionTypes = value;
                OnPropertyChanged("QuestionTypes");
            }
        }
        private ObservableCollection<string> _filteredQuestionTypes = new ObservableCollection<string>();
        public ObservableCollection<string> FilteredQuestionTypes
        {
            get
            {
                return _filteredQuestionTypes;
            }
        }
        #endregion
        #region Commands
        private RelayCommand _searchAllQuestionTypes;
        public RelayCommand ShowAllQuestionTypes
        {
            get
            {
                if (_searchAllQuestionTypes == null)
                {
                    _searchAllQuestionTypes = new RelayCommand(obj =>
                    {
                        List<string> allQuestionType = _services.DealTypeService.GetAll().GroupBy(dt => dt.Question_type_UA).Select(dt => dt.Key).ToList();
                        if (_filteredQuestionTypes != null)
                        {
                            for(int i = 0; i < _filteredQuestionTypes.Count; ++i)
                            {
                                allQuestionType.Remove(_filteredQuestionTypes[i]);
                            }
                        }
                        QuestionTypes = new ObservableCollection<string>(allQuestionType);
                        var questionTypeViewCollection = CollectionViewSource.GetDefaultView(QuestionTypes);
                        questionTypeViewCollection.Filter = (x) => { return ((string)x).ToLower().Contains(SearchQuestionTypeMask.ToLower()); };
                        ShowAllQuestionBtnState = false;
                    });
                }
                return _searchAllQuestionTypes;
            }
        }
        private RelayCommand _selectedQuestionType;
        public RelayCommand SelectQuestionType
        {
            get
            {
                if (_selectedQuestionType == null)
                {
                    _selectedQuestionType = new RelayCommand(obj =>
                    {
                        var selQuestionType = obj as string;
                        if (selQuestionType == null)
                        {
                            Thread.Sleep(250);
                            return;
                        }
                        _questionTypes.Remove(selQuestionType);
                        _filteredQuestionTypes.Add(selQuestionType);
                        OnPropertyChanged("FilteredQuestionTypeState");
                    });
                }
                return _selectedQuestionType;
            }
        }
        private RelayCommand _unselectQuestionType;
        public RelayCommand UnselectQuestionType
        {
            get
            {
                if (_unselectQuestionType == null)
                {
                    _unselectQuestionType = new RelayCommand(obj =>
                    {
                        var unselQuestionType = obj as string;
                        if (unselQuestionType == null)
                            return;

                        _questionTypes.Add(unselQuestionType);
                        _filteredQuestionTypes.Remove(unselQuestionType);
                        OnPropertyChanged("FilteredQuestionTypeState");
                    });
                }
                return _unselectQuestionType;
            }
        }
        #endregion
        #endregion
        #region Deal type filter implementation
        #region Porperties
        public bool FilteredDealTypeState
        {
            get
            {
                return _filteredDealTypes.Count > 0;
            }
        }
        private bool _showDealTypeBtnState = true;
        public bool ShowAllDealTypeBtnState
        {
            get
            {
                return _showDealTypeBtnState;
            }
            set
            {
                _showDealTypeBtnState = value;
                OnPropertyChanged("ShowAllDealTypeBtnState");
            }
        }
        private string _searchDealTypeMask;
        public string SearchDealTypeMask
        {
            get
            {
                return _searchDealTypeMask ?? string.Empty;
            }
            set
            {
                var dealTypeViewCollection = CollectionViewSource.GetDefaultView(_dealTypes);
                dealTypeViewCollection.Filter = (x) => { return ((DealType)x).Deal_name_UA.ToLower().Contains(value.ToLower()); };
                _searchDealTypeMask = value;
                OnPropertyChanged("SearchDealTypeMask");
            }
        }
        #endregion
        #region Collection
        private ObservableCollection<DealType> _dealTypes;
        public ObservableCollection<DealType> DealTypes
        {
            get
            {
                if (_dealTypes == null)
                {
                    _dealTypes = new ObservableCollection<DealType>(_services.DealTypeService.GetAll().Take(10));
                }
                return _dealTypes;
            }
            set
            {
                _dealTypes = value;
                OnPropertyChanged("DealTypes");
            }
        }
        private ObservableCollection<DealType> _filteredDealTypes = new ObservableCollection<DealType>();
        public ObservableCollection<DealType> FilteredDealTypes
        {
            get
            {
                return _filteredDealTypes;
            }
        }
        #endregion
        #region Commands
        private RelayCommand _searchAllDealTypes;
        public RelayCommand ShowAllDealTypes
        {
            get
            {
                if (_searchAllDealTypes == null)
                {
                    _searchAllDealTypes = new RelayCommand(obj =>
                    {
                        List<DealType> allDealType = _services.DealTypeService.GetAll().ToList();
                        if (_filteredDealTypes != null)
                        {
                            for (int i = 0; i < _filteredDealTypes.Count; ++i)
                            {
                                allDealType.Remove(_filteredDealTypes[i]);
                            }
                        }
                        DealTypes = new ObservableCollection<DealType>(allDealType);
                        var dealTypeViewCollection = CollectionViewSource.GetDefaultView(DealTypes);
                        dealTypeViewCollection.Filter = (x) => { return ((DealType)x).Deal_name_UA.ToLower().Contains(SearchDealTypeMask.ToLower()); };
                        ShowAllDealTypeBtnState = false;
                    });
                }
                return _searchAllDealTypes;
            }
        }
        private RelayCommand _selectedDealType;
        public RelayCommand SelectDealType
        {
            get
            {
                if (_selectedDealType == null)
                {
                    _selectedDealType = new RelayCommand(obj =>
                    {
                        var selDealType = obj as DealType;
                        if (selDealType == null)
                        {
                            Thread.Sleep(250);
                            return;
                        }
                        _dealTypes.Remove(selDealType);
                        _filteredDealTypes.Add(selDealType);
                        OnPropertyChanged("FilteredDealTypeState");
                    });
                }
                return _selectedDealType;
            }
        }
        private RelayCommand _unselectDealType;
        public RelayCommand UnselectDealType
        {
            get
            {
                if (_unselectDealType == null)
                {
                    _unselectDealType = new RelayCommand(obj =>
                    {
                        var unselDealType = obj as DealType;
                        if (unselDealType == null)
                            return;

                        _dealTypes.Add(unselDealType);
                        _filteredDealTypes.Remove(unselDealType);
                        OnPropertyChanged("FilteredDealTypeState");
                    });
                }
                return _unselectDealType;
            }
        }
        #endregion
        #endregion

        private DispatcherTimer _timer;
        private void RaiseTimer()
        {
            _timer = new DispatcherTimer(
                TimeSpan.FromMilliseconds(Interval),
                DispatcherPriority.Normal,
                new EventHandler((o, e) =>
                {
                    SaveProgressRate += 100/ (SaveTime / Interval);

                    if (IsFilterApply)
                    {
                        ((DispatcherTimer)o).Stop();
                        SaveProgressRate = 0;
                    }
                    if (SaveProgressRate >= 100)
                    {
                        SaveProgressRate = 0;
                    }
                }),
                Dispatcher.CurrentDispatcher);
            _timer.Start();
        }
    }
}       