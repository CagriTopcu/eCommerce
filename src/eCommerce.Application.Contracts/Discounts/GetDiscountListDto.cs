using Volo.Abp.Application.Dtos;

namespace eCommerce.Discounts;

public class GetDiscountListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
