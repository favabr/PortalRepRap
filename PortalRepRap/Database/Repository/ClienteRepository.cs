using NHibernate;
using NHibernate.Linq;
using PortalRepRap.Domain;
using System.Collections.Generic;
using System.Linq;

namespace PortalRepRap.Database.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ISession _session;

        public ClienteRepository(ISession session)
        {
          _session = session;
        }

        public IList<Cliente> Clientes()
        {
            var query = _session.Query<Cliente>()
                                .Where(c => !c.Inativo)
                                .OrderByDescending(c => c.DataCadastro);

            //query.FetchMany(c => c.Tags).ToFuture();

            return query.ToFuture().ToList();
        }
    }
}