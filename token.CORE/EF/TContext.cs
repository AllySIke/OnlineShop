using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.DATA.Entities;
using refresh.DATA.Entities;

namespace OnlineShop.CORE.EF
{
    public class TContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public TContext(DbContextOptions<TContext> opt) : base(opt)
        {
            Database.EnsureCreated();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>()
                .HasKey(rt => new { rt.UserId, rt.Token });

            modelBuilder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(t => t.Category)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>[]
                { 
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole<Guid>
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER"
                    },
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
