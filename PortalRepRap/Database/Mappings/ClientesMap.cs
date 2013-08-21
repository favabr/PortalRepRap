using FluentNHibernate.Mapping;
using PortalRepRap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalRepRap.Database.Mappings
{
    public class ClientesMap : ClassMap<Clientes>
    {
        public ClientesMap()
        {
            Id(x => x.ID);
            Map(x => x.Nome);
            Map(x => x.Sobrenome);
            Map(x => x.Email);
            Map(x => x.Senha);
            Map(x => x.CPF);
            Map(x => x.RG);
            Map(x => x.CNPJ);
            Map(x => x.TelefoneFixo);
            Map(x => x.Celular);
            Map(x => x.CEP);
            Map(x => x.Endereco);
            Map(x => x.Numero);
            Map(x => x.Complemento);
            Map(x => x.Referencia);
            Map(x => x.Bairro);
            Map(x => x.Cidade);
            Map(x => x.Estado);
            Map(x => x.Pais);
            Map(x => x.Newsletter);
            Map(x => x.Inativo);
            Map(x => x.DataInativacao);
            Map(x => x.DataModificacao);
            Map(x => x.DataCadastro);
        }
    }
}