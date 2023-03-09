using System;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Products;

public class ProductDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string FullDescription { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid CategoryId { get; set; }
}
