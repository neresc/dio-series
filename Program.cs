using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {   
            Serie serie = new Serie(0, Genero.Suspense, "Dexter", "Perito criminal de Miami é um serial Killer", 2008);
            repositorio.Insere(serie);
            Serie serie2 = new Serie(0, Genero.Fantasia, "Merlin", "Aventura com o maior mago de todos os tempos", 2010);
            repositorio.Insere(serie2);

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
               switch (opcaoUsuario){
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
                        VisualizarSerie();
                        break;
                    case "C":
                    Console.Clear();
                        break;
                    default:
                   //     throw new ArgumentOutOfRangeException();
                   Console.WriteLine("Erro de alguma coisa");
                        break;
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
        }

        private static void VisualizarSerie(){
            Console.Write("Digite o número da série que você deseja visualizar: ");
            int entradaId = int.Parse(Console.ReadLine());
            
            Serie serie = repositorio.RetornaPorId(entradaId);
                        
            Console.WriteLine(serie);

        }

        private static void ExcluirSerie(){
            Console.Write("Digite o número da série que você deseja excluir: ");
            int entradaId = int.Parse(Console.ReadLine());
            
            repositorio.Exclui(entradaId);
            
            Console.WriteLine("Série excluída com sucesso.");

        }
        private static void AtualizarSerie(){
            Console.Write("Digite o número da série que você deseja alterar: ");
            int entradaId = int.Parse(Console.ReadLine());
           
            Console.WriteLine();

             foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("\nInforme o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de estréia da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Informe a descriação da série: ");
            string entradaDescricao = Console.ReadLine();
            Serie serieEditando = new Serie(id: entradaId,
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        ano: entradaAno, 
                                        descricao: entradaDescricao);

            repositorio.Atualiza(entradaId, serieEditando);
            Console.WriteLine("\nDados da série atualizados com sucesso.");

            


        }
        private static void InserirSerie(){
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("\nInforme o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de estréia da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Informe a descriação da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                        genero: (Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        ano: entradaAno, 
                                        descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);

            Console.WriteLine("Série inserida com sucesso.");

        }

        private static void ListarSeries(){
            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista){
                var excluido = serie.retornaExcluido();
                
                    Console.WriteLine("ID {0}: {1}{2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? " - Excluído" : "" ));
                
            }
        }

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Projeto DIO Séries\n");
			
			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();
            Console.Write("\nInforme a opção desejada: ");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
