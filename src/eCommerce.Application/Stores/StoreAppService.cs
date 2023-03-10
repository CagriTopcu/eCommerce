using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

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

    public Task<StoreDto> CreateAsync(CreateStoreDto input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<StoreDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<StoreDto>> GetListAsync(GetStoreListDto input)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, UpdateStoreDto input)
    {
        throw new NotImplementedException();
    }
}
