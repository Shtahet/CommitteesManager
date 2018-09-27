using CommitteesManager.AppUIClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;
using CommitteesManager.BLL.Model;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class RegistryViewModel: ViewModelSection
    {
        public RegistryViewModel(IServiceProvider inServiceProvider):base(inServiceProvider)
        {
            _filter = ViewModelBase.GetNewSection(ViewModels.Filter, inServiceProvider) as FilterViewModel;
            _filter.ApplyFilter += _filter_ApplyFilter;
        }

        private void _filter_ApplyFilter(object sender, EventArgs e)
        {
            var repQuery = _services.ReportService.GetRegistryQuery().AsEnumerable();
            if (_filter.FilteredCommitte.Count > 0)
            {
                repQuery = repQuery.Where(r => _filter.FilteredCommitte.Any(fc => r.Committee_name_UA == fc.Committee_name_UA));
            }
            if (_filter.FilteredCommitteeModes.Count > 0)
            {
                repQuery = repQuery.Where(r => _filter.FilteredCommitteeModes.Any(fcm => r.Mode_name_UA == fcm.Mode_name_UA));
            }
            if (_filter.FromDate.HasValue)
            {
                repQuery = repQuery.Where(r => r.Protocol_date >= _filter.FromDate.Value);
            }
            if (_filter.ToDate.HasValue)
            {
                repQuery = repQuery.Where(r => r.Protocol_date <= _filter.FromDate.Value);
            }
            if (_filter.FilteredQuestionTypes.Count > 0)
            {
                repQuery = repQuery.Where(r => _filter.FilteredQuestionTypes.Any(fqt => r.Question_type_UA == fqt));
            }
            if (_filter.FilteredDealTypes.Count > 0)
            {
                repQuery = repQuery.Where(r => _filter.FilteredDealTypes.Any(fdt => r.Deal_name_UA == fdt.Deal_name_UA));
            }
            
            RegistryStatistic = new ObservableCollection<RegistryRecord>(repQuery);
        }

        private FilterViewModel _filter;
        public override ViewModelSection Filter { get => _filter; set => _filter = value as FilterViewModel; }

        private ObservableCollection<RegistryRecord> _reportCollection;
        public ObservableCollection<RegistryRecord> RegistryStatistic
        {
            get
            {
                if (_reportCollection == null)
                {
                    _reportCollection = new ObservableCollection<RegistryRecord>(_services.ReportService.GetRegistryQuery().AsEnumerable());
                }
                return _reportCollection;
            }
            set
            {
                _reportCollection = value;
                OnPropertyChanged("RegistryStatistic");
            }
        }
    }
}
