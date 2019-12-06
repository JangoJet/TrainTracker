using System;
using System.Collections.Generic;
using System.Text;
using TrainTracker.Core.Entities;

namespace TrainTracker.Core.Services
{
    public class InMemoryPersonService : IPersonService
    {
        public IEnumerable<Person> GetPeople()
        {
            IEnumerable<Person> people = new List<Person>() { new Person() {Id=1, FirstName= "Geoff",  LastName="Norton"},
                                                                                         new Person() {Id=2, FirstName= "Alice",  LastName="Norton"},
                                                                                         new Person(){Id=3, FirstName="Elinor",LastName="Norton"},
                                                                                         new Person(){Id=4,FirstName="Sandra", LastName="Norton"}
            };

            return people;
        }
    }
}
