using hicas_training.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Data
{
    public class DbContextTraining : DbContext
    {
        public virtual DbSet<Product> Products { get; set; } 
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        private const string connectionString = "Server=localhost;Database=HicasTraining;Trusted_Connection=True;MultipleActiveResultSets=true;";

        public DbContextTraining( DbContextOptions<DbContextTraining> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasIndex(x => x.IdCart);
                entity.HasKey(x => x.IdCart);

            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(x => x.IdProduct);
                entity.HasKey(x => x.IdProduct);
                entity.HasIndex(x => x.Name);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(x => x.IdUser);
                entity.HasKey(x => x.IdUser);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
