using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace eCommerce.Discounts;

public class Discount : AuditedEntity<Guid>
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public DiscountTypes DiscountType { get; private set; }
    public decimal DiscountPercentage { get; private set; }
    public decimal DiscountAmount { get; private set; }
    public bool IsExpirable { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }

    private Discount()
    {
    }

    public Discount(Guid id, string name, string code, DiscountTypes discountType, decimal discountPercentage, decimal discountAmount, bool isExpirable, DateTime? startDate, DateTime? expireDate) : base(id)
    {
        SetName(name);
        SetCode(code);
        DiscountType = Check.NotNull(discountType, nameof(discountType));
        DiscountPercentage = discountPercentage;
        DiscountAmount = discountAmount;
        IsExpirable = Check.NotNull(isExpirable, nameof(isExpirable));
        StartDate = startDate;
        ExpireDate = expireDate;
    }

    private void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: DiscountConsts.MaxNameLength,
            minLength: DiscountConsts.MinNameLength);
    }

    private void SetCode([NotNull] string code)
    {
        Code = Check.NotNullOrWhiteSpace(
            code,
            nameof(code),
            maxLength: DiscountConsts.MaxCodeLength,
            minLength: DiscountConsts.MinCodeLength);
    }
}
