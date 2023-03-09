using System.ComponentModel.DataAnnotations;
using System;

namespace eCommerce.Stores;

public class UpdateStoreDto
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
