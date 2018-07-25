namespace CommittessManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Covenants")]
    public partial class Covenant
    {
        public int CovenantID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AgendaID { get; set; }

        [StringLength(50)]
        public string Covenant_object { get; set; }

        public int? Covenant_condition { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Covenant_expire { get; set; }

        [StringLength(50)]
        public string Covenant_expire_unit { get; set; }

        [StringLength(255)]
        public string Covenant_result { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Covenant_result_value { get; set; }

        public virtual Agenda Agenda { get; set; }
    }
}
