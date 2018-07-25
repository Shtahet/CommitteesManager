namespace CommittessManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Environment")]
    public partial class Environment
    {
        [Key]
        public int EnvID { get; set; }

        [Required]
        [StringLength(50)]
        public string EnvName { get; set; }

        [Required]
        [StringLength(100)]
        public string EnvValue { get; set; }
    }
}
