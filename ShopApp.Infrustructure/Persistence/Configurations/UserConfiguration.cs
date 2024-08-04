using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Domain.UserAggregate;
using ShopApp.Domain.UserAggregate.Enums;
using ShopApp.Domain.UserAggregate.ValueObjects;

namespace ShopApp.Infrustructure.Persistence.Configurations;


public class UserConfiguration : IEntityTypeConfiguration<User>
{

    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);
    }


    private void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey("Id");
        builder.Property(b => b.Id)
                .HasColumnName("UserId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value)
                );

        builder.Property(c => c.FirstName)
                    .HasMaxLength(100)
                    .IsRequired(true);

        
        builder.Property(c => c.LastName)
                    .HasMaxLength(100)
                    .IsRequired(true);

        builder.Property(c => c.Email)
                    .HasMaxLength(100)
                    .IsRequired(true);


        builder.Property(c => c.Username)
                    .HasMaxLength(100)
                    .IsRequired(true);

        builder.Property(c => c.HashedPassword)
                    .HasMaxLength(200)
                    .IsRequired(true);

        builder.Property(c => c.Role)
                .HasDefaultValue(Roles.Buyer)
                .HasConversion<string>();


    }
}
