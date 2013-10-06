using System;
using System.Linq;
using System.Linq.Expressions;

namespace PortalRepRap.Framework.Repository.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        /// <summary>
        /// Loads a proxy object with nothing but the primary key set.  
        /// Other properties will be pulled from the DB the first time they are accessed.
        /// Generally only use when you know you will NOT be wanting the other properties though.
        /// </summary>
        TEntity Load(long primaryKey);

        TEntity Get(long primaryKey);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> All();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(object id);
        TEntity Load(object id);
        void Delete(TEntity entity);
        void DeleteAll();
        TEntity Save(TEntity entity);
        TEntity SaveOrUpdate(TEntity entity);
        void Update(TEntity entity);
        TEntity Merge(TEntity entity);
    }
}
