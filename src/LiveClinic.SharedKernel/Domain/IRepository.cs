using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LiveClinic.SharedKernel.Domain
{
    public interface IRepository<T, in TId> where T : AggregateRoot<TId>
    {
        Task<T> GetAsync(TId id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        Task CreateOrUpdateAsync(T entity);
        Task CreateOrUpdateAsync(IEnumerable<T> entities);

        Task Delete(T entity);
        Task DeleteById(TId id);
        Task Delete(IEnumerable<T> entities);
        Task DeleteById(IEnumerable<TId> ids);
    }
}
