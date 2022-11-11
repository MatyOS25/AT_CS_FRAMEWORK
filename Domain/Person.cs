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
        public void update(Person newOne)
        {
            Name = newOne.Name;
            Sobrenome = newOne.Sobrenome;
            Nascimento = newOne.Nascimento;
        }

        public List<String> showPersonDetail()
        {
            return new List<String>() {
                        "Dados da Pessoa",
                        $"Nome: {Name} {Sobrenome}",
                        $"Data de Nascimento: {Nascimento}",
                        $"{birthDay(Nascimento)}"
                    };
        }
        public List<String> showPersonRaw()
        {
            return new List<String>() {
                        $"{Name}",
                        $"{Sobrenome}",
                        $"{Nascimento}"
                    };
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
        public bool todayBirth()
        {
            if (birthDay(Nascimento) == "Essa Pessoa está fazendo aniversário!!")
            {
                return true;
            }
            return false;
        }

    }
}
