using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalRepRap.Domain
{
    public class Clientes
    {
        public virtual int ID { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual string CPF { get; set; }
        public virtual string RG { get; set; }
        public virtual string CNPJ { get; set; }
        public virtual string TelefoneFixo { get; set; }
        public virtual string Celular { get; set; }
        public virtual string CEP { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Referencia { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Pais { get; set; }
        public virtual bool Newsletter { get; set; }
        public virtual bool Inativo { get; set; }
        public virtual DateTime DataInativacao { get; set; }
        public virtual DateTime DataModificacao { get; set; }
        public virtual DateTime DataCadastro { get; set; }
    }
}