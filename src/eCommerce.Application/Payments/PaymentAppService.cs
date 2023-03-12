using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

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

    public async Task<PaymentDto> CreateAsync(CreatePaymentDto input)
    {
        Payment payment = new(
            GuidGenerator.Create(),
            input.OrderId,
            input.Amount,
            input.Status,
            input.Currency);

        await _paymentRepository.InsertAsync(payment);
        return ObjectMapper.Map<Payment, PaymentDto>(payment);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _paymentRepository.DeleteAsync(id);
    }

    public async Task<PaymentDto> GetAsync(Guid id)
    {
        Payment payment = await _paymentRepository.GetAsync(id);
        return ObjectMapper.Map<Payment, PaymentDto>(payment);
    }

    public async Task<PagedResultDto<PaymentDto>> GetListAsync(GetPaymentListDto input)
    {
        if(input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Payment.CreationTime);
        }

        List<Payment> payments = await _paymentRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        int totalCount = await _paymentRepository.CountAsync();

        return new PagedResultDto<PaymentDto>(
            totalCount,
            ObjectMapper.Map<List<Payment>, List<PaymentDto>>(payments)
        );
    }

    public async Task UpdateAsync(Guid id, UpdatePaymentDto input)
    {
        Payment existingPayment = await _paymentRepository.GetAsync(id);

        if (existingPayment is null)
            throw new PaymentNotFoundException();

        Payment payment = new(
            id,
            input.OrderId,
            input.Amount,
            input.Status,
            input.Currency);

        await _paymentRepository.UpdateAsync(payment);
    }
}
