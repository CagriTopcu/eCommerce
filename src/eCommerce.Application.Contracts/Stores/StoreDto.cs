using System;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Stores;

public class StoreDto : EntityDto<Guid>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
}
