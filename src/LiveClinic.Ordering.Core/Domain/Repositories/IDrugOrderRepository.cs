using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LiveClinic.SharedKernel.Domain.Repositories;

namespace LiveClinic.Ordering.Core.Domain.Repositories
{
    public interface IDrugOrderRepository : IRepository<DrugOrder, Guid>
    {
        List<DrugOrder> LoadAll(Expression<Func<DrugOrder, bool>> predicate = null);
    }
}
