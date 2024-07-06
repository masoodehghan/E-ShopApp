using Microsoft.EntityFrameworkCore;
using ShopApp.Domain.BuyerAggregate;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.OrderAggregate;
using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.TagAggregate;
using ShopApp.Domain.UserAggregate;
using ShopApp.Infrastructure.Persistence.Interceptors;
using ShopApp.Infrustructure.Persistence.Configurations;

namespace ShopApp.Infrustructure.Persistence;


public class ShopAppDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomain;

    public ShopAppDbContext(
        DbContextOptions<ShopAppDbContext> options
, PublishDomainEventsInterceptor publishDomain) : base(options)
    {
        _publishDomain = publishDomain;
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<Buyer> Buyers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ShopAppDbContext).Assembly
        );
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomain);
        base.OnConfiguring(optionsBuilder);
    }
}
