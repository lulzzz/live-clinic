using System.Linq;
using LiveClinic.Inventory.Domain;
using LiveClinic.Inventory.Persistence.Seed;
using LiveClinic.SharedKernel.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LiveClinic.Inventory.Persistence
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
