using CommitteesManager.AppUIClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class FilterViewModel:ViewModelSection
    {
        public FilterViewModel()
        {
            _closeCmd = new RelayCommand(obj => { }, obj => false);
        }
    }
}
