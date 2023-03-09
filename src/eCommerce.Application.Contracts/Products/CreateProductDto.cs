using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Products;

public class CreateProductDto
{
    [Required]
    [StringLength(ProductConsts.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    [StringLength(ProductConsts.MaxShortDescriptionLength)]
    public string ShortDescription { get; set; }

    [Required]
    [StringLength(ProductConsts.MaxFullDescriptionLength)]
    public string FullDescription { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public Guid CategoryId { get; set; }
}
