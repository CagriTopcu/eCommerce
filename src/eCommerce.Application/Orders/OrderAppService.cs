using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace eCommerce.Orders;

public class OrderAppService : eCommerceAppService, IOrderAppService
{
    private readonly IOrderRepository _orderRepository;
    private readonly OrderManager _orderManager;

    public OrderAppService(IOrderRepository orderRepository, OrderManager orderManager)
    {
        _orderRepository = orderRepository;
        _orderManager = orderManager;
    }

    public async Task<OrderDto> CreateAsync(CreateOrderDto input)
    {
        Order order = new(
            GuidGenerator.Create(),
            input.StoreId,
            input.CustomerId,
            input.BillingAddressId,
            input.ShippingAddressId,
            input.PaymentId,
            input.SubTotal,
            input.Tax,
            input.Total,
            input.Discount,
            input.PickupInStore,
            input.Status);

        await _orderRepository.InsertAsync(order);
        return ObjectMapper.Map<Order, OrderDto>(order);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _orderRepository.DeleteAsync(id);
    }

    public async Task<OrderDto> GetAsync(Guid id)
    {
        Order order = await _orderRepository.GetAsync(id);
        return ObjectMapper.Map<Order, OrderDto>(order);
    }

    public async Task<PagedResultDto<OrderDto>> GetListAsync(GetOrderListDto input)
    {
        if(input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Order.CreationTime);
        }

        List<Order> orders = await _orderRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        int totalCount = input.Filter == null
            ? await _orderRepository.CountAsync()
            : await _orderRepository.CountAsync(
                order => order.OrderNo.Contains(input.Filter));

        return new PagedResultDto<OrderDto>(
            totalCount,
            ObjectMapper.Map<List<Order>, List<OrderDto>>(orders)
        );
    }

    public async Task UpdateAsync(Guid id, UpdateOrderDto input)
    {
        Order existingOrder = await _orderRepository.GetAsync(id);

        if (existingOrder is null)
            throw new OrderNotFoundException();

        Order order = new(
            id,
            input.StoreId,
            input.CustomerId,
            input.BillingAddressId,
            input.ShippingAddressId,
            input.PaymentId,
            input.SubTotal,
            input.Tax,
            input.Total,
            input.Discount,
            input.PickupInStore,
            input.Status);

        await _orderRepository.UpdateAsync(order);
    }
}
