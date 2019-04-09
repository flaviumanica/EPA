    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace Stiri
{
    [Table("Articol")]
    public partial class Articol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articol()
        {
            Imagine = new HashSet<Imagine>();
            Comentarii = new HashSet<Comentarii>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Titlu { get; set; }

        public string Continut { get; set; }

        public int Id_User { get; set; }

        public DateTime Data_Publicare { get; set; }

        [Required]
        public string Descriere { get; set; }

        public int Categorie { get; set; }

        public string Link { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imagine> Imagine { get; set; }

        public virtual Categorii Categorii { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentarii> Comentarii { get; set; }
    }
}