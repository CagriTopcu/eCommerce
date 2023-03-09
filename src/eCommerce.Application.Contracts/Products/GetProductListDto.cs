using Volo.Abp.Application.Dtos;

namespace eCommerce.Products;

public class GetProductListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
