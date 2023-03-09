using System;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Categories;

public class CategoryDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
