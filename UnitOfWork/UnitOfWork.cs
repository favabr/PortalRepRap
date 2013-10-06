using System;
using PortalRepRap.Framework.UnitOfWork.Interface;
using NHibernate;

namespace PortalRepRap.Framework.UnitOfWork
{
    public class UnitOfWork
    {
        private static readonly IUnitOfWorkFactory _unitOfWorkFactory = new UnitOfWorkFactory();

        public const string CurrentUnitOfWorkKey = "CurrentUnitOfWork.Key";

        private static IUnitOfWork CurrentUnitOfWork
        {
            get { return Local.Data[CurrentUnitOfWorkKey] as IUnitOfWork; }
            set { Local.Data[CurrentUnitOfWorkKey] = value; }
        }

        public static IUnitOfWork Current
        {
            get
            {
                var unitOfWork = CurrentUnitOfWork;
                if (unitOfWork == null)
                    throw new InvalidOperationException("You are not in a unit of work");
                return unitOfWork;
            }
        }

        public static bool IsStarted
        {
            get { return CurrentUnitOfWork != null; }
        }

        public static ISession CurrentSession
        {
            get
            {
                return CurrentUnitOfWork.Session;
            }
        }

        public static IUnitOfWork Start()
        {
            if (CurrentUnitOfWork != null)
                return CurrentUnitOfWork;

            var unitOfWork = _unitOfWorkFactory.Create();
            CurrentUnitOfWork = unitOfWork;
            return unitOfWork;
        }

        public static void DisposeUnitOfWork(IUnitOfWork unitOfWork)
        {
            CurrentUnitOfWork = null;
        }
    }
}
