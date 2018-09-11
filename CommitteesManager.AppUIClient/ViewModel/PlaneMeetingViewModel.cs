using CommitteesManager.AppUIClient.Infrastructure;
using CommitteesManager.BLL.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.AppUIClient.ViewModel
{
    class PlaneMeetingViewModel : ViewModelSection
    {
        public PlaneMeetingViewModel(IServiceProvider provider) : base(provider)
        {
        }
        public override ViewModelSection Filter { get => null; set { } }
    }
}
