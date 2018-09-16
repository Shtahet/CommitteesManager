using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.AppUIClient.Infrastructure;
using IServiceProvider = CommitteesManager.BLL.Abstract.IServiceProvider;

namespace CommitteesManager.AppUIClient.ViewModel
{
    internal class CreateMeetingViewModel : ViewModelSection
    {
        internal CreateMeetingViewModel(IServiceProvider IncomingServiceProvider) : base(IncomingServiceProvider)
        {
        }
        public override ViewModelSection Filter { get => null; set { } }
    }
}
