using System.Collections.Generic;
using Locadora.Interfaces;

namespace Locadora
{
    public class FilmeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listFilme = new List<Filme>();
        public void Atualiza(int id, Filme filme)
        {
            listFilme[id] = filme;
        }

        public void Exclui(int id)
        {
            listFilme[id].Excluir();
        }

        public void Insere(Filme filme)
        {
            listFilme.Add(filme);
        }

        public List<Filme> Lista()
        {
            return listFilme;
        }

        public int ProximoId()
        {
            return listFilme.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return listFilme[id];
        }
    }
}