using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.Billing.Domain.Repositories;
using MediatR;
using Serilog;

namespace LiveClinic.Billing.Application.Commands
{
    public class ReceivePayment:IRequest<Result>
    {
        public Guid InvoiceId { get; }
        public double Amount  { get; }

        public ReceivePayment(Guid invoiceId, double amount)
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
                var invoice =await _invoiceRepository.GetAsync(request.InvoiceId);

                // invoice.MakePayment();

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
