using System;
using System.Collections.Generic;
using System.Text;

namespace TrainTracker.Core.Entities
{
    
    public class Person : IPerson
    {
        private int _Id;

        public int Id { get=> _Id; set =>_Id = value; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
