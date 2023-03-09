using Volo.Abp.Application.Dtos;

namespace eCommerce.Stores;

public class GetStoreListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
