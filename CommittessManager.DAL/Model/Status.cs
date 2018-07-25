namespace CommittessManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Statuses")]
    public partial class Status
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Status()
        {
            Protocols = new HashSet<Protocol>();
            Deals = new HashSet<Deal>();
            Deals1 = new HashSet<Deal>();
        }

        public int StatusID { get; set; }

        public int Status_typeID { get; set; }

        [StringLength(50)]
        public string Status_type_name { get; set; }

        [Required]
        [StringLength(100)]
        public string Status_name_UA { get; set; }

        [StringLength(100)]
        public string Status_name_US { get; set; }

        public bool Is_available { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Protocol> Protocols { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deal> Deals1 { get; set; }
    }
}
