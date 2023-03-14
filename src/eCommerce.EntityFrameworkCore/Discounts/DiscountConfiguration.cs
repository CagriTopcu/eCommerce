using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace eCommerce.Discounts;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable(eCommerceConsts.DbTablePrefix + "Discounts",
            eCommerceConsts.DbSchema);

        builder.ConfigureByConvention();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(DiscountConsts.MaxNameLength);

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(DiscountConsts.MaxCodeLength);

        builder.Property(x => x.DiscountType)
            .IsRequired();

        builder.Property(x => x.DiscountPercentage)
            .IsRequired();

        builder.Property(x => x.DiscountAmount)
            .IsRequired();

        builder.Property(x => x.IsExpirable)
            .IsRequired();
    }
}
