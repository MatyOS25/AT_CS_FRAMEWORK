using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person
    {
        private string Name { get; set; }
        private string Sobrenome { get; set; }
        private DateTime Nascimento { get; set; }

        public Person(string name, string sobrenome, DateTime nascimento)
        {
            Name = name;
            Sobrenome = sobrenome;
            Nascimento = nascimento;
        }


        public string showPerson()
        {
            return Name;
        }
        public void showPersonDetail()
        {
            Console.WriteLine();
            Console.WriteLine("Dados da pessoa:");
            Console.WriteLine($"Nome Completo: {Name} {Sobrenome}");
            Console.WriteLine($"Data do Aniversário: {Nascimento}");
            birthDay(Nascimento);

        }

        void birthDay(DateTime nascimento)
        {
            DateTime aniverAnoSeguinte = new DateTime(DateTime.Today.Year + 1, nascimento.Month, nascimento.Day);
            DateTime aniverAnoAtual = new DateTime(DateTime.Today.Year, nascimento.Month, nascimento.Day);
            DateTime diaAtual = DateTime.Today;

            int calcFuturo = aniverAnoSeguinte.Subtract(diaAtual).Days;
            int calcPresente = aniverAnoAtual.Subtract(diaAtual).Days;

            if (calcPresente > 0)
            {
                Console.WriteLine($"Faltam {calcPresente} dias para esse aniversário");
            }
            else if (calcPresente < 0)
            {
                Console.WriteLine($"Faltam {calcFuturo} dias para esse aniversário");
            }

            else
            {
                Console.WriteLine($"Essa Pessoa está fazendo aniversário!!");
            }
        }

    }
}
