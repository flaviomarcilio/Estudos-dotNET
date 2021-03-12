using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        FecharConta();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void FecharConta()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            double saldo = listaContas[indiceConta].Fechar();

            if (saldo == 0) {
                listaContas.RemoveAt(indiceConta);
                Console.WriteLine("Conta encerrada com sucesso.");
            } else if (saldo > 0) {
                Console.WriteLine("Deseja fazer o saque deste valor?");
                Console.Write("Digite S para [sim] ou N para [não]: ");
                string opcao = Console.ReadLine().ToUpper();
                if (opcao == "S") {
                    listaContas[indiceConta].Sacar(saldo);
                    listaContas.RemoveAt(indiceConta);
                    Console.WriteLine("Conta encerrada com sucesso.");
                } else {
                    Console.WriteLine("Conta não encerrada!");
                }
            } else {
                Console.WriteLine("Deseja fazer o depósito deste valor?");
                Console.Write("Digite S para [sim] ou N para [não]: ");
                string opcao = Console.ReadLine().ToUpper();
                if (opcao == "S") {
                    listaContas[indiceConta].Depositar(-saldo);
                    listaContas.RemoveAt(indiceConta);
                    Console.WriteLine("Conta encerrada com sucesso.");
                } else {
                    Console.WriteLine("Conta não encerrada!");
                }
            } 
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int contaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[contaOrigem].Transferir(valorTransferencia, listaContas[contaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i <  listaContas.Count; i++) 
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("********** Menu Banco **********");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Fechar Conta");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
