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
        private static Presentation _presentation = new Presentation();
        private static IPersonRepository _repository;

        public Controller(IPersonRepository personRepository)
        {
            _repository = personRepository;
        }
        public void menu()
        {
            int option;
            do
            {
                _presentation.listOptions();

                option = _presentation.consoleRead(0);
                switch (option)
                {
                    case 1:
                        getAll();
                        break;
                    case 2:
                        adicionarPessoa();
                        break;
                    case 3:
                        searchPeople();
                        break;
                    case 4:
                        updatePeople();
                        break;
                    case 5:
                        getTodayBirthdays();
                        break;
                    case 6:
                        removePerson();
                        break;

                    // Sair
                    case 7:
                        option = 8;
                        break;
                    default:
                        _presentation.verifiqueInfo();
                        option = 8;
                        break;
                }
                _presentation.pressAnyKey();
                _presentation.consoleRead();
            }
            while (option != 8);
        }
        private static void getAll()
        {
            var peopleFound = _repository.GetAll();

            if (peopleFound.Count > 0)
            {
                _presentation.consoleWriter("Selecione uma das opções abaixo para visualizar os dados das pessoas encontrados:");
                for (var index = 0; index < peopleFound.Count; index++)
                    _presentation.consoleWriter($"{index} - {peopleFound[index].showPerson()}");
                if (!ushort.TryParse(_presentation.consoleRead(), out var indexAExibir) || indexAExibir >= peopleFound.Count)
                {
                    _presentation.consoleWriter($"Opção inválida! ");
                    return;
                }

                if (indexAExibir < peopleFound.Count)
                {
                    var person = peopleFound[indexAExibir];
                    _presentation.consoleWriter(person.showPersonDetail());
                }
            }
            else
            {
                _presentation.consoleWriter($"Não foi encontrado nenhuma pessoa!");
            }
        }
        private static void getTodayBirthdays()
        {
            var peopleFound = _repository.TodayBirthday();

            if (peopleFound.Count > 0)
            {
                _presentation.consoleWriter("Selecione uma das opções abaixo para visualizar os dados das pessoas que fazem aniversário hoje:");
                for (var index = 0; index < peopleFound.Count; index++)
                    _presentation.consoleWriter($"{index} - {peopleFound[index].showPerson()}");
                if (!ushort.TryParse(_presentation.consoleRead(), out var indexAExibir) || indexAExibir >= peopleFound.Count)
                {
                    _presentation.consoleWriter($"Opção inválida! ");
                    return;
                }

                if (indexAExibir < peopleFound.Count)
                {
                    var person = peopleFound[indexAExibir];
                    _presentation.consoleWriter(person.showPersonDetail());
                }
            }
            else
            {
                _presentation.consoleWriter($"Não foi encontrado nenhuma pessoa!");
            }
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
                nome = _presentation.consoleRead();
                _presentation.consoleWriter("Digite o sobrenome da pessoa que deseja adicionar: ");
                sobrenome = _presentation.consoleRead();
                _presentation.consoleWriter("Digite a data de nascimento no formato dd/MM/yyyy: ");
                nascimento = DateTime.Parse(_presentation.consoleRead());
                _presentation.consoleWriter();
                _presentation.consoleWriter(new List<String>() {
                    "Os dados abaixo estão corretos?",
                    $"Nome: {nome} {sobrenome}",
                    $"Data de Aniversário: {nascimento}",
                    $"1 - Sim", $"2 - Não"
                });
                try
                {
                    ativo = _presentation.consoleRead(0);
                }
                catch
                {
                    _presentation.consoleWriter("Insira um número válido ou verifique se as informações estão no padrão correto.");
                }
            }
            _repository.Add(new Person(nome, sobrenome, nascimento));
            _presentation.consoleWriter($"Adicionado");
            _presentation.consoleWriter();
        }
        static void searchPeople()
        {
            _presentation.consoleWriter($"Informe o Nome da Pessoa que deseja pesquisar:");
            var searchQuery = _presentation.consoleRead();
            var peopleFound = _repository.FindByName(searchQuery);

            if (peopleFound.Count > 0)
            {
                _presentation.consoleWriter("Selecione uma das opções abaixo para visualizar os dados das pessoas encontrados:");
                for (var index = 0; index < peopleFound.Count; index++)
                    _presentation.consoleWriter($"{index} - {peopleFound[index].showPerson()}");
                if (!ushort.TryParse(_presentation.consoleRead(), out var indexAExibir) || indexAExibir >= peopleFound.Count)
                {
                    _presentation.consoleWriter($"Opção inválida! ");
                    return;
                }

                if (indexAExibir < peopleFound.Count)
                {
                    var person = peopleFound[indexAExibir];
                    _presentation.consoleWriter(person.showPersonDetail());
                }
            }
            else
            {
                _presentation.consoleWriter($"Não foi encontrado nenhuma pessoa!");
            }
        }
        void updatePeople()
        {
            _presentation.consoleWriter($"Informe o nome da Pessoa que deseja alterar:");
            var searchQuery = _presentation.consoleRead();
            var peopleFound = _repository.FindByName(searchQuery);

            if (peopleFound.Count > 0 && peopleFound.Count < 2)
            {
                _presentation.consoleWriter(peopleFound[0].showPersonDetail());


                var update = newPeople(peopleFound[0]);
                _repository.Update(peopleFound[0], update);
            }
            else
            {
                _presentation.consoleWriter($"Foi encontrada mais de uma pessoa com o mesmo nome ou não foi encontrada nenhuma!");
            }


        }
        private static Person newPeople(Person old)
        {
            List<String> details = old.showPersonRaw();
            int ativo = 2;

            string nome = "";
            string sobrenome = "";
            DateTime nascimento = new DateTime();

            while (ativo == 2)
            {
                nome = details[0];
                sobrenome = details[1];
                nascimento = DateTime.Parse(details[2]);
                _presentation.consoleWriter("Digite o novo valor, caso deseje manter o valor atual de um enter!");
                _presentation.consoleWriter($"Nome -{nome}- : ");
                nome = verifyLenght(_presentation.consoleRead());
                if (nome == "vazio")
                {
                    nome = details[0];
                }
                _presentation.consoleWriter($"Sobrenome -{sobrenome}- : ");
                sobrenome = verifyLenght(_presentation.consoleRead());
                if (sobrenome == "vazio")
                {
                    sobrenome = details[1];
                }
                _presentation.consoleWriter($"Data de Nascimento no formato dd/MM/yyyy -{nascimento}- : ");
                try
                {
                    nascimento = DateTime.Parse(_presentation.consoleRead());
                }
                catch
                {
                    _presentation.consoleWriter();
                }
                _presentation.consoleWriter();
                _presentation.consoleWriter(new List<String>() {
                    "Os dados abaixo estão corretos?",
                    $"Nome: {nome} {sobrenome}",
                    $"Data de Aniversário: {nascimento}",
                    $"1 - Sim", $"2 - Não"
                });
                try
                {
                    ativo = _presentation.consoleRead(0);
                }
                catch
                {
                    _presentation.consoleWriter("Insira um número válido ou verifique se as informações estão no padrão correto.");
                }
            }
            return new Person(nome, sobrenome, nascimento);
        }

        static string verifyLenght(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "vazio";
            }
            return s;
        }
        void removePerson()
        {
            _presentation.consoleWriter($"Informe o Nome da Pessoa que deseja remover:");
            var searchQuery = _presentation.consoleRead();
            var peopleFound = _repository.FindByName(searchQuery);

            if (peopleFound.Count > 0)
            {
                _presentation.consoleWriter("Selecione uma das opções abaixo para visualizar os dados das pessoas encontrados:");
                for (var index = 0; index < peopleFound.Count; index++)
                    _presentation.consoleWriter($"{index} - {peopleFound[index].showPerson()}");
                if (!ushort.TryParse(_presentation.consoleRead(), out var indexAExibir) || indexAExibir >= peopleFound.Count)
                {
                    _presentation.consoleWriter($"Opção inválida! ");
                    return;
                }

                if (indexAExibir < peopleFound.Count)
                {
                    var person = peopleFound[indexAExibir];
                    _presentation.consoleWriter(person.showPersonDetail());
                    _presentation.consoleWriter();
                    _presentation.consoleWriter("Deseja remover esta pessoa?");
                    _presentation.consoleWriter($"1 - Sim", $"2 - Não");
                    int ativo = _presentation.consoleRead(0);
                    if (ativo == 1)
                    {
                        _repository.Remove(person);
                    }
                }
            }
            else
            {
                _presentation.consoleWriter($"Não foi encontrado nenhuma pessoa!");
            }
        }

    }
}
