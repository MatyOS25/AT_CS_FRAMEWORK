using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace Presentation
{
    public class Presentation
    {
        public void listOptions()
        {
            consoleWriter("Selecione uma das opções abaixo:");
            consoleWriter("1 - Pesquisar pessoas");
            consoleWriter("2 - Adicionar nova pessoa");
            consoleWriter("3 - Sair");
        }
        public static void consoleWriter(string write)
        {
            Console.WriteLine(write);
        }
        public static void consoleWriter()
        {
            Console.WriteLine();
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
