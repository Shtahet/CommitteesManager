using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommitteesManager.BLL.Abstract;
using CommitteesManager.DAL.Abstract;

namespace CommitteesManager.BLL.Concrete
{
    class ScheduleProvider: IScheduleService
    {
        private readonly IDataProvider _dataProvider;

        public ScheduleProvider(IDataProvider provider)
        {
            _dataProvider = provider;
        }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime LastCommitteeDate { get; set; }

        public bool CloseSchedule()
        {
            throw new NotImplementedException();
        }

        public bool OpenSchedule()
        {
            throw new NotImplementedException();
        }
    }
}
