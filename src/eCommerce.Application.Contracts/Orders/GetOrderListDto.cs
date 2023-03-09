using Volo.Abp.Application.Dtos;

namespace eCommerce.Orders;

public class GetOrderListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
