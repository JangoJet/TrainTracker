using System;
using System.Collections.Generic;
using System.Text;
using TrainTracker.Core.Entities;
using TrainTracker.Core.Services;

namespace TrainTracker.Tests.Fakes
{
    public class FakeInMemoryPersonService : IPersonService
    {
        public IEnumerable<Person> GetPeople()
        {
            return new List<Person>() { new Person() { Id = 1, FirstName = "Geoff", LastName = "Norton" } };
        }
    }
}
