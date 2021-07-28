using System.Linq;
using LiveClinic.Inventory.Core.Domain;
using LiveClinic.Inventory.Infrastructure.Seed;
using LiveClinic.SharedKernel.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LiveClinic.Inventory.Infrastructure
{
    public class InventoryDbContext:BaseContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public override void EnsureSeeded()
        {
            if (!Drugs.Any())
            {
                Drugs.AddRange(DrugSeed.GetDrugs());
                SaveChanges();
            }
        }
    }
}
