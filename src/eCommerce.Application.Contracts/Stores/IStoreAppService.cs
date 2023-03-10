using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace eCommerce.Stores;

public interface IStoreAppService : IApplicationService
{
    Task<StoreDto> GetAsync(Guid id);
    Task<PagedResultDto<StoreDto>> GetListAsync(GetStoreListDto input);
    Task<StoreDto> CreateAsync(CreateStoreDto input);
    Task UpdateAsync(Guid id, UpdateStoreDto input);
    Task DeleteAsync(Guid id);
}
