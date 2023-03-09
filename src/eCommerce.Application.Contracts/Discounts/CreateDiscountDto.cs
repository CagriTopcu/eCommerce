using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Discounts;

public class CreateDiscountDto
{
    [Required]
    [StringLength(DiscountConsts.MaxNameLength)]
    public string Name { get; set; }

    [Required]
    [StringLength(DiscountConsts.MaxCodeLength)]
    public string Code { get; set; }

    [Required]
    public DiscountTypes DiscountType { get; set; }

    [Required]
    public decimal DiscountPercentage { get; set; }

    [Required]
    public decimal DiscountAmount { get; set; }

    [Required]
    public bool IsExpirable { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? ExpireDate { get; set; }
}
