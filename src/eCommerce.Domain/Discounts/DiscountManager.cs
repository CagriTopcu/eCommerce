using Volo.Abp.Domain.Services;

namespace eCommerce.Discounts;

public class DiscountManager : DomainService
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountManager(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
}
