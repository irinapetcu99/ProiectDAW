using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Entities;

namespace WebApplication3.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<Produs> Produs { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Comanda>()
            .HasMany(x => x.Produse)
            .WithOne(y => y.Comanda);

            builder.Entity<User>()
            .HasOne(x => x.Comanda)
            .WithOne(y => y.User)
            .HasForeignKey<Comanda>(z => z.UserId);

            builder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(z => z.UserId);

            builder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(z => z.RoleId);

            builder.Entity<UserRole>()
                .HasAlternateKey(x => new { x.UserId, x.RoleId });
        }
    }
}
