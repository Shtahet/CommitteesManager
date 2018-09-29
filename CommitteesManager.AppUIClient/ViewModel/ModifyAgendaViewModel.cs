using CommitteesManager.AppUIClient.Infrastructure;
using CommitteesManager.DAL.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;

namespace CommitteesManager.AppUIClient.ViewModel
{
    internal class ModifyAgendaViewModel : ViewModelSection
    {
        private Agenda _modifyAgenda;
        private bool _infoMode;
        public ModifyAgendaViewModel(IServiceProvider service, Agenda agenda, bool forInfoOnly) : base(service)
        {
            _modifyAgenda = agenda;
            _infoMode = forInfoOnly;
        }
        public override ViewModelSection Filter { get => null; set { } }

        #region Properties
        public Agenda Agenda
        {
            get { return _modifyAgenda; }
        }
        public bool NeedToSave { get; set; } = false;
        public bool IsReadOnly
        {
            get { return _infoMode; }
            set { _infoMode = value; OnPropertyChanged("IsReadOnly"); }
        }
        public bool IsEnable
        {
            get { return !_infoMode; }
            set { }
        }
        public decimal AgendaID
        {
            get { return _modifyAgenda.AgendaID; }
            set { _modifyAgenda.AgendaID = value; OnPropertyChanged("AgendaID"); }
        }
        public Region SelectedRegion
        {
            get { return _modifyAgenda.Region; }
            set { _modifyAgenda.Region = value; OnPropertyChanged("SelectedRegion"); }
        }
        public string ContractorName
        {
            get { return _modifyAgenda.Contractor_Name; }
            set { _modifyAgenda.Contractor_Name = value; OnPropertyChanged("ContractorName"); }
        }
        public string ContractNumber
        {
            get { return _modifyAgenda.Contract_number; }
            set { _modifyAgenda.Contract_number = value; OnPropertyChanged("ContractNumber"); }
        }
        public DateTime? ContractDate
        {
            get { return _modifyAgenda.Contract_date; }
            set { _modifyAgenda.Contract_date = value; OnPropertyChanged("ContractDate"); }
        }
        public decimal? DealAmount
        {
            get { return _modifyAgenda.Deal_amount; }
            set { _modifyAgenda.Deal_amount = value; OnPropertyChanged("DealAmount"); }
        }
        public string TaxCode
        {
            get { return _modifyAgenda.Tax_code; }
            set { _modifyAgenda.Tax_code = value; OnPropertyChanged("TaxCode"); }
        }
        public decimal ContractId
        {
            get { return _modifyAgenda.Contract_id; }
            set { _modifyAgenda.Contract_id = value; OnPropertyChanged("ContractId"); }
        }
        public string Comments
        {
            get { return _modifyAgenda.Comments; }
            set { _modifyAgenda.Comments = value; OnPropertyChanged("Comments"); }
        }
        #endregion
        #region Collection
        private ObservableCollection<Region> _regions;
        public ObservableCollection<Region> RegionsList
        {
            get
            {
                if (_regions == null)
                {
                    _regions = new ObservableCollection<Region>(_services.RegionService.GetActualAll());
                }
                return _regions;
            }
        }
        #endregion
        #region Command
        private RelayCommand _saveAndClose;
        public RelayCommand SaveAndClose
        {
            get
            {
                if (_saveAndClose == null)
                {
                    _saveAndClose = new RelayCommand(obj =>
                    {
                        NeedToSave = true;
                        this.Close.Execute(null);
                    });
                }
                return _saveAndClose;
            }
        }
        #endregion
    }
}
