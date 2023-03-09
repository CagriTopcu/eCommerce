using Volo.Abp.Application.Dtos;

namespace eCommerce.Orders;

public class GetOrderItemListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
