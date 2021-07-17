using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using LiveClinic.Inventory.Application.Dtos;
using LiveClinic.Inventory.Domain;
using MediatR;
using Serilog;

namespace LiveClinic.Inventory.Application.Queries
{
    public class GetInventory:IRequest<Result<List<InventoryDto>>>
    {
        public Guid? DrugId { get; }

        public GetInventory(Guid? drugId)
        {
            DrugId = drugId;
        }
    }

    public class GetInventoryHandler : IRequestHandler<GetInventory,Result<List<InventoryDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IDrugRepository _drugRepository;


        public GetInventoryHandler( IMapper mapper,IDrugRepository drugRepository)
        {
            _mapper = mapper;
            _drugRepository = drugRepository;
        }

        public  Task<Result<List<InventoryDto>>> Handle(GetInventory request, CancellationToken cancellationToken)
        {
            try
            {
                var drugs=new List<Drug>();
                if(request.DrugId.HasValue)
                    drugs =  _drugRepository.GetAllStock(request.DrugId.Value).ToList();
                else
                    drugs =  _drugRepository.GetAllStock(null).ToList();

                var dtp = _mapper.Map<List<InventoryDto>>(drugs);


                return Task.FromResult(Result.Success(dtp));
            }
            catch (Exception e)
            {
                var msg = $"Error {request.GetType().Name}";
                Log.Error(msg, e);
                return Task.FromResult<>(Result.Failure(msg));
            }
        }
    }
}
