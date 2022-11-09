using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IPersonRepository
    {
        IList<Person> GetAll();
        IList<Person> FindAll();
        IList<Person> FindByName(string name);
        IList<Person> GetById(int id);
        void Add(Person person);
        void Save();
        void Remove(Person person);
        void Update(Person person);
        bool FirstRun();

    }
}
