using System.ComponentModel.DataAnnotations;
using System;

namespace eCommerce.Payments;

public class UpdatePaymentDto
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
