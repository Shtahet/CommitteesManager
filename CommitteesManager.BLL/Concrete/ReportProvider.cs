using CommitteesManager.BLL.Abstract;
using CommitteesManager.BLL.Model;
using CommitteesManager.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Concrete
{
    public class ReportProvider : IReportService
    {
        private IDataProvider _dataProvider;
        public ReportProvider(IDataProvider incomingDataProvider)
        {
            _dataProvider = incomingDataProvider;
        }
        public IQueryable<RegistryRecord> GetRegistryQuery()
        {
            return _dataProvider.Deals.GetAll()
                .Select(d => new RegistryRecord()
                {
                    Protocol_number = d.Agenda.Protocol.Protocol_number,
                    Protocol_date = d.Agenda.Protocol.Protocol_date,
                    EXPIRIOD_DATE_DECISION = d.Agenda.Protocol.EXPIRIOD_DATE_DECISION,
                    User_name_UA = d.Agenda.Protocol.User1.User_name_UA,
                    Mode_name_UA = d.Agenda.Protocol.Mode.Mode_name_UA,
                    Committee_name_UA = d.Agenda.Protocol.Committee.Committee_name_UA,
                    Committe_status = d.Agenda.Protocol.Status.Status_name_UA,
                    Region_name_UA = d.Agenda.Region.Region_name_UA,
                    Contractor_Name = d.Agenda.Contractor_Name,
                    Contract_number = d.Agenda.Contract_number,
                    Deal_name_UA = d.DealType.Deal_name_UA,
                    Question_type_UA = d.DealType.Question_type_UA,
                    Deal_status = d.Status.Status_name_UA,
                    Reason_name_UA = d.Reason.Reason_name_UA
                });
        }
    }
}
