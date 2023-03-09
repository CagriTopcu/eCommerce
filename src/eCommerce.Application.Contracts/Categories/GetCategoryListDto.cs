using Volo.Abp.Application.Dtos;

namespace eCommerce.Categories;

public class GetCategoryListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}
