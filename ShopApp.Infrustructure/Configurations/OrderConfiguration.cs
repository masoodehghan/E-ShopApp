using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Domain.BuyerAggregate.ValueObjects;
using ShopApp.Domain.OrderAggregate;
using ShopApp.Domain.OrderAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Configurations;


public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        ConfigureOrderTable(builder);
        ConfigureOrderItemIdsTable(builder);
    }

    private void ConfigureOrderItemIdsTable(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsMany(o => o.OrderItemIds, oib => 
        {
            oib.ToTable("OrderOrderItemIds");
            oib.HasKey("Id");
            oib.WithOwner().HasForeignKey("OrderId");
            oib.Property(o => o.Value)
                .ValueGeneratedNever()
                .HasColumnName("OrderItemId");
        });

        builder.Metadata
                .FindNavigation(nameof(Order.OrderItemIds))!
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

    }
}
