using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OrmModel.OpenIddictApiServer
{
    [Table("openiddictapplications")]
    public partial class Openiddictapplication
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = null!;
        [Column("clientid")]
        [StringLength(100)]
        public string Clientid { get; set; } = null!;
        [Column("clientsecret")]
        [StringLength(2000)]
        public string Clientsecret { get; set; } = null!;
        [Column("postlogoutredirecturis")]
        [StringLength(2000)]
        public string? Postlogoutredirecturis { get; set; }
        [Column("concurrencytoken")]
        [StringLength(50)]
        public string Concurrencytoken { get; set; } = null!;
        [Column("consenttype")]
        [StringLength(50)]
        public string? Consenttype { get; set; }
        [Column("displayname")]
        [StringLength(2000)]
        public string Displayname { get; set; } = null!;
        [Column("displaynames")]
        [StringLength(2000)]
        public string? Displaynames { get; set; }
        [Column("permissions")]
        [StringLength(2000)]
        public string Permissions { get; set; } = null!;
        [Column("properties")]
        [StringLength(2000)]
        public string? Properties { get; set; }
        [Column("redirecturis")]
        [StringLength(2000)]
        public string? Redirecturis { get; set; }
        [Column("requirements")]
        [StringLength(2000)]
        public string? Requirements { get; set; }
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; } = null!;
    }
}
