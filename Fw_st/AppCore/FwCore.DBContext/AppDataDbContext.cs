using FwCore.DBContext.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace FwCore.DBContext
{
    public class AppDataDbContext : DbContext
    {
        public AppDataDbContext(DbContextOptions<AppDataDbContext> Options) : base(Options) { }

        // All DbSet...
        public DbSet<Category> pCategory { get; set; }

        public DbSet<pBrand> pBrand { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<pStock> pStock { get; set; }

        public DbSet<pUnitPrice> pUnitPrice { get; set; }

        public DbSet<oShipingAddress> oShipingAddress { get; set; }

        public DbSet<pOrder> pOrder { get; set; }

        public DbSet<pOrderDetails> pOrderDetails { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<CustFavoredList> CustFavoredList { get; set; }

        public DbSet<pReview> pReview { get; set; }

        public DbSet<pColor> pColor { get; set; }

        public DbSet<pProductColor> pProductColor { get; set; }

        public DbSet<ProductExtraInfo> ProductExtraInfo { get; set; }

        public DbSet<pImage> Images { get; set; }

        public DbSet<PaymentType> paymentType { get; set; }

        public DbSet<Payment> Payment { get; set; }


    }

}
