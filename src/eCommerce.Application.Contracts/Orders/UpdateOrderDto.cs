using System.ComponentModel.DataAnnotations;
using System;

namespace eCommerce.Orders;

public class UpdateOrderDto
{
    [Required]
    public Guid StoreId { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [Required]
    public Guid BillingAddressId { get; set; }

    [Required]
    public Guid ShippingAddressId { get; set; }

    [Required]
    public Guid PaymentId { get; set; }

    [Required]
    public decimal SubTotal { get; set; }

    [Required]
    public decimal Tax { get; set; }

    [Required]
    public decimal Total { get; set; }

    [Required]
    public decimal Discount { get; set; }

    [Required]
    public bool PickupInStore { get; set; }

    [Required]
    public OrderStatus Status { get; set; }
}
