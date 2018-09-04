using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommittessManager.BLL.Abstract
{
    interface IServiceProvider
    {
        public IScheduleService ScheduleService{ get; }
    }
}
