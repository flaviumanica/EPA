    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace Stiri
{
    public partial class Stiri_Propuse
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Titlu_propunere { get; set; }

        [Required]
        public string Continut_propunere { get; set; }

        public int User_propunere { get; set; }

        public DateTime Data_propunere { get; set; }

        public int Categorie_propunere { get; set; }

        [StringLength(300)]
        public string Imagine_propunere { get; set; }

        public virtual Categorii Categorii { get; set; }

        public virtual User User { get; set; }
    }
}