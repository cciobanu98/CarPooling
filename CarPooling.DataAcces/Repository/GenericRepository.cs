using System.Collections.Generic;
using CarPooling.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CarPooling.DataAcces.Interfaces;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace CarPooling.DataAcces.Interfaces
{
        public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
        {
            internal CarPoolingContext context;
            internal DbSet<TEntity> dbSet;

            public GenericRepository(CarPoolingContext context)
            {
                this.context = context;
                this.dbSet = context.Set<TEntity>();
            }
        public List<TEntity> Get(
                          Expression<Func<TEntity, bool>> predicate = null,
                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                          bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public List<TEntity> GetPage(
                         Expression<Func<TEntity, bool>> predicate = null,
                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                         int? pageIndex = null,
                         int? pageSize = null,
                         bool disableTracking = true)
        {
           
            IQueryable<TEntity> query = dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (pageSize != null && pageIndex != null)
            {
                int skip = (((int)pageIndex - 1) * (int)pageSize);
                return query.Skip(skip).Take((int)pageSize).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public List<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> selector,
                                      Expression<Func<TEntity, bool>> predicate = null,
                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                      bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector).ToList();
            }
            else
            {
                return query.Select(selector).ToList();
            }
        }
        public TEntity GetFirstorDefault(Expression<Func<TEntity, bool>> predicate = null,
                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                bool disableTracking = true)
        {
            IQueryable<TEntity> query = dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }
        public virtual int Count(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (include != null)
            {
                query = include(query);
            }
            if (predicate == null)
            {
                return query.Count();
            }
            else
            {
                return query.Count(predicate);
            }
        }

        public virtual TEntity GetById(object id)
            {
                return dbSet.Find(id);
            }

            public virtual void Insert(TEntity entity)
            {
                dbSet.Add(entity);
            }

            public virtual void Delete(object id)
            {
                TEntity entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
            }

            public virtual void Delete(TEntity entityToDelete)
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }

            public virtual void Update(TEntity entityToUpdate)
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }

            public IEnumerable<TEntity> GetAll()
            {
             return dbSet.ToList();
            }
        }
  }
