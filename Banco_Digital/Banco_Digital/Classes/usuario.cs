using Banco_Digital.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco_Digital.Classes
{
    public class usuario
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public iconta conta { get; set; }

        public void setnome(string nome)
        {
            this.Nome = nome;
        }

        public void setcpf(string cpf)
        {
            this.Cpf = cpf;
        }

        public void setsenha(string senha)
        {
            this.Senha = senha;
        }

        internal void setnome(object nome)
        {
         
        }
    }
}
