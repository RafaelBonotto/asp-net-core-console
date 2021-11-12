using series.Classes;
using series.Enum;
using System;

namespace series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoDoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoDoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void VizualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            var indiceInput = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceInput);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            var indiceInput = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceInput);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            var indiceInput = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i}-{System.Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            var generoInput = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string tituloInput = Console.ReadLine();

            Console.Write("Digite o ano de inicio da Série: ");
            int anoInput = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série: ");
            string descricaoInput = Console.ReadLine();

            Serie novaSerie = new Serie(id: indiceInput,
                                        genero: (Genero)generoInput,
                                        titulo: tituloInput,
                                        ano: anoInput,
                                        descricao: descricaoInput);

            repositorio.Atualizar(indiceInput, novaSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            foreach (int i in System.Enum.GetValues(typeof(Genero))) 
            {
                Console.WriteLine($"{i}-{System.Enum.GetName(typeof(Genero), i)}");
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            var generoInput = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string tituloInput = Console.ReadLine();

            Console.Write("Digite o ano de inicio da Série: ");
            int anoInput = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série: ");
            string descricaoInput = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)generoInput,
                                        titulo: tituloInput,
                                        ano: anoInput,
                                        descricao: descricaoInput);

            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Serie cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine($"# ID: {serie.RetornaId()}: {serie.RetornaTitulo()}");
            }
        }
    

        private static string ObterOpcaoDoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series ao sue dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
