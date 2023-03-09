using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Stores;

public class CreateStoreDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required]
    [StringLength(StoreConsts.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    [StringLength(StoreConsts.MaxTitleLength)]
    public string Title { get; set; }

    [Required]
    [StringLength(StoreConsts.MaxDescriptionLength)]
    public string Description { get; set; }

    [Required]
    public string Url { get; set; }
}
