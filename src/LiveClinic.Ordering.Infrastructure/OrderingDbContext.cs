using LiveClinic.Ordering.Core.Domain;
using LiveClinic.SharedKernel.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LiveClinic.Ordering.Infrastructure
{
    public class OrderingDbContext:BaseContext
    {
        public DbSet<DrugOrder> DrugOrders { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public OrderingDbContext(DbContextOptions<OrderingDbContext> options) : base(options)
        {
        }
    }
}
