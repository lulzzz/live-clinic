using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.Billing.Core.Domain.Common;
using LiveClinic.Billing.Core.Domain.InvoiceAggregate;
using MediatR;
using Serilog;

namespace LiveClinic.Billing.Core.Application.Commands
{
    public class ReceivePayment:IRequest<Result>
    {
        public Guid InvoiceId { get; }
        public Money Amount  { get; }

        public ReceivePayment(Guid invoiceId, Money amount)
        {
            InvoiceId = invoiceId;
            Amount = amount;
        }
    }

    public class ReceivePaymentHandler : IRequestHandler<ReceivePayment, Result>
    {
        private readonly IMediator _mediator;
        private readonly IInvoiceRepository _invoiceRepository;


        public ReceivePaymentHandler(IMediator mediator, IInvoiceRepository invoiceRepository)
        {
            _mediator = mediator;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Result> Handle(ReceivePayment request, CancellationToken cancellationToken)
        {
            try
            {
                var payment = new Payment(request.Amount, request.InvoiceId);

                var invoice =await _invoiceRepository.GetAsync(request.InvoiceId);

                invoice.MakePayment(payment);

                _invoiceRepository.CreateOrUpdateAsync(invoice);
                _invoiceRepository.CreateOrUpdateAsync<Payment,Guid>(new []{payment});


                return Result.Success();
            }
            catch (Exception e)
            {
                var msg = $"Error {request.GetType().Name}";
                Log.Error(msg, e);
                return Result.Failure(msg);
            }
        }
    }
}
