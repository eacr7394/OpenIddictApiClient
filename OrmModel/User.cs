using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrmModel.OpenIddictApiServer
{
    [Table("user")]
    public partial class User
    {
        [Key]
        [Column("id_user")]
        [StringLength(38)]
        public string IdUser { get; set; } = null!;
        [Column("password")]
        [StringLength(256)]
        public string Password { get; set; } = null!;
    }
}
