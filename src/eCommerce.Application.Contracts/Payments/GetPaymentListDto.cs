using Volo.Abp.Application.Dtos;

namespace eCommerce.Payments;

public class GetPaymentListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
