namespace CommitteesManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.DealTypes")]
    public partial class DealType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DealType()
        {
            Deals = new HashSet<Deal>();
            Deals1 = new HashSet<Deal>();
        }

        [Key]
        public int Deal_typeID { get; set; }

        [Required]
        [StringLength(200)]
        public string Deal_name_UA { get; set; }

        [StringLength(200)]
        public string Deal_name_US { get; set; }

        [Required]
        [StringLength(200)]
        public string Question_type_UA { get; set; }

        [Required]
        [StringLength(200)]
        public string Question_type_US { get; set; }

        [Required]
        [StringLength(50)]
        public string Deal_type { get; set; }

        public bool Is_available { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deals1 { get; set; }
    }
}
