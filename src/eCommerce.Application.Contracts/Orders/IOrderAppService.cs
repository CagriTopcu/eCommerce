using eCommerce.Discounts;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace eCommerce.Orders;

public interface IOrderAppService : IApplicationService
{
    Task<OrderDto> GetAsync(Guid id);
    Task<PagedResultDto<OrderDto>> GetListAsync(GetOrderListDto input);
    Task<OrderDto> CreateAsync(CreateDiscountDto input);
    Task UpdateAsync(Guid id, UpdateDiscountDto input);
    Task DeleteAsync(Guid id);
}
