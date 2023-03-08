using JetBrains.Annotations;
using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace eCommerce.Products;

public class Product : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string ShortDescription { get; private set; }
    public string FullDescription { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public Guid CategoryId { get; private set; }

    private Product()
    {
    }

    public Product(
        Guid id,
        [NotNull] string name,
        [CanBeNull] string shortDescription,
        [NotNull] string fullDescription,
        decimal price,
        int stock,
        Guid categoryId) : base(id)
    {
        SetName(name);
        ShortDescription = shortDescription;
        FullDescription = fullDescription;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
    }

    private void SetName([NotNull] string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: ProductConsts.MaxNameLength,
            minLength: ProductConsts.MinNameLength);
    }

}
