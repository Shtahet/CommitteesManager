namespace CommittessManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Protocols")]
    public partial class Protocol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Protocol()
        {
            Agendas = new HashSet<Agenda>();
            Protocols1 = new HashSet<Protocol>();
            RegisterOfApproveds = new HashSet<RegisterOfApproved>();
        }

        public int ProtocolID { get; set; }

        [Required]
        [StringLength(20)]
        public string ResponsibleID { get; set; }

        [StringLength(20)]
        public string ReporterID { get; set; }

        public string Decision_text { get; set; }

        public int Protocol_mode { get; set; }

        public int? Protocol_longation { get; set; }

        public int? ProtocolID_longation { get; set; }

        [StringLength(50)]
        public string Protocol_number { get; set; }

        [Column(TypeName = "date")]
        public DateTime Protocol_date { get; set; }

        public int CommitteeID { get; set; }

        public int? StatusID { get; set; }

        public int? RegisterID { get; set; }

        public DateTime Add_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EXPIRIOD_DATE_DECISION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agenda> Agendas { get; set; }

        public virtual Committee Committee { get; set; }

        public virtual Mode Mode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Protocol> Protocols1 { get; set; }

        public virtual Protocol Protocol1 { get; set; }

        public virtual RegisterOfApproved RegisterOfApproved { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegisterOfApproved> RegisterOfApproveds { get; set; }
    }
}
