    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace Stiri
{
    [Table("Imagine")]
    public partial class Imagine
    {
        public int Id { get; set; }

        public int Id_Articol { get; set; }

        [Required]
        public string Cale { get; set; }

        public virtual Articol Articol { get; set; }
    }

}