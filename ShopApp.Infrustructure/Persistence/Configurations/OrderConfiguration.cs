using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Domain.BuyerAggregate.ValueObjects;
using ShopApp.Domain.OrderAggregate;
using ShopApp.Domain.OrderAggregate.Enums;
using ShopApp.Domain.OrderAggregate.ValueObjects;
using ShopApp.Domain.ProductAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Configurations;


public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        ConfigureOrderItemsTable(builder);
        ConfigureOrderTable(builder);
    }

    private void ConfigureOrderItemsTable(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsMany(o => o.OrderItems, ob => 
        {
            ob.ToTable("OrderItems");
            ob.WithOwner().HasForeignKey("OrderId");
            ob.HasKey("Id", "OrderId");
            ob.Property(o => o.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => OrderItemId.Create(value)
                    )
                    .HasColumnName("OrderItemId");
            
            ob.Property(o => o.ProductId)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => ProductId.Create(value)
                    )
                    .HasColumnName("ProductId");
        });

        builder.Metadata
                .FindNavigation(nameof(Order.OrderItems))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureOrderTable(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey("Id");
        builder.Property(o => o.Id)
                .ValueGeneratedNever()
                .HasColumnName("OrderId")
                .HasConversion(
                    id => id.Value,
                    value => OrderId.Create(value)
                );
        
        builder.OwnsOne(o => o.Address);
        builder.Property(o => o.BuyerId)
                 .ValueGeneratedNever()
                 .HasColumnName("BuyerId")
                 .HasConversion(
                    id => id.Value,
                    value => BuyerId.Create(value)
                 );

        builder.Property(o => o.OrderStatus)
            .HasDefaultValue(OrderStatus.UnPaid)
            .HasConversion<string>();

    }
}
