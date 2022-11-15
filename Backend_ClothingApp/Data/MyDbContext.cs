using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend_ClothingApp.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) { }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<User>().Property(e => e.UpdatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Order>().Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Cart>().Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Cart>().Property(e => e.id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<CartDetail>().HasIndex(p => new { p.CartId, p.ProductId }).IsUnique();
            modelBuilder.Entity<OrderDetail>().HasIndex(p => new { p.OrderId, p.ProductId }).IsUnique();
         }
        #endregion
    }
}
