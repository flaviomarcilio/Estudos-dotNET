using System;

namespace Locadora
{
    public class Filme : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private float Rate { get; set; }
        private bool Excluido { get; set; }

        public Filme(int id, Genero genero, string titulo, string descricao, int ano, float rate)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Rate = rate;
            this.Excluido = false;

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Rate: " + this.Rate + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        
        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}