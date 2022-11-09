using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person
    {
        public Person(string name, string sobrenome, DateTime nascimento)
        {
            Id = Guid.NewGuid();
            Name = name;
            Sobrenome = sobrenome;
            Nascimento = nascimento;
        }
        private Guid Id { get; set; }
        private string Name { get; set; }
        private string Sobrenome { get; set; }
        private DateTime Nascimento { get; set; }

        public override string ToString()
        {
            return $"{Id};{Name};{Sobrenome};{Nascimento};{birthDay(Nascimento)}";
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

        private string birthDay(DateTime nascimento)
        {
            DateTime aniverAnoSeguinte = new DateTime(DateTime.Today.Year + 1, nascimento.Month, nascimento.Day);
            DateTime aniverAnoAtual = new DateTime(DateTime.Today.Year, nascimento.Month, nascimento.Day);
            DateTime diaAtual = DateTime.Today;

            int calcFuturo = aniverAnoSeguinte.Subtract(diaAtual).Days;
            int calcPresente = aniverAnoAtual.Subtract(diaAtual).Days;

            if (calcPresente > 0)
            {
                return $"Faltam {calcPresente} dias para esse aniversário";
            }
            else if (calcPresente < 0)
            {
                return $"Faltam {calcFuturo} dias para esse aniversário";
            }
            else
            {
                return $"Essa Pessoa está fazendo aniversário!!";
            }
        }

    }
}
