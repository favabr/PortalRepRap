using System;
using System.Data;
using NHibernate;

namespace PortalRepRap.Framework.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Flush();
        bool IsInActiveTransaction { get; }

        IGenericTransaction BeginTransaction();
        IGenericTransaction BeginTransaction(IsolationLevel isolationLevel);
        void TransactionalFlush();
        void TransactionalFlush(IsolationLevel isolationLevel);
        ISession Session { get; }

        bool HasPendingChanges { get; }
    }
}
