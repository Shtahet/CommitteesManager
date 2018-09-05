namespace CommitteesManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Committees")]
    public partial class Committee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Committee()
        {
            Protocols = new HashSet<Protocol>();
        }

        public int CommitteeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Committee_name_UA { get; set; }

        [Required]
        [StringLength(50)]
        public string Committee_name_US { get; set; }

        public bool Is_available { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Protocol> Protocols { get; set; }
    }
}
