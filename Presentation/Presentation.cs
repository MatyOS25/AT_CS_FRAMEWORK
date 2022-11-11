using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace Presentation
{
    public class Presentation
    {
        private const string pressioneQualquerTecla = "Pressione qualquer tecla para exibir o menu principal...";
        public void listOptions()
        {
            consoleWriter("Selecione uma das opções abaixo:");
            consoleWriter("1 - Listar pessoas");
            consoleWriter("2 - Adicionar nova pessoa");
            consoleWriter("3 - Pesquisar por nome");
            consoleWriter("4 - Alterar cadastro");
            consoleWriter("5 - Aniversariantes do dia");
            consoleWriter("6 - Remover Pessoa");
            consoleWriter("7 - Sair");
        }
        public void pressAnyKey()
        {
            consoleWriter(pressioneQualquerTecla);
        }
        public void consoleWriter(string write)
        {
            Console.WriteLine(write);
        }
        public void consoleWriter()
        {
            Console.WriteLine();
        }
        public void consoleWriter(string write1, string write2)
        {
            consoleWriter(write1);
            consoleWriter(write2);
        }
        public void consoleWriter(List<String> lista)
        {
            foreach (String str in lista)
            {
                consoleWriter(str);
            }
        }
        public void verifiqueInfo()
        {
            consoleWriter("Insira um número válido ou verifique se as informações estão no padrão correto.");
        }
        public string consoleRead()
        {
            return Console.ReadLine();
        }
        public int consoleRead(int fake)
        {
            return Int32.Parse(Console.ReadLine());
        }
        public void pesquisarPessoas(IList<Person> pessoas)
        {
            consoleWriter();
            consoleWriter("Pessoas Adicionadas:");
            foreach (Person pessoa in pessoas)
            {
                consoleWriter($"{pessoas.IndexOf(pessoa)} - {pessoa.showPerson()}");
            }
            consoleWriter();
            consoleWriter("Escreva o index para obter mais detalhes: ");
            try
            {
                Person pessoaDetail = pessoas[Int32.Parse(Console.ReadLine())];
                pessoaDetail.showPersonDetail();
                consoleWriter();
                consoleWriter();
            }
            catch
            {
                consoleWriter("Insira um número válido");
            }

        }

    }
}
