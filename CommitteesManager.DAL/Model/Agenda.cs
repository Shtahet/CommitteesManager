namespace CommitteesManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Agendas")]
    public partial class Agenda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agenda()
        {
            Covenants = new HashSet<Covenant>();
            Deals = new HashSet<Deal>();
        }

        [Column(TypeName = "numeric")]
        public decimal AgendaID { get; set; }

        public int ProtocolID { get; set; }

        public int? RegionID { get; set; }

        [StringLength(255)]
        public string Contractor_Name { get; set; }

        [StringLength(255)]
        public string Contract_number { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Contract_date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Deal_amount { get; set; }

        [StringLength(20)]
        public string Tax_code { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Potential_amount_UAH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Potential_amount_CCY { get; set; }

        [StringLength(5)]
        public string Currency { get; set; }

        [StringLength(50)]
        public string Fraud { get; set; }

        [StringLength(300)]
        public string Comments { get; set; }

        [StringLength(50)]
        public string Contact_info { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Contract_id { get; set; }

        public int? Covenant_Y_N { get; set; }

        public DateTime Add_date { get; set; }

        public int? CounterpartID { get; set; }

        public int Ban_departure { get; set; }

        public virtual Protocol Protocol { get; set; }

        public virtual Region Region { get; set; }

        public virtual Counterparty Counterparty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Covenant> Covenants { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deals { get; set; }
    }
}
