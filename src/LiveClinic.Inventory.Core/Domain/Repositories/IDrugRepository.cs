using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiveClinic.SharedKernel.Domain.Repositories;

namespace LiveClinic.Inventory.Core.Domain.Repositories
{
    public interface IDrugRepository : IRepository<Drug, Guid>
    {
        List<Drug> LoadAll(Expression<Func<Drug, bool>> predicate = null);
    }
}
