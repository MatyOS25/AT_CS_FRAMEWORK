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
                        searchPeople();
                        break;
                    case 2:
                        adicionarPessoa();
                        break;
                    case 3:
                        break;
                    default:
                        _presentation.verifiqueInfo();
                        option = 5;
                        break;
                }
                _presentation.pressAnyKey();
                _presentation.consoleRead();
            }
            while (option != 5);
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
            _presentation.consoleWriter($"Informe o Nome da Série que deseja pesquisar:");
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
            _presentation.consoleWriter($"Informe o Nome da Série que deseja alterar:");
            var searchQuery = _presentation.consoleRead();
            var peopleFound = _repository.FindByName(searchQuery);

            if (peopleFound.Count > 0 && peopleFound.Count < 2)
            {
                _presentation.consoleWriter(peopleFound[0].showPersonDetail());


                var update = newPeople();
                _repository.Update(peopleFound[0], update);
            }
            else
            {
                _presentation.consoleWriter($"Foi encontrada mais de uma pessoa com o mesmo nome ou não foi encontrada nenhuma!");
            }


        }
        private static Person newPeople()
        {
            string nome = "";
            string sobrenome = "";
            DateTime nascimento = new DateTime();
            int ativo = 2;

            while (ativo == 2)
            {
                _presentation.consoleWriter("Digite o novo valor, caso contrário de um enter!");
                _presentation.consoleWriter("Nome: ");
                nome = _presentation.consoleRead();
                _presentation.consoleWriter("Sobrenome: ");
                sobrenome = _presentation.consoleRead();
                _presentation.consoleWriter("Data de Nascimento no formato dd/MM/yyyy: ");
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
            return new Person(nome, sobrenome, nascimento);
        }
        void ExcluirTvShow()
        {

        }

    }
}
