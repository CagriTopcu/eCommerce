using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace eCommerce.Orders;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(eCommerceConsts.DbTablePrefix + "Orders",
            eCommerceConsts.DbSchema);

        builder.ConfigureByConvention();

        builder.Property(x => x.OrderNo)
            .IsRequired();

        builder.Property(x => x.StoreId)
            .IsRequired();

        builder.Property(x => x.CustomerId)
            .IsRequired();

        builder.Property(x => x.BillingAddressId)
            .IsRequired();

        builder.Property(x => x.ShippingAddressId)
            .IsRequired();

        builder.Property(x => x.PaymentId)
            .IsRequired();

        builder.Property(x => x.Subtotal)
            .IsRequired();

        builder.Property(x => x.Tax)
            .IsRequired();

        builder.Property(x => x.Total)
            .IsRequired();

        builder.Property(x => x.Discount)
            .IsRequired();

        builder.Property(x => x.PickupInStore)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();
    }
}
