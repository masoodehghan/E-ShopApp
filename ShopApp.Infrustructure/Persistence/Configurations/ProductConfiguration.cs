using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Configurations;


public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        ConfigureProductTable(builder);
        ConfigureOrderItemIdsTable(builder);
        ConfigureTagIdsTable(builder);
    }

    private void ConfigureTagIdsTable(EntityTypeBuilder<Product> builder)
    {
        builder.OwnsMany(p => p.TagIds, tib => {
                tib.ToTable("ProductTagIds");
                tib.HasKey("Id");
                tib.WithOwner().HasForeignKey("ProductId");
                
                tib.Property(ti => ti.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("TagId");
        });
        builder.Metadata
                .FindNavigation(nameof(Product.TagIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    

    private void ConfigureOrderItemIdsTable(EntityTypeBuilder<Product> builder)
    {
        builder.OwnsMany(p => p.OrderItemIds, tib => {
                tib.ToTable("ProductOrderItemIdIds");
                tib.HasKey("Id");
                tib.WithOwner().HasForeignKey("ProductId");
                
                tib.Property(ti => ti.Value)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderItemId");
        });
        builder.Metadata
                .FindNavigation(nameof(Product.OrderItemIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureProductTable(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");
        builder.HasKey("Id");
        builder.Property(p => p.Id)
            .HasColumnName("ProductId")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value)
            );

        builder.Property(p => p.CategoryId)
                    .HasColumnName("CategoryId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => CategoryId.Create(value)
                    );
    }
}
