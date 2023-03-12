using Volo.Abp;

namespace eCommerce.Payments;

public class PaymentNotFoundException : BusinessException
{
    public PaymentNotFoundException()
        : base(eCommerceDomainErrorCodes.PaymentNotFound)
    {
    }
}
