using Banco_Digital.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banco_Digital.Classes
{
    public abstract class conta : banco, iconta
    {
        public conta()
        {
            this.numero_agencia = "0007";
            conta.gerador_numero_conta_sequencial++;
        }

        public double saldo { get; protected set; }
        public string numero_agencia { get; private set; }
        public string numero_conta { get; protected set; }
        public static int gerador_numero_conta_sequencial { get; private set; }

        public double consultasaldo()
        {
            return this.saldo;
        }

        public void deposita(double valor)
        {
            this.saldo += valor;
        }
        public bool sacar(double valor)
        {
            if (valor > this.consultasaldo())
                return false;

            this.saldo -= valor;
            return true;
        }
        public string recebe_codigo_banco()
        {
            return this.codigo_banco;
        }

        public string recebe_numero_agencia()
        {
            return this.numero_agencia;
        }

        public string recebe_numero_conta()
        {
            return this.numero_conta;
        }
    }
}
