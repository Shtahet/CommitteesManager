using CommitteesManager.AppUIClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class ProtocolsViewModel: ViewModelSection
    {
        public ProtocolsViewModel(IServiceProvider inServiceProvider):base(inServiceProvider)
        {
            _filter = ViewModelBase.GetNewSection(ViewModels.Filter, inServiceProvider) as FilterViewModel;
        }

        private FilterViewModel _filter;
        public override ViewModelSection Filter { get => _filter; set => _filter = value as FilterViewModel; }
    }
}
