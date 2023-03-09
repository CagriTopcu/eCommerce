using System.ComponentModel.DataAnnotations;
using System;

namespace eCommerce.Orders;

public class UpdateOrderItemDto
{
    [Required]
    public Guid OrderId { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public decimal TotalPrice => Price * Quantity;
}
