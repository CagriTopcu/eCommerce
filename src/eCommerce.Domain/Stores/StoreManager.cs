using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace eCommerce.Stores;

public class StoreManager : DomainService
{
    private readonly IStoreRepository _storeRepository;

    public StoreManager(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<Store> CreateAsync(
        [NotNull] Guid userId,
        [NotNull] string name,
        [NotNull] string title,
        [NotNull] string description,
        [NotNull] string url)
    {
        var existingStore = await _storeRepository.FindByNameAsync(name);

        if (existingStore is not null)
            throw new StoreAlreadyExistsException(name);

        return new(
            GuidGenerator.Create(),
            userId,
            name,
            title,
            description,
            url);
    }

    public async Task ChangeNameAsync(
        [NotNull] Store store,
        [NotNull] string newName)
    {
        Check.NotNull(store, nameof(store));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        Store existingStore = await _storeRepository.FindByNameAsync(newName);

        if (existingStore is not null && existingStore.Id != store.Id)
            throw new StoreAlreadyExistsException(newName);

        store.ChangeName(newName);
    }

    public async Task ChangeUrlAsync(
        [NotNull] Store store,
        [NotNull] string newUrl)
    {
        Check.NotNull(store, nameof(store));
        Check.NotNullOrWhiteSpace(newUrl, nameof(newUrl));

        Store existingStore = await _storeRepository.FindByUrlAsync(newUrl);

        if (existingStore is not null)
            throw new StoreUrlAlreadyExistsException(newUrl);

        store.ChangeUrl(newUrl);
    }
}
