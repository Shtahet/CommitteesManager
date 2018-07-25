namespace CommittessManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Modes")]
    public partial class Mode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mode()
        {
            Protocols = new HashSet<Protocol>();
        }

        public int ModeID { get; set; }

        [Required]
        [StringLength(100)]
        public string Mode_name_UA { get; set; }

        [StringLength(100)]
        public string Mode_name_US { get; set; }

        public bool Is_available { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Protocol> Protocols { get; set; }
    }
}
