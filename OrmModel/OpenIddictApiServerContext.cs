
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OrmModel.OpenIddictApiServer.Configurations;
using System;
using System.Collections.Generic;
namespace OrmModel.OpenIddictApiServer
{
    public partial class OpenIddictApiServerContext : DbContext
    {
        public virtual DbSet<Openiddictapplication> Openiddictapplications { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
