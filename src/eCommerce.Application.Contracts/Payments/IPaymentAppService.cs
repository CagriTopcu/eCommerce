using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace eCommerce.Payments;

public interface IPaymentAppService : IApplicationService
{
    Task<PaymentDto> GetAsync(Guid id);
    Task<PagedResultDto<PaymentDto>> GetListAsync(GetPaymentListDto input);
    Task<PaymentDto> CreateAsync(CreatePaymentDto input);
    Task UpdateAsync(Guid id, UpdatePaymentDto input);
    Task DeleteAsync(Guid id);
}
