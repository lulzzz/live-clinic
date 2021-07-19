using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.Ordering.Application.Dtos;
using LiveClinic.Ordering.Domain;
using LiveClinic.Ordering.Domain.Events;
using LiveClinic.Ordering.Domain.Repositories;
using MediatR;
using Serilog;

namespace LiveClinic.Ordering.Application.Commands
{
    public class PrescribeDrugs:IRequest<Result>
    {
        public DrugOrderDto OrderDto { get; }

        public PrescribeDrugs(DrugOrderDto orderDto)
        {
            OrderDto = orderDto;
        }
    }

    public class PrescribeDrugsHandler : IRequestHandler<PrescribeDrugs, Result>
    {
        private readonly IMediator _mediator;
        private readonly IDrugOrderRepository _drugOrderRepository;

        public PrescribeDrugsHandler(IMediator mediator, IDrugOrderRepository drugOrderRepository)
        {
            _mediator = mediator;
            _drugOrderRepository = drugOrderRepository;
        }

        public async Task<Result> Handle(PrescribeDrugs request, CancellationToken cancellationToken)
        {
            try
            {
                var order=DrugOrder.Generate(request.OrderDto);

               await _drugOrderRepository.CreateOrUpdateAsync(order);

               _mediator.Publish(new DrugOrderGenerated(order.Id, order.OrderNo));

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
