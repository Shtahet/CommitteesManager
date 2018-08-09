using CommitteesManager.AppUIClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class RegistryViewModel: ViewModelSection
    {
        public RegistryViewModel()
        {
            _filter = ViewModelBase.GetNewSection(ViewModels.Filter) as FilterViewModel;
        }

        private FilterViewModel _filter;
        public override ViewModelSection Filter { get => _filter; set => _filter = value as FilterViewModel; }
    }
}
