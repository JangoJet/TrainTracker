using System;
using System.Collections.Generic;
using System.Text;
using TrainTracker.Core.Entities;

namespace TrainTracker.Core.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();

        Person FindById(int Id);
        void Create(Person person);
        void Remove(int id, Person person);
        void Update(Person person);
    }
}
