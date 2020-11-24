using System;
using System.Collections.Generic;
using System.Text;

namespace Banco_Digital.Classes
{
    public abstract class banco
    {
        public banco()
        {
            this.nome_banco = "BancoDigital";
            this.codigo_banco = "007";
        }

        public string nome_banco { get; private set; }
        public string codigo_banco { get; private set; }
    }
}
