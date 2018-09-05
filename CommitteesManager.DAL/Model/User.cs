namespace CommitteesManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Users")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Protocols = new HashSet<Protocol>();
            Protocols1 = new HashSet<Protocol>();
            Users1 = new HashSet<User>();
        }

        [StringLength(20)]
        public string UserID { get; set; }

        public int? Access_typeID { get; set; }

        [Required]
        [StringLength(100)]
        public string User_name_UA { get; set; }

        [Required]
        [StringLength(100)]
        public string User_name_US { get; set; }

        [StringLength(255)]
        public string Job_title { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone_number { get; set; }

        [StringLength(20)]
        public string HeadID { get; set; }

        public int? User_order { get; set; }

        public bool Is_available { get; set; }

        public virtual AccessType AccessType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Protocol> Protocols { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Protocol> Protocols1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users1 { get; set; }

        public virtual User User1 { get; set; }
    }
}
