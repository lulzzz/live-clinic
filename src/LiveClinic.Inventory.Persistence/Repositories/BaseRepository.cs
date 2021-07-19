using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LiveClinic.Inventory.Persistence.Repositories
{
    public abstract class BaseRepository<T, TId> : BaseReadOnlyRepository<T, TId>, IRepository<T, TId>
        where T : AggregateRoot<TId>
    {
        protected BaseRepository(DbContext context) : base(context)
        {
        }

        public async Task CreateAsync(T entity)
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkInsert(entity));
        }

        public async Task CreateAsync<TC, TCId>(TC entity) where TC : Entity<TCId>
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkInsert(entity));
        }

        public async Task CreateAsync(IEnumerable<T> entities)
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkInsert(entities));
        }

        public async Task CreateAsync<TC, TCId>(IEnumerable<TC> entities) where TC : Entity<TCId>
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkInsert(entities));
        }

        public async Task UpdateAsync(T entity)
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkUpdate(entity));
        }

        public async Task UpdateAsync<TC, TCId>(TC entity) where TC : Entity<TCId>
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkUpdate(entity));
        }

        public async Task UpdateAsync(IEnumerable<T> entities)
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkUpdate(entities));
        }

        public async Task UpdateAsync<TC, TCId>(IEnumerable<TC> entities) where TC : Entity<TCId>
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkUpdate(entities));
        }

        public async Task MergeAsync(T entity)
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkMerge(entity));
        }

        public async Task MergeAsync<TC, TCId>(TC entity) where TC : Entity<TCId>
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkMerge(entity));
        }

        public async Task MergeAsync(IEnumerable<T> entities)
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkMerge(entities));
        }

        public async Task MergeAsync<TC, TCId>(IEnumerable<TC> entities) where TC : Entity<TCId>
        {
            using var con = GetNewConnection();
            await con.BulkActionAsync(x => x.BulkMerge(entities));
        }

        public virtual Task CreateOrUpdateAsync(T entity)
        {
            if (null == entity)
                throw new Exception("cannot save null objects");

            return CreateOrUpdateAsync(new List<T> {entity});
        }

        public Task CreateOrUpdateAsync<TC, TCId>(TC entity) where TC : Entity<TCId>
        {
            if (null == entity)
                throw new Exception("cannot save null objects");

            return CreateOrUpdateAsync<TC, TCId>(new List<TC> {entity});
        }

        public virtual async Task CreateOrUpdateAsync(IEnumerable<T> entities)
        {
            var updates = new List<T>();
            var inserts = new List<T>();

            foreach (var entity in entities)
            {
                var exists = await ExistsAsync(entity);
                if (exists)
                    updates.Add(entity);
                else
                    inserts.Add(entity);
            }

            if (inserts.Any())
                GetConnection().BulkInsert(inserts);

            if (updates.Any())
                GetConnection().BulkUpdate(updates);
        }

        public virtual async Task CreateOrUpdateAsync<TC, TCId>(IEnumerable<TC> entities) where TC : Entity<TCId>
        {
            var updates = new List<TC>();
            var inserts = new List<TC>();

            foreach (var entity in entities)
            {
                var exists = await ExistsAsync<TC, TCId>(entity);
                if (exists)
                    updates.Add(entity);
                else
                    inserts.Add(entity);
            }

            if (inserts.Any())
                GetConnection().BulkInsert(inserts);

            if (updates.Any())
                GetConnection().BulkUpdate(updates);
        }

        public virtual void Delete(T entity)
        {
            if (null == entity)
                return;
            Delete(new List<T> {entity});
        }

        public virtual void Delete<TC, TCId>(TC entity) where TC : Entity<TCId>
        {
            if (null == entity)
                return;
            Delete<TC, TCId>(new List<TC> {entity});
        }

        public virtual async void DeleteById(TId id)
        {
            var entity = await GetByIdAsync(id);
            Delete(entity);
        }

        public virtual async void DeleteById<TC, TCId>(TCId id) where TC : Entity<TCId>
        {
            var entity = await GetByIdAsync<TC, TCId>(id);
            Delete<TC, TCId>(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            using var con = GetNewConnection();
            con.BulkDelete(entities);
        }

        public void Delete<TC, TCId>(IEnumerable<TC> entities) where TC : Entity<TCId>
        {
            using var con = GetNewConnection();
            con.BulkDelete(entities);
        }

        public virtual void DeleteById(IEnumerable<TId> ids)
        {
            var entities = GetAll(x => ids.Contains(x.Id));
            Delete(entities);
        }

        public virtual void DeleteById<TC, TCId>(IEnumerable<TCId> ids) where TC : Entity<TCId>
        {
            var entities = GetAll<TC, TCId>(x => ids.Contains(x.Id));
            Delete<TC, TCId>(entities);
        }

        public virtual async Task ExecCommand(string sqlCommand)
        {
            using var con = GetNewConnection();
            await con.ExecuteAsync(sqlCommand);
        }

        public virtual async Task ExecCommand(string sqlCommand, object param)
        {
            using var con = GetNewConnection();
            await con.ExecuteAsync(sqlCommand, param);
        }

        public virtual Task SaveAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
