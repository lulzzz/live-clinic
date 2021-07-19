using System;
using LiveClinic.SharedKernel.Domain.Repositories;

namespace LiveClinic.Ordering.Domain.Repositories
{
    public interface IDrugOrderRepository : IRepository<DrugOrder, Guid>
    {
    }
}
