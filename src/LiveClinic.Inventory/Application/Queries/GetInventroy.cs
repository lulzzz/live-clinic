using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using LiveClinic.Inventory.Application.Dtos;
using LiveClinic.Inventory.Domain;
using LiveClinic.Inventory.Domain.Repositories;
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
                    drugs =  _drugRepository.GetAll(x=>x.Id==request.DrugId.Value).ToList();
                else
                    drugs =  _drugRepository.GetAll().ToList();

                var inventoryDtos = _mapper.Map<List<InventoryDto>>(drugs);

                return Task.FromResult(Result.Success(inventoryDtos));
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
