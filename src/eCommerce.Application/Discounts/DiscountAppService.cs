using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace eCommerce.Discounts;

public class DiscountAppService : eCommerceAppService, IDiscountAppService
{
    private readonly IDiscountRepository _discountRepository;
    private readonly DiscountManager _discountManager;

    public DiscountAppService(IDiscountRepository discountRepository, DiscountManager discountManager)
    {
        _discountRepository = discountRepository;
        _discountManager = discountManager;
    }

    public async Task<DiscountDto> CreateAsync(CreateDiscountDto input)
    {
        Discount discount = await _discountManager.CreateAsync(
            input.Name,
            input.Code,
            input.DiscountType,
            input.DiscountPercentage,
            input.DiscountAmount,
            input.IsExpirable,
            input.StartDate,
            input.ExpireDate);

        await _discountRepository.InsertAsync(discount);
        return ObjectMapper.Map<Discount, DiscountDto>(discount);
    } 

    public async Task DeleteAsync(Guid id)
    {
        await _discountRepository.DeleteAsync(id);
    }

    public async Task<DiscountDto> GetAsync(Guid id)
    {
        Discount discount = await _discountRepository.GetAsync(id);
        return ObjectMapper.Map<Discount, DiscountDto>(discount);
    }

    public async Task<PagedResultDto<DiscountDto>> GetListAsync(GetDiscountListDto input)
    {
        if(input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Discount.Name);
        }

        List<Discount> discounts = await _discountRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        int totalCount = input.Filter == null
            ? await _discountRepository.CountAsync()
            : await _discountRepository.CountAsync(
                discount => discount.Name.Contains(input.Filter));

        return new PagedResultDto<DiscountDto>(
            totalCount,
            ObjectMapper.Map<List<Discount>, List<DiscountDto>>(discounts)
        );
    }

    public async Task UpdateAsync(Guid id, UpdateDiscountDto input)
    {
        Discount existingDiscount = await _discountRepository.GetAsync(id);

        await _discountManager.ChangeNameAsync(existingDiscount, input.Name);
        await _discountManager.ChangeCodeAsync(existingDiscount, input.Code);

        Discount discount = new(
            id,
            existingDiscount.Name,
            existingDiscount.Code,
            input.DiscountType,
            input.DiscountPercentage,
            input.DiscountAmount,
            input.IsExpirable,
            input.StartDate,
            input.ExpireDate);

        await _discountRepository.UpdateAsync(discount);
    }
}
