using System;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Ordering.Domain
{
    public interface IDrugOrderRepository : IRepository<DrugOrder, Guid>
    {
    }
}
