namespace CommitteesManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Reasons")]
    public partial class Reason
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reason()
        {
            Deals = new HashSet<Deal>();
        }

        public int ReasonID { get; set; }

        [Required]
        [StringLength(200)]
        public string Reason_name_UA { get; set; }

        [StringLength(200)]
        public string Reason_name_US { get; set; }

        public bool Is_available { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deals { get; set; }
    }
}
