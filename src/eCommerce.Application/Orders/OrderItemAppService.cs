using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Orders;

public class OrderItemAppService : eCommerceAppService, IOrderItemAppService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly OrderItemManager _orderItemManager;

    public OrderItemAppService(IOrderItemRepository orderItemRepository, OrderItemManager orderItemManager)
    {
        _orderItemRepository = orderItemRepository;
        _orderItemManager = orderItemManager;
    }

    public Task<OrderItemDto> CreateAsync(CreateOrderItemDto input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItemDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<OrderItemDto>> GetListAsync(GetOrderItemListDto input)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, UpdateOrderItemDto input)
    {
        throw new NotImplementedException();
    }
}
