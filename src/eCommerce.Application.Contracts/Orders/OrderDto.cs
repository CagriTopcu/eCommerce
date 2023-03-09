using System;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Orders;

public class OrderDto : EntityDto<Guid>
{
    public Guid StoreId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid BillingAddressId { get; set; }
    public Guid ShippingAddressId { get; set; }
    public Guid PaymentId { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
    public decimal Discount { get; set; }
    public bool PickupInStore { get; set; }
    public OrderStatus Status { get; set; }
}
