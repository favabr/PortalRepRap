using System;
using System.Linq;
using System.Linq.Expressions;
using PortalRepRap.Framework.Repository.Interface;
using PortalRepRap.Framework.UnitOfWork;
using NHibernate;
using NHibernate.Linq;

namespace PortalRepRap.Framework.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected virtual ISession Session
        {
            get { return UnitOfWork.UnitOfWork.CurrentSession; }
        }

        protected virtual ISessionFactory SessionFactory
        {
            get { return UnitOfWork.UnitOfWork.CurrentSession.GetSessionImplementation().Factory; }
        }

        private bool _isDisposed;

        ~Repository()
        {
            Dispose(false);
        }

        public TEntity Load(long primaryKey)
        {
            return Session.Load<TEntity>(primaryKey);
        }

        public TEntity Get(long primaryKey)
        {
            return Session.Get<TEntity>(primaryKey);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return All().SingleOrDefault(predicate);
        }

        public IQueryable<TEntity> All()
        {
            return Session.Query<TEntity>();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return All().Where(predicate);
        }

        public TEntity Get(object id)
        {
            return (TEntity)Session.Get(typeof(TEntity), id);
        }

        public TEntity Load(object id)
        {
            return (TEntity)Session.Load(typeof(TEntity), id);
        }

        public void Delete(TEntity entity)
        {
            ((UnitOfWorkImplementor)UnitOfWork.UnitOfWork.Current).HasPendingChanges = true;
            Session.Delete(entity);
        }

        public void DeleteAll()
        {
            ((UnitOfWorkImplementor)UnitOfWork.UnitOfWork.Current).HasPendingChanges = true;
            Session.Delete(string.Format("from {0}", typeof(TEntity).Name));
        }

        public TEntity Save(TEntity entity)
        {
            ((UnitOfWorkImplementor)UnitOfWork.UnitOfWork.Current).HasPendingChanges = true;
            Session.Save(entity);
            return entity;
        }

        public TEntity SaveOrUpdate(TEntity entity)
        {
            ((UnitOfWorkImplementor)UnitOfWork.UnitOfWork.Current).HasPendingChanges = true;
            Session.SaveOrUpdate(entity);
            return entity;
        }

        public void Update(TEntity entity)
        {
            ((UnitOfWorkImplementor)UnitOfWork.UnitOfWork.Current).HasPendingChanges = true;
            Session.Update(entity);
        }

        public TEntity Merge(TEntity entity)
        {
            ((UnitOfWorkImplementor)UnitOfWork.UnitOfWork.Current).HasPendingChanges = true;
            return Session.Merge(entity);
        }

        public void Dispose()
        {
            if (!_isDisposed)
                Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            _isDisposed = true;
            if (disposing)
            {
                // Libera os componentes
            }
        }
    }
}
