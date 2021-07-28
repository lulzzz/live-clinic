using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LiveClinic.Ordering.Core.Domain;
using LiveClinic.Ordering.Core.Domain.Repositories;
using LiveClinic.SharedKernel.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LiveClinic.Ordering.Infrastructure.Repositories
{
    public class DrugOrderRepository:BaseRepository<DrugOrder,Guid>, IDrugOrderRepository
    {
        public DrugOrderRepository(OrderingDbContext context) : base(context)
        {
        }

        public List<DrugOrder> LoadAll(Expression<Func<DrugOrder, bool>> predicate = null)
        {
            if(null==predicate)
                return GetAll().Include(x => x.Prescriptions)
                    .ToList();

            return GetAll(predicate).Include(x => x.Prescriptions)
                .ToList();
        }
    }
}
