using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimplyLifestyle.Domain;

namespace SimplyLifestyle.Infrastructure;

internal class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasConversion(
                productCategoryId => productCategoryId.Value,
                value => new ProductCategoryId(value));

        builder
            .HasMany(x => x.Products)
            .WithOne()
            .HasForeignKey("ProductCategoryId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
