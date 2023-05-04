using DogShop.Models;
using Microsoft.EntityFrameworkCore;
    


namespace DogShop.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AssociativeProductOrder> AssociativeProductOrders { get; set; }
        public DbSet<AssociativeProductWishlist> AssociativeProductWishlists { get; set; }


        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // 1 - 1 User - Wishlist
            builder.Entity<User>()
                .HasOne(u => u.Wishlist)
                .WithOne(w => w.User)
                .HasForeignKey<User>(u => u.WishlistId);

            builder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithOne(u => u.Wishlist)
                .HasForeignKey<Wishlist>(w => w.UserId);

            // 1 - M User - Orders
            builder.Entity<User>()
                .HasMany(u => u.OrderList)
                .WithOne(o => o.User);

            // M - M Products - Orders
            builder.Entity<AssociativeProductOrder>()
                .HasKey(a => new { a.ProductId, a.OrderId });
            builder.Entity<AssociativeProductOrder>()
                .HasOne(a => a.Order)
                .WithMany(o => o.ProductAssociative)
                .HasForeignKey(a => a.OrderId);
            builder.Entity<AssociativeProductOrder>()
                .HasOne(a => a.Product)
                .WithMany(p => p.OrderAssociative)
                .HasForeignKey(a => a.ProductId);

            // M - M Products - Wishlist
            builder.Entity<AssociativeProductWishlist>()
                .HasKey(a => new { a.ProductId, a.WishlistId });
            builder.Entity<AssociativeProductWishlist>()
                .HasOne(a => a.Wishlist)
                .WithMany(w => w.ProductAssociative)
                .HasForeignKey(a => a.WishlistId);
            builder.Entity<AssociativeProductWishlist>()
                .HasOne(a => a.Product)
                .WithMany(p => p.WishlistAssociative)
                .HasForeignKey(a => a.ProductId);

            base.OnModelCreating(builder);
        }

    }
}
