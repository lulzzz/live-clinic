using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.Inventory.Domain;
using LiveClinic.Inventory.Domain.Events;
using LiveClinic.Inventory.Domain.Repositories;
using MediatR;
using Serilog;

namespace LiveClinic.Inventory.Application.Commands
{
    public class ReceiveStock : IRequest<Result>
    {
        public Guid DrugId { get; }
        public string BatchNo { get; }
        public double Quantity { get; }

        public ReceiveStock(Guid drugId, string batchNo, double quantity)
        {
            DrugId = drugId;
            BatchNo = batchNo;
            Quantity = quantity;
        }
    }

    public class ReceiveStockHandler : IRequestHandler<ReceiveStock, Result>
    {
        private readonly IMediator _mediator;
        private readonly IDrugRepository _drugRepository;

        public ReceiveStockHandler(IMediator mediator, IDrugRepository drugRepository)
        {
            _mediator = mediator;
            _drugRepository = drugRepository;
        }

        public async Task<Result> Handle(ReceiveStock request, CancellationToken cancellationToken)
        {
            try
            {
                var drug = await  _drugRepository.GetAsync(request.DrugId);
                if (null == drug)
                    throw new Exception("Drug NOT Found!");

                var newStock= drug.ReceiveStock(request.BatchNo,request.Quantity);
                await _drugRepository.CreateOrUpdateAsync<StockTransaction,Guid>(new[] {newStock});

                await _mediator.Publish(new StockReceived(newStock.Id), cancellationToken);

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
