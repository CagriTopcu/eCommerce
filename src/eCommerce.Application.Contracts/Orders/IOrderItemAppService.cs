using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace eCommerce.Orders;

public interface IOrderItemAppService : IApplicationService
{
    Task<OrderItemDto> GetAsync(Guid id);
    Task<PagedResultDto<OrderItemDto>> GetListAsync(GetOrderItemListDto input);
    Task<OrderItemDto> CreateAsync(CreateOrderItemDto input);
    Task UpdateAsync(Guid id, UpdateOrderItemDto input);
    Task DeleteAsync(Guid id);
}
