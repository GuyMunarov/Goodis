using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;
using Models.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Infrastracture.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext([NotNullAttribute] DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<BpType> BpTypes { get; set; }
        public DbSet<BusinessPartner> BusinessPartners { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public DbSet<SaleOrderLine> SaleOrderLines { get; set; }
        public DbSet<SalesOrderLineComment> SaleOrderLinesComments { get; set; }

        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasIndex(x => x.UserName).IsUnique();

            modelBuilder.Entity<SaleOrderLine>().HasOne(x => x.CreatedBy).WithMany(z => z.SaleOrderLines);
            modelBuilder.Entity<PurchaseOrderLine>().HasOne(x => x.CreatedBy).WithMany(z => z.PurchaseOrderLines);

            modelBuilder.Entity<PurchaseOrder>().HasOne(x => x.CreatedBy).WithMany(z => z.PurchaseOrdersCreated);
            modelBuilder.Entity<PurchaseOrder>().HasOne(x => x.LastUpdatedBy).WithMany(z => z.PurchaseOrdersUpdated);

            modelBuilder.Entity<SaleOrder>().HasOne(x => x.CreatedBy).WithMany(z => z.SaleOrdersCreated);
            modelBuilder.Entity<SaleOrder>().HasOne(x => x.LastUpdatedBy).WithMany(z => z.SaleOrdersUpdated);


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var decimalProperties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in decimalProperties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }



        }

    }
}