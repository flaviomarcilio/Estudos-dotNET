using System;

namespace Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) 
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
               
        }

        public double Fechar()
        {
            if (this.Saldo == 0)
            {
                return 0;
            } 
            else if (this.Saldo > 0)
            {
                Console.WriteLine("Você possui um saldo de {0}", this.Saldo);
                return this.Saldo;
            }
            else{
                Console.WriteLine("Você possui um débito de {0}", this.Saldo);
                return this.Saldo;
            }
        }

        public bool Sacar(double valorSaque)
        {
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTranferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTranferencia))
            {
                contaDestino.Depositar(valorTranferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo da Conta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }
    }

}