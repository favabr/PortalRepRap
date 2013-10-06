using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalRepRap.Framework.UnitOfWork.Interface
{
    public interface IUnitOfWorkFactory
    {
        Configuration Configuration { get; }
        ISessionFactory SessionFactory { get; }

        IUnitOfWork Create();
        void DisposeUnitOfWork(UnitOfWorkImplementor adapter);
    }
}
