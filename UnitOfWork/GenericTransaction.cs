using System;
using PortalRepRap.Framework.UnitOfWork.Interface;
using NHibernate;

namespace PortalRepRap.Framework.UnitOfWork
{
    public class GenericTransaction : IGenericTransaction
    {
        private readonly ITransaction _transaction;

        public GenericTransaction(ITransaction transaction)
        {
            _transaction = transaction;
        }

        #region IGenericTransaction Members
        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public bool IsActive
        {
            get { return _transaction.IsActive; }
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
        #endregion
    }
}
