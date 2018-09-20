using System;

namespace CommitteesManager.BLL.Abstract
{
    public enum ScheduleStatus
    {
        Undefine = 0,
        Preparing = 1,
        Scheduled = 2,
        InSession = 3,
        Completed = 4,
        Canceled = 5
    }
    public interface IScheduleService
    {
        DateTime? AdmissionStartDate { get; set; }
        DateTime? AdmissionStopDate { get; set; }
        DateTime? CommitteeDate { get; set; }
        DateTime? LastCommitteeDate { get; set; }
        ScheduleStatus Status { get; set; }
        bool OpenSchedule();
        bool CloseSchedule();
        bool DismissSchedule();
        bool SaveChange();
    }
}