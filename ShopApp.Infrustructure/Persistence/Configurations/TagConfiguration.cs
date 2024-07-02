using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Domain.TagAggregate;
using ShopApp.Domain.TagAggregate.ValueObjects;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Configurations;


public class TagConfiguration : IEntityTypeConfiguration<Tag>
{

    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        ConfigureTagTable(builder);
        ConfigureProductIds(builder);
    }

    private void ConfigureProductIds(EntityTypeBuilder<Tag> builder)
    {
        builder.OwnsMany(s => s.ProductIds, ob => 
        {
            ob.ToTable("TagProductIds");
            ob.HasKey("Id");
            ob.WithOwner().HasForeignKey("TagId");

            ob.Property(s => s.Value)
                    .HasColumnName("ProductId")
                    .ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(Tag.ProductIds))!
                    .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureTagTable(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");

        builder.HasKey("Id");
        builder.Property(b => b.Id)
                .HasColumnName("TagId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => TagId.Create(value)
                );

        builder.Property(c => c.Name)
                    .HasMaxLength(100)
                    .IsRequired(true);

    }
}
