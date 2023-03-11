using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace eCommerce.Discounts;

public class DiscountManager : DomainService
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountManager(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task<Discount> CreateAsync(
        [NotNull] string name,
        [NotNull] string code,
        [NotNull] DiscountTypes discountType,
        [NotNull] decimal discountPercentage,
        [NotNull] decimal discountAmount,
        [NotNull] bool isExpirable,
        [CanBeNull] DateTime? startDate,
        [CanBeNull] DateTime? expireDate
        )
    {
        Discount existingDiscount = await _discountRepository.GetAsync(x => x.Name == name || x.Code == code);

        if (existingDiscount is not null)
            throw new DiscountNameAlreadyExistsException(name);

        return new(
            GuidGenerator.Create(),
            name,
            code,
            discountType,
            discountPercentage,
            discountAmount,
            isExpirable,
            startDate,
            expireDate);
    }

    public async Task ChangeNameAsync([NotNull] Discount discount, [NotNull] string newName)
    {
        Check.NotNull(discount, nameof(discount));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingDiscount = await _discountRepository.FindByNameAsync(newName);

        if(existingDiscount is not null && existingDiscount.Id != discount.Id)
            throw new DiscountNameAlreadyExistsException(newName);

        discount.ChangeName(newName);
    }

    public async Task ChangeCodeAsync([NotNull] Discount discount, [NotNull] string newCode)
    {
        Check.NotNull(discount, nameof(discount));
        Check.NotNullOrWhiteSpace(newCode, nameof(newCode));

        var existingDiscount = await _discountRepository.FindByCodeAsync(newCode);

        if (existingDiscount is not null && existingDiscount.Id != discount.Id)
            throw new DiscountCodeAlreadyExistsException(newCode);

        discount.ChangeCode(newCode);
    }

}
