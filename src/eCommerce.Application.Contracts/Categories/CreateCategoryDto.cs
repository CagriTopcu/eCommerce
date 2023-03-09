using System.ComponentModel.DataAnnotations;

namespace eCommerce.Categories;

public class CreateCategoryDto
{
    [Required]
    [StringLength(CategoryConsts.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    [StringLength(CategoryConsts.MinDescriptionLength)]
    public string Description { get; set; }
}
