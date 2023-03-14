using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace eCommerce.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(eCommerceConsts.DbTablePrefix + "Products", eCommerceConsts.DbSchema);

        builder.ConfigureByConvention();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(ProductConsts.MaxNameLength);

        builder.Property(x => x.ShortDescription)
            .IsRequired()
            .HasMaxLength(ProductConsts.MaxShortDescriptionLength);

        builder.Property(x => x.FullDescription)
            .IsRequired()
            .HasMaxLength(ProductConsts.MaxFullDescriptionLength);

        builder.Property(x => x.Price)
            .IsRequired();

        builder.Property(x => x.Stock)
            .IsRequired();

        builder.Property(x => x.CategoryId)
            .IsRequired();
    }
}
