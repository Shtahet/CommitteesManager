namespace CommittessManager.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMDB.Counterparties")]
    public partial class Counterparty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Counterparty()
        {
            Agendas = new HashSet<Agenda>();
        }

        [Key]
        public int CounterpartID { get; set; }

        [Required]
        [StringLength(200)]
        public string Counterpart_name_UA { get; set; }

        [Required]
        [StringLength(200)]
        public string Counterpart_name_US { get; set; }

        public bool Is_available { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agenda> Agendas { get; set; }
    }
}
