using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Domain.BuyerAggregate;
using ShopApp.Domain.BuyerAggregate.ValueObjects;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Configurations;


public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
{

    public void Configure(EntityTypeBuilder<Buyer> builder)
    {
        ConfigureBuyerTable(builder);
        ConfigureOrderIds(builder);
    }

    private void ConfigureOrderIds(EntityTypeBuilder<Buyer> builder)
    {
        builder.OwnsMany(s => s.OrderIds, ob => 
        {
            ob.ToTable("BuyerOrderIds");
            ob.HasKey("Id");
            ob.WithOwner().HasForeignKey("BuyerId");

            ob.Property(s => s.Value)
                    .HasColumnName("OrderId")
                    .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Buyer.OrderIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureBuyerTable(EntityTypeBuilder<Buyer> builder)
    {
        builder.ToTable("Buyers");

        builder.HasKey("Id");
        builder.Property(b => b.Id)
                .HasColumnName("BuyerId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => BuyerId.Create(value)
                );

        builder.Property(b => b.UserId)
                .HasColumnName("UserId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value)
                );

    }
}
