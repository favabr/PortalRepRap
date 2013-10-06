using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalRepRap.Framework.UnitOfWork.Interface
{
    public interface IGenericTransaction : IDisposable
    {
        void Commit();
        void Rollback();
        bool IsActive { get; }
    }
}
