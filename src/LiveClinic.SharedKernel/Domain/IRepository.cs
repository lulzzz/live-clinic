using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LiveClinic.SharedKernel.Domain
{
    public interface IRepository<T, in TId> where T : AggregateRoot<TId>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        Task CreateOrUpdateAsync(T entity);
        Task CreateOrUpdateAsync(IEnumerable<T> entities);

        void Delete(T entity);
        void DeleteById(TId id);
        void Delete(IEnumerable<T> entities);
        void DeleteById(IEnumerable<TId> ids);
    }
}
