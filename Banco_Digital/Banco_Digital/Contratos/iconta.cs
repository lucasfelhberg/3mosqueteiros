using System;
using System.Collections.Generic;
using System.Text;

namespace Banco_Digital.Contratos
{
    public interface iconta
    {
        void deposita(double valor);
        bool sacar(double valor);
        double consultasaldo();
        string recebe_codigo_banco();
        string recebe_numero_agencia();
        string recebe_numero_conta();

    }
}
