using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainTracker.Core.Entities;
using TrainTracker.Core.Services;

namespace TrainTracker.Tests.Fakes
{
    public class FakeInMemoryPersonService: IPersonService
    {
        private readonly List<Person> _people;

        public FakeInMemoryPersonService()
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
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
