using System;

namespace CRUDSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaousuario = Menu();

            while(opcaousuario.ToUpper() != "X") 
            {
                switch(opcaousuario) 
                {
                    case "1":
                        InserirSerie();
                        break;
                    case "2":
                        ListarSeries();
                         break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaousuario = Menu();
            }
            Console.ReadLine();

        }

                private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }

            foreach (var serie in lista)
            {

                var excluido = serie.getExcluido();
				Console.WriteLine("#ID {0}: - {1} {2}", serie.getId(), serie.getTitulo(), (excluido ? "*Excluído*" : ""));
			}
        }

          private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}

            private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaId(indiceSerie);

			Console.WriteLine(serie);
		}

         private static void ExcluirSerie()
		{
            Console.WriteLine("Deseja mesmo relizar a exclusão? ");
            string respostaUsuario = Console.ReadLine();
            if(respostaUsuario == "s") {
                Console.Write("Digite o id da série: ");
			    int indiceSerie = int.Parse(Console.ReadLine());
                repositorio.Exclui(indiceSerie);
            } 
            else {
                Console.WriteLine("Série não excluida");
            }

		}

        private static string Menu()
        {
            Console.WriteLine("Séries");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Inserie nova série");
            Console.WriteLine("2- Listar séries");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string menu = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return menu;
        }
    }
}
