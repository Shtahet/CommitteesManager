using System;

namespace CommittessManager.BLL.Abstract
{
    public interface IScheduleService
    {
        DateTime StartDate { get; set; }
        DateTime FinishDate { get; set; }
        DateTime LastCommitteeDate { get; set; }
        bool OpenSchedule();
        bool CloseSchedule();
    }
}