using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace eCommerce.Stores;

public class Store : AuditedEntity<Guid>
{
    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Url { get; private set; }

    private Store()
    {
    }

    public Store(Guid id, Guid userId, string name, string title, string description, string url)
        : base(id)
    {
        UserId = Check.NotNull(userId, nameof(userId));
        Name = Check.NotNull(name, nameof(name), maxLength: StoreConsts.MaxNameLength, minLength: StoreConsts.MinNameLength);
        Title = Check.NotNull(title, nameof(title), maxLength: StoreConsts.MaxTitleLength, StoreConsts.MinTitleLength);
        Description = Check.NotNull(description, nameof(description), maxLength: StoreConsts.MaxDescriptionLength, minLength: StoreConsts.MinDescriptionLength);
        Url = url;
    }

    internal Store ChangeUrl([NotNull] string url)
    {
        SetUrl(url);
        return this;
    }

    internal Store ChangeName([NotNull] string name)
    {
        SetName(name);
        return this;
    }

    private void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: StoreConsts.MaxNameLength,
            minLength: StoreConsts.MinNameLength);
    }

    private void SetUrl([NotNull] string url)
    {
        Url = Check.NotNullOrWhiteSpace(
            url,
            nameof(url));
    }
}
