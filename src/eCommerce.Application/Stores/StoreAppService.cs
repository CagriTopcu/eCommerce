using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace eCommerce.Stores;

public class StoreAppService : eCommerceAppService, IStoreAppService
{
    private readonly IStoreRepository _storeRepository;
    private readonly StoreManager _storeManager;

    public StoreAppService(IStoreRepository storeRepository, StoreManager storeManager)
    {
        _storeRepository = storeRepository;
        _storeManager = storeManager;
    }

    public async Task<StoreDto> CreateAsync(CreateStoreDto input)
    {
        Store store = await _storeManager.CreateAsync(
            input.UserId,
            input.Name,
            input.Title,
            input.Description,
            input.Url);

        await _storeRepository.InsertAsync(store);
        return ObjectMapper.Map<Store, StoreDto>(store);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _storeRepository.DeleteAsync(id);
    }

    public async Task<StoreDto> GetAsync(Guid id)
    {
        Store store = await _storeRepository.GetAsync(id);
        return ObjectMapper.Map<Store, StoreDto>(store);
    }

    public async Task<PagedResultDto<StoreDto>> GetListAsync(GetStoreListDto input)
    {
        if(input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Store.Name);
        }

        List<Store> stores = await _storeRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        int totalCount = input.Filter == null
            ? await _storeRepository.CountAsync()
            : await _storeRepository.CountAsync(
                store => store.Name.Contains(input.Filter));

        return new PagedResultDto<StoreDto>(
            totalCount,
            ObjectMapper.Map<List<Store>, List<StoreDto>>(stores)
        );
    }

    public async Task UpdateAsync(Guid id, UpdateStoreDto input)
    {
        Store existingStore = await _storeRepository.GetAsync(id);

        if (existingStore is null)
            throw new StoreNotFoundException();

        if(input.Name !=  existingStore.Name) 
            await _storeManager.ChangeNameAsync(existingStore, input.Name);

        if(input.Url != existingStore.Url)
            await _storeManager.ChangeUrlAsync(existingStore, input.Url);

        Store store = new(
            id,
            input.UserId,
            input.Name,
            input.Title,
            input.Description,
            input.Url);

        await _storeRepository.UpdateAsync(store);
    }
}
