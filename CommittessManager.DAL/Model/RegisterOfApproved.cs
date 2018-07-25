namespace CommittessManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.RegisterOfApproved")]
    public partial class RegisterOfApproved
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegisterOfApproved()
        {
            Protocols = new HashSet<Protocol>();
        }

        [Key]
        public int RegisterID { get; set; }

        public int ProtocolID { get; set; }

        public int RegisterYears { get; set; }

        public int Register_number { get; set; }

        [Required]
        [StringLength(50)]
        public string Protocol_number { get; set; }

        [Column(TypeName = "date")]
        public DateTime Decision_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Protocol> Protocols { get; set; }

        public virtual Protocol Protocol { get; set; }
    }
}
