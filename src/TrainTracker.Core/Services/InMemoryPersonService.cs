using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainTracker.Core.Entities;

namespace TrainTracker.Core.Services
{
    public class InMemoryPersonService : IPersonService
    {
        private readonly List<Person> _people;

        public InMemoryPersonService()
        {
            _people = new List<Person>() { new Person() {Id=1, FirstName= "Geoff",  LastName="Norton"}};
        
        }

        public IEnumerable<Person> GetAll()
        {
            return _people;
        }
        public void Create(Person person)
        {
            _people.Add(person);
        }

        public Person FindById(int Id)
        {
            return _people.Where(p => p.Id == Id).FirstOrDefault();
        }

        public void Remove(int id, Person person)
        {
            _people.Remove(person);
        }

        public void Update(Person person)
        {
            var personToUpdate = FindById(person.Id);
            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.Email = person.Email;
        }
    }
}
