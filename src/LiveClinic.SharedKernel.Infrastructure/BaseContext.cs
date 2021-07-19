using Microsoft.EntityFrameworkCore;

namespace LiveClinic.SharedKernel.Infrastructure
{
    public abstract class BaseContext : DbContext
    {
        protected BaseContext(DbContextOptions options) : base(options)
        {
        }

        public virtual void EnsureSeeded()
        {

        }
    }
}
