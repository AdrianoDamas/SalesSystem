using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Sales.Infra.Data
{
    /// <summary>
    /// Referência de artigo para conseguir criar modelos de configuração
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    /// Rererência de artigo para conseguir criar migration a partir de dominios
    /// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
    /// </summary>
    public class SalesContext : DbContext
    {
        public DbSet<Domain.SalesAggregate.Order> Order { get; set; }
        public DbSet<Domain.SalesAggregate.OrderItems> OrderItems { get; set; }
        public DbSet<Domain.SalesAggregate.Product> Product { get; set; }
        public SalesContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.Entity<Domain.SalesAggregate.Order>();

            modelBuilder.ApplyConfiguration(new OrderItemsEntityTypeConfiguration());
            modelBuilder.Entity<Domain.SalesAggregate.OrderItems>();

            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.Entity<Domain.SalesAggregate.Product>();

        }
    }

    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Domain.SalesAggregate.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.SalesAggregate.Order> orderConfiguration)
        {
            orderConfiguration.ToTable("Order", "dbo");

            orderConfiguration.HasKey(o => o.Id);
            orderConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderConfiguration.Property(o => o.ClientName).IsRequired();
            orderConfiguration.Property(o => o.ClientEmail).IsRequired();
            orderConfiguration.Property(o => o.CreationDate).IsRequired();
            orderConfiguration.Property(o => o.Payment).IsRequired();
        }
    }

    public class OrderItemsEntityTypeConfiguration : IEntityTypeConfiguration<Domain.SalesAggregate.OrderItems>
    {
        public void Configure(EntityTypeBuilder<Domain.SalesAggregate.OrderItems> orderItemsConfiguration)
        {
            orderItemsConfiguration.ToTable("OrderItems", "dbo");

            orderItemsConfiguration.HasKey(o => o.Id);
            orderItemsConfiguration.Property(o => o.Id).UseIdentityColumn();
            orderItemsConfiguration.Property(o => o.IdOrder).IsRequired();
            orderItemsConfiguration.Property(o => o.IdProduct).IsRequired();
            orderItemsConfiguration.Property(o => o.Quantity).IsRequired();
        }
    }

    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Domain.SalesAggregate.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.SalesAggregate.Product> productConfiguration)
        {
            productConfiguration.ToTable("Product", "dbo");

            productConfiguration.HasKey(o => o.Id);
            productConfiguration.Property(o => o.Id).UseIdentityColumn();
            productConfiguration.Property(o => o.ProductName).IsRequired();
            productConfiguration.Property(o => o.Value).IsRequired();
        }
    }
}