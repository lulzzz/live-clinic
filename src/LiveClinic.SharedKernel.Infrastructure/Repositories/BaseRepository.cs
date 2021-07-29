﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiveClinic.SharedKernel.Domain;
using LiveClinic.SharedKernel.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LiveClinic.SharedKernel.Infrastructure
{
    public abstract class BaseRepository<T, TId> :  IRepository<T, TId> where T : AggregateRoot<TId>
    {
        protected internal DbContext Context;
        protected internal readonly DbSet<T> DbSet;

        protected BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual Task<T> GetAsync(TId id)
        {
            return DbSet.FindAsync(id).AsTask();
        }

        public Task<TC> GetAsync<TC, TId1>(TId1 id) where TC : Entity<TId1>
        {
            return Context.Set<TC>().FindAsync(id).AsTask();
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).AsNoTracking();
        }

        public IQueryable<TC> GetAll<TC,TId>(Expression<Func<TC, bool>> predicate) where TC : Entity<TId>
        {
            return Context.Set<TC>().Where(predicate).AsNoTracking();
        }

        public virtual async Task<bool> ExistsAsync(T entity)
        {
            return null !=  await GetAll(x=>x.Id.Equals(entity.Id)).FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsAsync<TC,TId>(TC entity) where TC : Entity<TId>
        {
            return null != await Context.Set<TC>().AsNoTracking().FirstOrDefaultAsync(x=>x.Id.Equals(entity.Id));
        }

        public virtual Task CreateOrUpdateAsync(T entity)
        {
            if (null == entity)
                throw new Exception("cannot save null objects");

            return CreateOrUpdateAsync(new List<T> {entity});
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
                DbSet.AddRange(entities);

            if (updates.Any())
                DbSet.UpdateRange(entities);

            await Context.SaveChangesAsync();
        }

        public virtual async Task CreateOrUpdateAsync<TC,TId>(IEnumerable<TC> entities) where TC : Entity<TId>
        {
            var updates = new List<TC>();
            var inserts = new List<TC>();

            foreach (var entity in entities)
            {
                var exists = await ExistsAsync<TC,TId>(entity);
                if (exists)
                    updates.Add(entity);
                else
                    inserts.Add(entity);
            }

            if (inserts.Any())
                Context.Set<TC>().AddRange(entities);

            if (updates.Any())
                Context.Set<TC>().UpdateRange(entities);

            await Context.SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
        public virtual async Task Delete(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public virtual async  Task DeleteById(TId id)
        {
            var entity = await GetAsync(id);
            if(null==entity)
                return;

            Delete(entity);
        }

        public virtual async Task DeleteById(IEnumerable<TId> ids)
        {
            var entities = DbSet.Where(x => ids.Contains(x.Id));
            if(!entities.Any())
                return;

            DbSet.RemoveRange(entities);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteById<TC, TCId>(IEnumerable<TCId> ids) where TC : Entity<TCId>
        {
            var entities = Context.Set<TC>().Where(x => ids.Contains(x.Id));
            if(!entities.Any())
                return;

            Context.Set<TC>().RemoveRange(entities);
            await Context.SaveChangesAsync();
        }
    }
}
