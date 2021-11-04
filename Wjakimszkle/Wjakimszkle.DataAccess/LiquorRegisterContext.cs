using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Wjakimszkle.DataAccess.Entities;

namespace Wjakimszkle.DataAccess
{
    public class LiquorRegisterContext:IdentityDbContext
    {
       public LiquorRegisterContext(DbContextOptions<LiquorRegisterContext> opt) : base(opt) { }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Glass> Glasses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DrinkType> DrinkTypes { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public new DbSet<ApplicationUser> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<ApplicationUser>(b =>
            //{
            //    b.HasMany(e => e.UserRoles)
            //    .WithOne(e => e.User)
            //    .HasForeignKey(ur => ur.UserId)
            //    .IsRequired();

            //    //b.ToTable("AspNetUsers");
            //});

            //builder.Entity<ApplicationRole>(b =>
            //{
            //    b.HasMany(e => e.UserRoles)
            //    .WithOne(e => e.Role)
            //    .HasForeignKey(ur => ur.RoleId)
            //    .IsRequired();
            //});

            //builder.Entity<ApplicationUserRole>(b =>
            //{
            //    b.HasKey(r => new { r.UserId, r.RoleId });
            //});

            //builder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Name = "Admin",
            //    NormalizedName = "ADMIN",
            //    Id = Guid.NewGuid().ToString(),
            //    ConcurrencyStamp = Guid.NewGuid().ToString()
            //});

            //builder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Name = "Editor",
            //    NormalizedName = "EDITOR",
            //    Id = Guid.NewGuid().ToString(),
            //    ConcurrencyStamp = Guid.NewGuid().ToString()
            //});

            //builder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Name = "User",
            //    NormalizedName = "USER",
            //    Id = Guid.NewGuid().ToString(),
            //    ConcurrencyStamp = Guid.NewGuid().ToString()
            //});

        }
    }
}
