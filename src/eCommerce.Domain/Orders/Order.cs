using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace eCommerce.Orders;

public class Order : AuditedAggregateRoot<Guid>
{
    public string OrderNo { get; private set; }
    public Guid StoreId { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid BillingAddressId { get; private set; }
    public Guid ShippingAddressId { get; private set; }
    public Guid PaymentId { get; private set; }
    public decimal Subtotal { get; private set; }
    public decimal Tax { get; private set; }
    public decimal Total { get; private set; }
    public decimal Discount { get; private set; }
    public bool PickupInStore { get; private set; }
    public OrderStatus Status { get; private set; }

    private Order()
    {
    }

    public Order(Guid id, Guid storeId, Guid customerId, Guid billingAddressId, Guid shippingAddressId, Guid paymentId, decimal subtotal, decimal tax, decimal total, decimal discount, bool pickupInStore, OrderStatus status)
        : base(id)
    {
        GenerateOrderNumber();
        StoreId = Check.NotNull(storeId, nameof(storeId));
        CustomerId = Check.NotNull(customerId, nameof(customerId));
        BillingAddressId = Check.NotNull(billingAddressId, nameof(billingAddressId));
        ShippingAddressId = Check.NotNull(shippingAddressId, nameof(shippingAddressId));
        PaymentId = Check.NotNull(paymentId, nameof(paymentId));
        Subtotal = Check.NotNull(subtotal, nameof(subtotal));
        Tax = Check.NotNull(tax, nameof(tax));
        Total = Check.NotNull(total, nameof(total));
        Discount = Check.NotNull(discount, nameof(discount));
        PickupInStore = Check.NotNull(pickupInStore, nameof(pickupInStore));
        Status = Check.NotNull(status, nameof(status));
    }

    private void GenerateOrderNumber()
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new();

        OrderNo = new string(
            Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
    }
}
