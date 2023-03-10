using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace eCommerce.Payments;

public class PaymentAppService : eCommerceAppService, IPaymentAppService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly PaymentManager _paymentManager;

    public PaymentAppService(IPaymentRepository paymentRepository, PaymentManager paymentManager)
    {
        _paymentRepository = paymentRepository;
        _paymentManager = paymentManager;
    }

    public Task<PaymentDto> CreateAsync(CreatePaymentDto input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentDto> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResultDto<PaymentDto>> GetListAsync(GetPaymentListDto input)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, UpdatePaymentDto input)
    {
        throw new NotImplementedException();
    }
}
