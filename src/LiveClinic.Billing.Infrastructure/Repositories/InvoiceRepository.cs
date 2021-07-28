using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LiveClinic.Billing.Core.Domain.InvoiceAggregate;
using LiveClinic.SharedKernel.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LiveClinic.Billing.Infrastructure.Repositories
{
    public class InvoiceRepository:BaseRepository<Invoice,Guid>, IInvoiceRepository
    {
        public InvoiceRepository(BillingDbContext context) : base(context)
        {
        }

        public List<Invoice> LoadAll(Expression<Func<Invoice, bool>> predicate = null)
        {
            if(null==predicate)
                return GetAll()
                    .Include(x => x.Items)
                    .Include(x=>x.Payments)
                    .ToList();

            return GetAll(predicate)
                .Include(x => x.Items)
                .Include(x=>x.Payments)
                .ToList();
        }
    }
}