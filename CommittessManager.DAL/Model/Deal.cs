namespace CommittessManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Deals")]
    public partial class Deal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DealID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal AgendaID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Deal_typeID { get; set; }

        public int? Agreed_deal_typeID { get; set; }

        public int? DecisionID { get; set; }

        public int? ReasonID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Deal_date { get; set; }

        public int? Deal_statusID { get; set; }

        public DateTime? Status_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Next_date_committee { get; set; }

        [StringLength(50)]
        public string Revision_status { get; set; }

        [StringLength(500)]
        public string Revision_comment { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Revision_date { get; set; }

        public virtual Agenda Agenda { get; set; }

        public virtual DealType DealType { get; set; }

        public virtual DealType DealType1 { get; set; }

        public virtual Reason Reason { get; set; }

        public virtual Status Status { get; set; }

        public virtual Status Status1 { get; set; }
    }
}
