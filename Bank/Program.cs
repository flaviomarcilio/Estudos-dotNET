using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Flávio Marcilio");

            Console.WriteLine(minhaConta.ToString());
        }

    }
}
