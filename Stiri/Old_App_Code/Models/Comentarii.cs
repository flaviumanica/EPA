    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

namespace Stiri
{
    [Table("Comentarii")]
    public partial class Comentarii
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Text { get; set; }

        public int Id_Articol { get; set; }

        public int Id_User { get; set; }

        public DateTime Data { get; set; }

        public virtual Articol Articol { get; set; }

        public virtual User User { get; set; }
    }
}