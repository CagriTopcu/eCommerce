using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace eCommerce.Discounts;

public interface IDiscountAppService : IApplicationService
{
    Task<DiscountDto> GetAsync(Guid id);
    Task<PagedResultDto<DiscountDto>> GetListAsync(GetDiscountListDto input);
    Task<DiscountDto> CreateAsync(CreateDiscountDto input);
    Task UpdateAsync(Guid id, UpdateDiscountDto input);
    Task DeleteAsync(Guid id);
}
