using System.ComponentModel.DataAnnotations;

namespace eCommerce.Categories;

public class UpdateCategoryDto
{
    [Required]
    [StringLength(CategoryConsts.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    [StringLength(CategoryConsts.MaxDescriptionLength)]
    public string Description { get; set; }
}
