using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Discounts;

public class DiscountAppService : eCommerceAppService, IDiscountAppService
{
    private readonly IDiscountRepository _discountRepository;
    private readonly DiscountManager _discountManager;

    public DiscountAppService(IDiscountRepository discountRepository, DiscountManager discountManager)
    {
        _discountRepository = discountRepository;
        _discountManager = discountManager;
    }

    public Task<DiscountDto> CreateAsync(CreateDiscountDto input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<DiscountDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<DiscountDto>> GetListAsync(GetDiscountListDto input)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, UpdateDiscountDto input)
    {
        throw new NotImplementedException();
    }
}
