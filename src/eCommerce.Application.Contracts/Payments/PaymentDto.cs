using System;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Payments;

public class PaymentDto : EntityDto<Guid>
{
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    public Currency Currency { get; set; }
}
