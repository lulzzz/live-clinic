using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CSharpFunctionalExtensions;
using LiveClinic.Ordering.Core.Domain;
using LiveClinic.Ordering.Core.Domain.Repositories;
using MediatR;
using Serilog;

namespace LiveClinic.Ordering.Core.Application.Queries
{
    public class GetOrders : IRequest<Result<List<DrugOrder>>>
    {
        public string Patient { get; }

        public GetOrders(string patient="")
        {
            Patient = patient;
        }
    }

    public class GetOrderHandler : IRequestHandler<GetOrders,Result<List<DrugOrder>>>
    {
        private readonly IDrugOrderRepository _drugOrderRepository;

        public GetOrderHandler(IDrugOrderRepository drugOrderRepository)
        {
            _drugOrderRepository = drugOrderRepository;
        }

        public Task<Result<List<DrugOrder>>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            try
            {
                var drugOrders=new List<DrugOrder>();

                if(string.IsNullOrWhiteSpace(request.Patient))
                    drugOrders =  _drugOrderRepository.LoadAll(x=>x.Patient==request.Patient).ToList();
                else
                    drugOrders =  _drugOrderRepository.LoadAll().ToList();

                return Task.FromResult(Result.Success(drugOrders));
            }
            catch (Exception e)
            {
                var msg = $"Error {request.GetType().Name}";
                Log.Error(msg, e);
                return Task.FromResult(Result.Failure<List<DrugOrder>>(msg));
            }
        }
    }
}
