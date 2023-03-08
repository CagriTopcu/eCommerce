using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace eCommerce.Orders;

public class OrderItem : AuditedEntity<Guid>
{
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal TotalPrice => Price * Quantity;

    private OrderItem()
    {
    }

    public OrderItem(Guid orderId, Guid productId, int quantity, decimal price)
    {
        OrderId = Check.NotNull(orderId, nameof(orderId));
        ProductId = Check.NotNull(productId, nameof(productId));
        Quantity = Check.NotNull(quantity, nameof(quantity));
        Price = Check.NotNull(price, nameof(price));
    }
}
