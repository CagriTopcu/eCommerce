using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Payments;

public class CreatePaymentDto
{
    [Required]
    public Guid OrderId { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public PaymentStatus Status { get; set; }

    [Required]
    public Currency Currency { get; set; }
}
