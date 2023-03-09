using Volo.Abp.Domain.Services;

namespace eCommerce.Orders;

public class OrderItemManager : DomainService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemManager(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }
}
