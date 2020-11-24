using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Banco_Digital.Classes
{
    public class layout
    {
        private static List<usuario> usuarios = new List<usuario>();
        private static int opcao = 0;
        public static void telaprincipal()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();

            Console.WriteLine("=======================================================");
            Console.WriteLine("=                DIGITE A OPÇÃO DESEJADA:             =");
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                1 - CRIAR CONTA                      =");
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                2 - ENTRAR COM CPF E SENHA           =");
            Console.WriteLine("=======================================================");
        
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    telacriarconta();
                    break;
                case 2:
                    telalogin();
                    break;
                default:
                    Console.WriteLine("Opção Inválida!");
                    break;
            }
            
        }

        private static void telacriarconta()
        {
            Console.Clear();

            usuario user = new usuario();

            string arquivo_nome = "C:\\Users\\Jonh Wili\\Documents\\UCL\\PROGRAMAÇÃO AVANÇADA DE SISTEMAS\\Trabalho\\nome.txt";
            string arquivo_cpf = "C:\\Users\\Jonh Wili\\Documents\\UCL\\PROGRAMAÇÃO AVANÇADA DE SISTEMAS\\Trabalho\\CPF.txt";
            string arquivo_senha = "C:\\Users\\Jonh Wili\\Documents\\UCL\\PROGRAMAÇÃO AVANÇADA DE SISTEMAS\\Trabalho\\senha.txt";

            Console.WriteLine("=======================================================");
            Console.WriteLine("=                    DIGITE SEU NOME:                 =");
            Console.WriteLine("=======================================================");
            StreamWriter sw;
            if (File.Exists(arquivo_nome) == true)
            {
                sw = File.AppendText(arquivo_nome);
            }
            else
            {
                sw = File.CreateText(arquivo_nome);
            }
            user.Nome = Console.ReadLine() + "; ";
            sw.WriteLine(user.Nome);
            sw.Close();
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                    DIGITE SEU CPF:                  =");
            Console.WriteLine("=======================================================");
            string texto_cpf = File.ReadAllText("C:\\Users\\Jonh Wili\\Documents\\UCL\\PROGRAMAÇÃO AVANÇADA DE SISTEMAS\\Trabalho\\CPF.txt");
            user.Cpf = Console.ReadLine() + "; " + texto_cpf;
            string cpf_atual = Console.ReadLine();


            //if (ValidarCPF.ValidadorCPF(cpf_atual) == false)
           // {
            //    Console.WriteLine("=======================================================");
            //    Console.WriteLine("=                     CPF INVÁLIDO:                   =");
            //    Console.WriteLine("=======================================================");
            //}
            //else
            //{

            File.WriteAllText(arquivo_cpf, user.Cpf);
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                    DEFINA UMA SENHA:                =");
            Console.WriteLine("=======================================================");

            string texto_senha = File.ReadAllText("C:\\Users\\Jonh Wili\\Documents\\UCL\\PROGRAMAÇÃO AVANÇADA DE SISTEMAS\\Trabalho\\senha.txt");
            string senha_usuario = Console.ReadLine();
            user.Senha = Console.ReadLine() + "; " + texto_senha;
            File.WriteAllText(arquivo_senha, user.Senha);

            contacorrente contacorrente = new contacorrente();
            usuario usuario = new usuario();

            usuario.setnome(user.Nome);
            usuario.setcpf(user.Cpf);
            usuario.setsenha(senha_usuario);
            usuario.conta = contacorrente;

            usuarios.Add(usuario);

            Console.Clear();

            Console.WriteLine("=======================================================");
            Console.WriteLine("=            CONTA CADASTRADA COM SUCESSO!            =");
            Console.WriteLine("=======================================================");

            Thread.Sleep(2000);

            contalogada(usuario);
          //  }
        }

        private static void telalogin()
        {
            Console.Clear();

            Console.WriteLine("=======================================================");
            Console.WriteLine("=                    DIGITE SEU CPF:                  =");
            Console.WriteLine("=======================================================");
            string cpf = Console.ReadLine();
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                    DIGITE SUA SENHA:                =");
            Console.WriteLine("=======================================================");
            string senha = Console.ReadLine();

            //var valores = File.ReadAllLines("C:\\Users\\Jonh Wili\\Documents\\UCL\\PROGRAMAÇÃO AVANÇADA DE SISTEMAS\\Trabalho\\cpf.txt");
            


            usuario usuario = usuarios.FirstOrDefault(x => x.Cpf == cpf && x.Senha == senha);
            


            if(usuario != null)
            {
                telaboasvindas(usuario);

                contalogada(usuario);

            }
            else
            {
                Console.Clear();

                Console.WriteLine("=======================================================");
                Console.WriteLine("=                  PESSOA NÃO CADASTRADA              =");
                Console.WriteLine("=======================================================");
                Console.WriteLine();
                Console.WriteLine();

                Thread.Sleep(2000);
                telaprincipal();
            }
        }

        private static void telaboasvindas(usuario usuario)
        {

            string msgbemvindo =
                $"{usuario.Nome} | Banco: {usuario.conta.recebe_codigo_banco()} | Ag: {usuario.conta.recebe_numero_agencia()} | Cc: {usuario.conta.recebe_numero_conta()}";
            Console.WriteLine("");
            Console.WriteLine($"                Seja bem vindo, {msgbemvindo}");
            Console.WriteLine("");
        }

        private static void contalogada(usuario usuario)
        {
            Console.Clear();

            telaboasvindas(usuario);
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                DIGITE A OPÇÃO DESEJADA:             =");
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                  1 - REALIZAR DEPÓSITO              =");
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                  2 - CONSULTAR SALDO                =");
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                  3 - REALIZAR SAQUE                 =");
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                  4 - EXTRATO                        =");
            Console.WriteLine("=======================================================");
            Console.WriteLine("=                  5 - SAIR                           =");
            Console.WriteLine("=======================================================");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:

                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("=        DIGITE O VALOR QUE DESEJA DEPOSITAR:         =");
                    Console.WriteLine("=======================================================");

                    double valor_deposito = int.Parse(Console.ReadLine());

                    Console.WriteLine("=======================================================");
                    Console.WriteLine("=        CONFIRMA O VALOR DE " + valor_deposito + " REAIS?                      = ");
                    Console.WriteLine("=                1 - SIM | 2 - NÃO                   = ");
                    Console.WriteLine("=======================================================");

                    double resposta_deposito = int.Parse(Console.ReadLine());

                    if(resposta_deposito == 1) {

                        Console.Clear();
                        usuario.conta.deposita(valor_deposito);

                        Console.WriteLine("==============================================================================");
                        Console.WriteLine("=        O DEPÓSITO NO VALOR DE " + valor_deposito + " REAIS FOI EFETUADO.         =");
                        Console.WriteLine("==============================================================================");

                        StreamWriter sw;
                        
                        sw = File.AppendText("C:\\Users\\Jonh Wili\\Documents\\UCL\\PROGRAMAÇÃO AVANÇADA DE SISTEMAS\\Trabalho\\extrato.txt");

                        sw.WriteLine("DEPÓSITO NO VALOR DE " + valor_deposito + " REAIS \r\n");
                        sw.Close();


                        Thread.Sleep(3000);
                        contalogada(usuario);
                        }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("==============================================================================");
                        Console.WriteLine("=       O DEPÓSITO NO VALOR DE " + valor_deposito + " REAIS FOI CANCELADO.         =");
                        Console.WriteLine("==============================================================================");

                        Thread.Sleep(3000);
                        contalogada(usuario);
                    }

                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("==============================================================================");
                    Console.WriteLine("=        O SEU SALDO ATUAL É DE " + usuario.conta.consultasaldo() + " REAIS.         =");
                    Console.WriteLine("==============================================================================");

                    Thread.Sleep(3000);
                    contalogada(usuario);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("=          DIGITE O VALOR QUE DESEJA SACAR:           =");
                    Console.WriteLine("=======================================================");

                    double valor_saque = int.Parse(Console.ReadLine());
                    
                    if(valor_saque > usuario.conta.consultasaldo())
                    {
                        Console.Clear();
                        Console.WriteLine("===============================================================================================================================================");
                        Console.WriteLine("=          O VALOR SOLICITADO NÃO ESTÁ DISPONÍVEL PARA SAQUE, O SALDO ATUAL DE SUA CONTA É DE:" + usuario.conta.consultasaldo() + " REAIS           =");
                        Console.WriteLine("===============================================================================================================================================");

                        Thread.Sleep(3000);
                        contalogada(usuario);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("=        CONFIRMA O VALOR DE " + valor_saque + " REAIS?                       = ");
                        Console.WriteLine("=                1 - SIM | 2 - NÃO                   = ");
                        Console.WriteLine("=======================================================");

                    double resposta_saque = int.Parse(Console.ReadLine());

                        if (resposta_saque == 1)
                        {
                            Console.Clear();
                            usuario.conta.sacar(valor_saque);
                            Console.WriteLine("==============================================================================");
                            Console.WriteLine("=           O SAQUE NO VALOR DE " + valor_saque + " REAIS FOI EFETUADO.            =");
                            Console.WriteLine("==============================================================================");

                            StreamWriter sw;
                            sw = File.AppendText("C:\\Users\\Jonh Wili\\Documents\\UCL\\PROGRAMAÇÃO AVANÇADA DE SISTEMAS\\Trabalho\\extrato.txt");

                            sw.WriteLine("SAQUE NO VALOR DE " + valor_saque + " REAIS. \r\n");
                            sw.Close();

                            Thread.Sleep(3000);
                            contalogada(usuario);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("==============================================================================");
                            Console.WriteLine("=           O SAQUE NO VALOR DE " + valor_saque + " REAIS FOI CANCELADO.           =");
                            Console.WriteLine("==============================================================================");

                            Thread.Sleep(3000);
                            contalogada(usuario);
                        }
                    }
                    break;
                case 4:
                    Console.Clear();

                    using (StreamReader sr = new StreamReader("C:\\Users\\Jonh Wili\\Documents\\UCL\\PROGRAMAÇÃO AVANÇADA DE SISTEMAS\\Trabalho\\extrato.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }

                        Console.WriteLine("==============================================================================");
                        Console.WriteLine("=     O SEU SALDO ATUAL É DE " + usuario.conta.consultasaldo() + " REAIS.    =");
                        Console.WriteLine("==============================================================================");

                        Thread.Sleep(4000);
                        contalogada(usuario);
                    }

                    break;
                case 5:
                    FileInfo fi = new FileInfo("C:\\Users\\Jonh Wili\\Documents\\UCL\\PROGRAMAÇÃO AVANÇADA DE SISTEMAS\\Trabalho\\extrato.txt");
                    if (fi.Exists)
                        fi.CreateText();
                    telaprincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("=======================================================");
                    Console.WriteLine("=                  OPÇÃO INVÁLIDA.                    =");
                    Console.WriteLine("=======================================================");

                    Thread.Sleep(2000);
                    contalogada(usuario);
                    break;
            }
        }

    }
}