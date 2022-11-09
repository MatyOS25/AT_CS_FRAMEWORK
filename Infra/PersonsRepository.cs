using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain;

namespace Infra
{
    class PersonsRepository : IPersonRepository
    {
        private static List<Person> Persons = new List<Person>();


        public void Add(Person person)
        {
            throw new NotImplementedException();
        }

        public IList<Person> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Person> FindByName(string name)
        {
            var personsFound = Persons.Where(x => x.showPerson().ToLower().Contains(name.ToLower())).ToList();
            return personsFound;
        }

        public IList<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Person> GetById(int id)
        {
            var personsFound = Persons.Where(x => x.showPerson().Contains(id.ToString())).ToList();
            return personsFound;
        }

        public void Remove(Person person)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }
        public bool FirstRun()
        {
            throw new NotImplementedException();
        }
    }
}
