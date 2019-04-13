    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace Stiri
{
    [Table("Table")]
    public partial class Table
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Titlu_propunere { get; set; }

        [Required]
        public string Continut_propunere { get; set; }

        public DateTime Data_propunere { get; set; }

        public int Categorie_propunere { get; set; }

        [Required]
        [StringLength(50)]
        public string Imagine_propunere { get; set; }

        public virtual Categorii Categorii { get; set; }
    }
}