using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Domain.CategoryAggregate;
using ShopApp.Domain.CategoryAggregate.ValueObjects;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Configurations;


public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{

    public void Configure(EntityTypeBuilder<Category> builder)
    {
        ConfigureCategoryTable(builder);
        ConfigureProductIds(builder);
    }

    private void ConfigureProductIds(EntityTypeBuilder<Category> builder)
    {
        builder.OwnsMany(s => s.ProductIds, ob => 
        {
            ob.ToTable("CategoryProductIds");
            ob.HasKey("Id");
            ob.WithOwner().HasForeignKey("CategoryId");

            ob.Property(s => s.Value)
                    .HasColumnName("ProductId")
                    .ValueGeneratedNever();
        });
        builder.Metadata.FindNavigation(nameof(Category.ProductIds))!
                    .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureCategoryTable(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey("Id");
        builder.Property(b => b.Id)
                .HasColumnName("CategoryId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => CategoryId.Create(value)
                );

        builder.Property(c => c.Name)
                    .HasMaxLength(100)
                    .IsRequired(true);

    }
}
