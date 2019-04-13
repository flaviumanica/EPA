using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Stiri
{
    public partial class UserInRoles
    {
        public int Id { get; set; }

        public int Id_User { get; set; }

        public int Id_Role { get; set; }

        public virtual Roles Roles { get; set; }

        public virtual User User { get; set; }
    }
}