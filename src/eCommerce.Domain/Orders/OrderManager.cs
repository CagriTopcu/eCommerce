using Volo.Abp.Domain.Services;

namespace eCommerce.Orders;

public class OrderManager : DomainService
{
    private readonly IOrderRepository _orderRepository;

    public OrderManager(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
}
