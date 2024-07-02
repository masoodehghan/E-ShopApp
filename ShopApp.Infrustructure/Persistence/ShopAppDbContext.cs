using Microsoft.EntityFrameworkCore;
using ShopApp.Domain.BuyerAggregate;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.OrderAggregate;
using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.TagAggregate;
using ShopApp.Domain.UserAggregate;
using ShopApp.Infrustructure.Configurations;

namespace ShopApp.Infrustructure.Persistence;


public class ShopAppDbContext : DbContext
{
    public ShopAppDbContext(
        DbContextOptions<ShopAppDbContext> options
    ) : base(options)
    { }



    DbSet<User> Users { get; set; } = null!;
    DbSet<Product> Products { get; set; } = null!;
    DbSet<Category> Categories { get; set; } = null!;
    DbSet<Tag> Tags { get; set; } = null!;
    DbSet<Buyer> Buyers { get; set; } = null!;
    DbSet<Order> Orders { get; set; } = null!;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ShopAppDbContext).Assembly
        );
        base.OnModelCreating(modelBuilder);
    }
}
