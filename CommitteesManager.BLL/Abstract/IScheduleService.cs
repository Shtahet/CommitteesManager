using System;

namespace CommitteesManager.BLL.Abstract
{
    public enum ScheduleStatus
    {
        Completed = 0,
        Preparing = 1,
        Scheduled = 2,
        InSession = 3
    }
    public interface IScheduleService
    {
        DateTime AdmissionStartDate { get; set; }
        DateTime AdmissionStopDate { get; set; }
        DateTime CommitteeDate { get; set; }
        DateTime LastCommitteeDate { get; set; }
        ScheduleStatus Status { get; set; }
        bool OpenSchedule();
        bool CloseSchedule();
        bool DismissSchedule();
    }
}