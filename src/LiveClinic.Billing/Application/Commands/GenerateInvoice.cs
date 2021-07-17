using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.Billing.Application.Dtos;
using LiveClinic.Billing.Domain;
using MediatR;
using Serilog;

namespace LiveClinic.Billing.Application.Commands
{
    public class GenerateInvoice:IRequest<Result>
    {
        public InvoiceDto InvoiceDto { get; }

        public GenerateInvoice(InvoiceDto invoiceDto)
        {
            InvoiceDto = invoiceDto;
        }
    }

    public class GenerateInvoiceHandler : IRequestHandler<GenerateInvoice, Result>
    {
        private readonly IMediator _mediator;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IPriceCatalogRepository _priceCatalogRepository;

        public GenerateInvoiceHandler(IMediator mediator, IInvoiceRepository invoiceRepository, IPriceCatalogRepository priceCatalogRepository)
        {
            _mediator = mediator;
            _invoiceRepository = invoiceRepository;
            _priceCatalogRepository = priceCatalogRepository;
        }

        public async Task<Result> Handle(GenerateInvoice request, CancellationToken cancellationToken)
        {
            try
            {
                var invoice = Invoice.Generate(request.InvoiceDto);

               await _invoiceRepository.CreateOrUpdateAsync(invoice);

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
