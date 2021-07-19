using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiveClinic.SharedKernel.Domain.Repositories;

namespace LiveClinic.Inventory.Domain.Repositories
{
    public interface IDrugRepository : IRepository<Drug, Guid>
    {
    }
}
