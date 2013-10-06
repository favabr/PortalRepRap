using PortalRepRap.Framework.Repository.Interface;

namespace PortalRepRap.Framework.Repository
{
    public class RepositoryFactory
    {
        public static TRepository Create<TDomain, TRepository>()
            where TRepository : IRepository<TDomain>, new()
            where TDomain : class, IEntity
        {
            return new TRepository();
        }

        public static IRepository<TDomain> Create<TDomain>()
            where TDomain : class, IEntity
        {
            return new Repository<TDomain>();
        }
    }
}
