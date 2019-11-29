using System;
using System.Collections.Generic;
using System.Text;
using TrainTracker.Core.Entities;

namespace TrainTracker.Core.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPeople();
    }
}
