using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace eCommerce.Payments;

public class Payment : AuditedEntity<Guid>
{
    public Guid OrderId { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public Currency Currency { get; private set; }

    private Payment()
    {
    }

    public Payment(Guid orderId, decimal amount, PaymentStatus paymentStatus, Currency currency)
    {
        OrderId = Check.NotNull(orderId, nameof(orderId));
        Amount = Check.NotNull(amount, nameof(amount));
        PaymentStatus = Check.NotNull(paymentStatus, nameof(paymentStatus));
        Currency = Check.NotNull(currency, nameof(currency));
    }
}
