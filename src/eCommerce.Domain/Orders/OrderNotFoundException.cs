using Volo.Abp;

namespace eCommerce.Orders;

public class OrderNotFoundException : BusinessException
{
    public OrderNotFoundException()
        : base(eCommerceDomainErrorCodes.OrderNotFound)
    {
        
    }
}
