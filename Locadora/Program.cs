using System;

namespace Locadora
{
    class Program
    {
        static SerieRepositorio serieRepositorio = new SerieRepositorio();
        static FilmeRepositorio filmeRepositorio = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcao = menuPrincipal();

            while (opcao != "X")
            {
                string opcaoUsuario = ObterOpcaoUsuario(opcao);

                while (opcaoUsuario != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            Listar(opcao);
                            break;
                        case "2":
                            Inserir(opcao);
                            break;
                        case "3":
                            Atualizar(opcao);
                            break;
                        case "4":
                            Excluir(opcao);
                            break;
                        case "5":
                            Visualizar(opcao);
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    opcaoUsuario = ObterOpcaoUsuario(opcao);
                }
                opcao = menuPrincipal();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void Visualizar(string opcao)
        {
            Console.Write("Digite o ID {0}: ", opcao == "F" ? "do Filme" : "da Série");
            int indice = int.Parse(Console.ReadLine());
            if (opcao == "S")
            {
                var serie = serieRepositorio.RetornaPorId(indice);
                Console.WriteLine(serie);
            }
            else
            {
                var filme = filmeRepositorio.RetornaPorId(indice);
                Console.WriteLine(filme);
            }

        }

        private static void Excluir(string opcao)
        {
            Console.Write("Digite o ID {0}: ", opcao == "F" ? "do Filme" : "da Série");
            int indice = int.Parse(Console.ReadLine());

            if (opcao == "S")
            {
                serieRepositorio.Exclui(indice);
            }
            else
            {
                filmeRepositorio.Exclui(indice);
            }
        }

        private static void Atualizar(string opcao)
        {
            Console.Write("Digite o ID {0}: ", opcao == "F" ? "do Filme" : "da Série");
            int indice = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título {0}: ", opcao == "F" ? "do Filme" : "da Série");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de {0}: ", opcao == "F" ? "lançamento do Filme" : "início da Série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição {0}: ", opcao == "F" ? "do Filme" : "da Série");
            string entradaDescricao = Console.ReadLine();

            if (opcao == "S")
            {
                Serie atualizaSerie = new Serie(id: indice,
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                ano: entradaAno,
                                                descricao: entradaDescricao);
                
                serieRepositorio.Atualiza(indice, atualizaSerie);
            }
            else{
                Console.Write("Digite a avaliação do Filme: ");
                float entradaRate = float.Parse(Console.ReadLine());

                Filme atualizaFilme = new Filme(id: indice,
                                                genero: (Genero)entradaGenero,
                                                titulo: entradaTitulo,
                                                descricao: entradaDescricao,
                                                ano: entradaAno,
                                                rate: entradaRate);

                filmeRepositorio.Atualiza(indice, atualizaFilme);
            }
        }

        private static void Listar(string opcao)
        {
            Console.WriteLine("Catálogo de {0}", opcao == "F" ? "Filmes" : "Séries");

            if (opcao == "S")
            {
                var series = serieRepositorio.Lista();

                if (series.Count == 0)
                {
                    Console.WriteLine("Nenhuma série cadastrada.");
                    return;
                }
                foreach (var serie in series)
                {
                    var excluido = serie.retornaExcluido();
                    if (!excluido) {
                        Console.WriteLine("#ID {0}: {1}", serie.retornaId(), serie.retornaTitulo());
                    }
                }
            }
            else
            {
                var filmes = filmeRepositorio.Lista();

                if (filmes.Count == 0)
                {
                    Console.WriteLine("Nenhum filme cadastrado.");
                    return;
                }
                foreach (var filme in filmes)
                {
                    var excluido = filme.retornaExcluido();
                    if (!excluido) {
                        Console.WriteLine("#ID {0}: {1}", filme.retornaId(), filme.retornaTitulo());
                    }
                }
            }
        }

        private static void Inserir(string opcao)
        {
            Console.WriteLine("Inserir {0}", opcao == "F" ? "novo Filme" : "nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título {0}: ", opcao == "F" ? "do Filme" : "da Série");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de {0}: ", opcao == "F" ? "lançamento do Filme" : "início da Série");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição {0}: ", opcao == "F" ? "do Filme" : "da Série");
            string entradaDescricao = Console.ReadLine();

            if (opcao == "S")
            {

                Serie novaSerie = new Serie(id: serieRepositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
                
                serieRepositorio.Insere(novaSerie);
            }
            else
            {
                Console.Write("Digite a avaliação do Filme: ");
                float entradaRate = float.Parse(Console.ReadLine());

                Filme novoFilme = new Filme(id: filmeRepositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            descricao: entradaDescricao,
                                            ano: entradaAno,
                                            rate: entradaRate);
                filmeRepositorio.Insere(novoFilme);
            }
        }

        private static string menuPrincipal()
        {
            Console.WriteLine();
            Console.WriteLine("**** LoCaDoRa VoCê FeLiZ ****");
            Console.WriteLine("Informe a seção desejada:");
            Console.WriteLine("F - Filmes");
            Console.WriteLine("S - Séries");
            Console.WriteLine("X - sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }

        private static string ObterOpcaoUsuario(string opcao)
        {
            Console.WriteLine();
            Console.WriteLine("**** LoCaDoRa VoCê FeLiZ ****");
            Console.WriteLine("O que você deseja fazer:");
            
            Console.WriteLine("1 - Listar {0}", opcao == "F" ? "Filme" : "Série");
            Console.WriteLine("2 - Inserir {0}", opcao == "F" ? "Filme" : "Série");
            Console.WriteLine("3 - Atualizar {0}", opcao == "F" ? "Filme" : "Série");
            Console.WriteLine("4 - Excluir {0}", opcao == "F" ? "Filme" : "Série");
            Console.WriteLine("5 - Visualizar {0}", opcao == "F" ? "Filme" : "Série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Voltar ao menu principal");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
