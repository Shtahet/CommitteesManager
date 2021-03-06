﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Abstract
{
    public interface IServiceProvider
    {
        IScheduleService ScheduleService{ get; }
        ICommitteeService CommitteeService { get; }
        ICommitteModeService CommitteeModeService { get; }
        IDealTypeService DealTypeService { get; }
        IReportService ReportService { get; }
        IDealService DealService { get; }
        IProtocolService ProtocolService { get; }
        IAgendaService AgendaService { get; }
        IUserService UserService { get; }
        IRegionService RegionService { get; }
    }
}
