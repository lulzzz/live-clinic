using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiveClinic.Inventory.Core.Domain;
using LiveClinic.Inventory.Core.Domain.Repositories;
using LiveClinic.SharedKernel.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LiveClinic.Inventory.Persistence.Repositories
{
    public class DrugRepository:BaseRepository<Drug,Guid>, IDrugRepository
    {
        public DrugRepository(InventoryDbContext context) : base(context)
        {
        }

        public List<Drug> LoadAll(Expression<Func<Drug, bool>> predicate = null)
        {
            if(null==predicate)
                return GetAll().Include(x => x.Transactions)
                    .ToList();

            return GetAll(predicate).Include(x => x.Transactions)
                .ToList();
        }
    }
}
