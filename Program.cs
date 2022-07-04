namespace AppCadSerie;

using AppCadSerie.classes;
using AppCadSerie.Series;


public class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main()
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                 switch(opcaoUsuario)
                 {
                    case "1":
                        listarSeries();
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
                        VisualizarSerie();
                        break;      
                    case "C":
                        //listarSeries();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();  
                 }                        
           
           opcaoUsuario = ObterOpcaoUsuario();
            }
        }

    private static void VisualizarSerie()
    {
        Console.WriteLine("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var serie = repositorio.RetornaPorId(indiceSerie);

        Console.WriteLine(serie);
    }

    private static void ExcluirSerie()
    {
        Console.WriteLine("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceSerie);
    }

    private static void AtualizarSerie()
    {
        Console.WriteLine("Digite o Id da série");
        int indiceSerie = int.Parse(Console.ReadLine());

      foreach(int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie AtualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, AtualizaSerie);                            
      
    }
    

    private static void InserirSerie()
    {
      Console.WriteLine("Inserir nova série");

      foreach(int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
      }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.insere(novaSerie);                            
      
    }

    private static void listarSeries()
    {
       Console.WriteLine("Listar Séries");

       var lista = repositorio.lista();

       if(lista.Count == 0)
       {
            Console.WriteLine("Nenhuma série cadastrada.");
            return;
       }

       foreach (var serie in lista)
       {
        var excluido =serie.retornaExcluido();
        Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? " - Excluído":" ");
       }
    }

    private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Series: ");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }      
    }
