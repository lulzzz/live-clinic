using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiveClinic.Inventory.Domain;
using LiveClinic.Inventory.Domain.Repositories;
using LiveClinic.SharedKernel.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LiveClinic.Inventory.Persistence.Repositories
{
    public class DrugRepository:BaseRepository<Drug,Guid>, IDrugRepository
    {
        public DrugRepository(InventoryDbContext context) : base(context)
        {
        }
    }
}
