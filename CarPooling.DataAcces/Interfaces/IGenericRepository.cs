using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CarPooling.DataAcces.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        List<TResult> Get<TResult>(Expression<Func<TEntity, TResult>> selector,
                                      Expression<Func<TEntity, bool>> predicate = null,
                                      Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                      bool disableTracking = true);
        List<TEntity> Get(
                                 Expression<Func<TEntity, bool>> predicate = null,
                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                 Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                 bool disableTracking = true);
        List<TEntity> GetPage(Expression<Func<TEntity, bool>> predicate = null,
                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                 Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                 int? pageIndex = null,
                                 int? pageSize = null,
                                 bool disableTracking = true);
        TEntity GetFirstorDefault(Expression<Func<TEntity, bool>> predicate = null,
                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                 Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                 bool disableTracking = true);
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        IEnumerable<TEntity> GetAll();
        int Count(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
    }
}