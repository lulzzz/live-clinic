using System;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using LiveClinic.Inventory.Domain;
using LiveClinic.Inventory.Domain.Events;
using MediatR;
using Serilog;

namespace LiveClinic.Inventory.Application.Commands
{
    public class DispenseDrug : IRequest<Result>
    {
        public Guid DrugId { get; }
        public string BatchNo { get; }
        public double Quantiy { get; }

        public DispenseDrug(Guid drugId, string batchNo, double quantiy)
        {
            DrugId = drugId;
            BatchNo = batchNo;
            Quantiy = quantiy;
        }
    }

    public class DispenseDrugHandler : IRequestHandler<DispenseDrug, Result>
    {
        private readonly IMediator _mediator;
        private readonly IDrugRepository _drugRepository;

        public DispenseDrugHandler(IMediator mediator, IDrugRepository drugRepository)
        {
            _mediator = mediator;
            _drugRepository = drugRepository;
        }

        public async Task<Result> Handle(DispenseDrug request, CancellationToken cancellationToken)
        {
            try
            {
                var drug = await  _drugRepository.GetAsync(request.DrugId);
                if (null == drug)
                    throw new Exception("Drug not Found!");

                var tx= drug.Dispense(request.BatchNo,request.Quantiy);
                _drugRepository.SaveStockTx(tx);

                await _mediator.Publish(new DrugDispensed(tx.Id, tx.DrugId,tx.Quantity), cancellationToken);
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
