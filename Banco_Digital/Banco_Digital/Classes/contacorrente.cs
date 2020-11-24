using System;
using System.Collections.Generic;
using System.Text;

namespace Banco_Digital.Classes
{
    class contacorrente : conta
    {
        public contacorrente()
        {
            this.numero_conta = "09" + conta.gerador_numero_conta_sequencial;
        }
    }
}
