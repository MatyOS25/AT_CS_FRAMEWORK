using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class Controller
    {
        private static Presentation _presentation;

        public Controller(Presentation presentation)
        {
            _presentation = presentation;
        }
        public static void menu()
        {
            string option;
            do
            {
                _presentation.listOptions();

                int option = _presentation.consoleRead(0);
                switch (option)
                {
                    case 1:
                        pesquisarPessoas();
                        break;
                    case 2:
                        adicionarPessoa();
                        break;
                    case 3:
                        return false;

                    default:
                        _presentation.consoleWriter("Escreva um número válido para prosseguir");
                        return false;
                }

                _presentation.pressAnyKey();
                Console.ReadKey();
            }
            while (option != "5");
        }
        private static void adicionarPessoa()
        {
            string nome = "";
            string sobrenome = "";
            DateTime nascimento = new DateTime();
            int ativo = 2;

            while (ativo == 2)
            {
                _presentation.consoleWriter("Digite o nome da pessoa que deseja adicionar: ");
                nome = Console.ReadLine();
                _presentation.consoleWriter("Digite o sobrenome da pessoa que deseja adicionar: ");
                sobrenome = Console.ReadLine();
                _presentation.consoleWriter("Digite a data de aniversário no formato dd/MM/yyyy: ");
                nascimento = DateTime.Parse(Console.ReadLine());
                _presentation.consoleWriter();
                _presentation.consoleWriter(new List<String>() {
                    "Os dados abaixo estão corretos?",
                    $"Nome: {nome} {sobrenome}",
                    $"Data de Aniversário: {nascimento}",
                    $"1 - Sim", $"2 - Não"
                });
                try
                {
                    ativo = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    _presentation.consoleWriter("Insira um número válido ou verifique se as informações estão no padrão correto.");
                }
            }
            pessoas.Add(new Person(nome, sobrenome, nascimento));
            Console.WriteLine($"Adicionado");
            Console.WriteLine();
        }
        void PesquisarTvShow()
        {
            Console.WriteLine("Informe o Nome da Série que deseja pesquisar:");
            var termoPesquisa = Console.ReadLine();
            var seriesEncontradas = _repositorio.Pesquisar(termoPesquisa);

            if (seriesEncontradas.Count > 0)
            {
                Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados das séries encontrados:");
                for (var index = 0; index < seriesEncontradas.Count; index++)
                    Console.WriteLine($"{index} - {seriesEncontradas[index].Serie_Name}");

                if (!ushort.TryParse(Console.ReadLine(), out var indexAExibir) || indexAExibir >= seriesEncontradas.Count)
                {
                    Console.WriteLine($"Opção inválida! ");
                    return;
                }

                if (indexAExibir < seriesEncontradas.Count)
                {
                    var serie = seriesEncontradas[indexAExibir];

                    Console.WriteLine("Dados da Série");
                    Console.WriteLine($"Nome: {serie.Serie_Name}");
                    Console.WriteLine($"Lançamento Série: {serie.Lancamento:dd/MM/yyyy}");
                    Console.WriteLine($"Lançado à {serie.GetTempoLancamento()} ano(s).");
                    Console.WriteLine($"Nota: {serie.Nota}/10 ");

                }
            }
            else
            {
                Console.WriteLine($"Não foi encontrado nenhuma série!");
            }
        }
        void AdicionarTvShow()
        {
            ///SOLICITAR USUÁRIO QUE INFORME OS DADOS DA NOVA SÉRIE
            Console.WriteLine("Informe o nome da série que deseja adicionar:");
            var nome_Serie = Console.ReadLine();

            Console.WriteLine("Informe o lançamento da série (formato dd/MM/yyyy):");
            if (!DateTime.TryParse(Console.ReadLine(), out var lancamento_Serie))
            {
                Console.WriteLine($"Data inválida! Dados descartados! ");
                return;
            }
            Console.WriteLine("Informe uma nota para a série que deseja adicionar: ");
            Console.WriteLine("              <<<<< 0 até 10 >>>>>  Exemplo: 9,4");
            double nota_serie = Double.Parse(Console.ReadLine());

            Console.WriteLine("Os dados estão corretos?");
            Console.WriteLine($"Nome: {nome_Serie}");
            Console.WriteLine($"Lançamento: {lancamento_Serie:dd/MM/yyyy}");
            Console.WriteLine($"Nota: {nota_serie}/10");
            Console.WriteLine("1 - Sim \n2 - Não");

            var opcaoParaAdicionar = Console.ReadLine();
            if (opcaoParaAdicionar == "1")
            {
                ///ATRIBUIR INFORMAÇÕES OBTIDAS NO CONSOLE NA NOVA ENTIDADE
                _repositorio.Adicionar(new Serie(nome_Serie, lancamento_Serie, nota_serie, DateTime.Now.Date));

                Console.WriteLine($"Dados adicionados com sucesso!");
            }
            else if (opcaoParaAdicionar == "2")
            {
                Console.WriteLine($"Dados descartados! ");
            }
            else
            {
                Console.WriteLine($"Opção inválida! ");
            }
        }
        void AlterarTvShow()
        {
            Console.WriteLine("Informe o Nome da Série que deseja alterar:");
            var termoPesquisa = Console.ReadLine();
            var seriesEncontradas = _repositorio.Pesquisar(termoPesquisa);

            if (seriesEncontradas.Count > 0)
            {
                Console.WriteLine("Selecione uma das opções abaixo para visualizar os dados das séries encontrados:");
                for (var index = 0; index < seriesEncontradas.Count; index++)
                    Console.WriteLine($"{index} - {seriesEncontradas[index].Serie_Name}");

                if (!ushort.TryParse(Console.ReadLine(), out var indexAExibir) || indexAExibir >= seriesEncontradas.Count)
                {
                    Console.WriteLine($"Opção inválida! ");
                    return;
                }

                if (indexAExibir < seriesEncontradas.Count)
                {
                    var serie = seriesEncontradas[indexAExibir];

                    Console.WriteLine("Dados da Série");
                    Console.WriteLine($"Nome: {serie.Serie_Name}");
                    Console.WriteLine($"Lançamento Série: {serie.Lancamento:dd/MM/yyyy}");
                    Console.WriteLine($"Lançado à {serie.GetTempoLancamento()} ano(s).");
                    Console.WriteLine($"Nota: {serie.Nota}/10 ");

                    Alterar();
                    _repositorio.Alterar();

                }
            }
            else
            {
                Console.WriteLine($"Não foi encontrado nenhuma série!");
            }
        }

        void Alterar()
        {
            Console.WriteLine("Qual a nova nota para a série? ");
            double nota_serie_alter = Double.Parse(Console.ReadLine());
        }
        void ExcluirTvShow()
        {

        }
    }
}
