using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain;

namespace Infra
{
    public sealed class PersonsRepository : IPersonRepository
    {
        //private static List<Person> Persons = new List<Person>();
        private static LinkedList<Person> pessoas = new LinkedList<Person>();


        public void Add(Person person)
        {
            pessoas.AddLast(person);
            Save();
        }

        public IList<Person> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<Person> FindByName(string name)
        {
            var personsFound = pessoas.Where(x => x.showPerson().ToLower().Contains(name.ToLower())).ToList();
            return personsFound;
        }

        public IList<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Person> GetById(int id)
        {
            var personsFound = pessoas.Where(x => x.showPerson().Contains(id.ToString())).ToList();
            return personsFound;
        }

        public void Remove(Person person)
        {
            pessoas.Remove(person);
        }

        public void Save()
        {
            string path = Environment.CurrentDirectory + @"\text.txt";
            if (File.Exists(path))
                File.Delete(path);
            var colecaoListS = pessoas.Select(x => x.ToString());
            File.WriteAllLines(path, colecaoListS);
        }

        public void Update(Person person,Person updated)
        {
            var toChange = pessoas.Find(person);
            try
            {
                toChange.Value.update(updated);
                Save();
            }
            catch
            {
                Console.WriteLine("Error on Update");
            }

        }
        public void FirstRun()
        {
            Console.WriteLine("Populating Repo....");
            Console.WriteLine();
            string path = Environment.CurrentDirectory + @"\text.txt";
            if (File.Exists(path))
            {
                var OrderLines = File.ReadAllLines(path).ToList();
                char[] delimiters = { ';' };
                foreach (var line in OrderLines.Select(OrderLine => OrderLine.Split(delimiters)).Select(parts =>
                new Person(
                    Convert.ToString(parts[1]),
                    Convert.ToString(parts[2]),
                    DateTime.Parse(parts[3])
                )
                ))
                {
                    Add(line);
                }

            }
            else
            {
                return;
            }
        }
    }
}
