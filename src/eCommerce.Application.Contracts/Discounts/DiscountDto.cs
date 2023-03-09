using System;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Discounts;

public class DiscountDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public DiscountTypes DiscountType { get; set; }
    public decimal DiscountPercentage { get; set; }
    public decimal DiscountAmount { get; set; }
    public bool IsExpirable { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ExpireDate { get; set; }
}
