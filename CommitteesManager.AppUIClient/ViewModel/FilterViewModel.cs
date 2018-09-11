using CommitteesManager.AppUIClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class FilterViewModel:ViewModelSection
    {
        public FilterViewModel(IServiceProvider inServiceProvider):base(inServiceProvider)
        {
            _closeCmd = new RelayCommand(obj => { }, obj => false);
        }

        public override ViewModelSection Filter { get => null; set { } }
    }
}
