using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommitteesManager.BLL.Model
{
    public class RegistryRecord
    {
        public string Protocol_number { get; set; }
        public DateTime Protocol_date { get; set; }
        public DateTime? EXPIRIOD_DATE_DECISION { get; set; }
        public string User_name_UA { get; set; }
        public string Mode_name_UA { get; set; }
        public string Committee_name_UA { get; set; }
        public string Committe_status { get; set; }
        public string Region_name_UA { get; set; }
        public string Contractor_Name { get; set; }
        public string Contract_number { get; set; }
        public string Deal_name_UA { get; set; }
        public string Deal_status { get; set; }
        public string Reason_name_UA { get; set; }
    }
}
