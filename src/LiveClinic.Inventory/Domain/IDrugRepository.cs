using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiveClinic.SharedKernel.Domain;

namespace LiveClinic.Inventory.Domain
{
    public interface IDrugRepository: IRepository<Drug,Guid>
    {
        Task SaveStockTx(Stock stock);
        IEnumerable<Drug> GetAllStock(Guid? drugId);
    }
}
