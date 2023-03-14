using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace eCommerce.Stores;

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.ToTable(eCommerceConsts.DbTablePrefix + "Stores",
            eCommerceConsts.DbSchema);

        builder.ConfigureByConvention();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(StoreConsts.MaxNameLength);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(StoreConsts.MaxTitleLength);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(StoreConsts.MaxDescriptionLength);

        builder.Property(x => x.Url)
            .IsRequired();
    }
}
