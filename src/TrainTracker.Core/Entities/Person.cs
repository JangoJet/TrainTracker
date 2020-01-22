using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainTracker.Core.Entities
{
    
    public class Person : IPerson
    {
        private int _Id;
        
        public int Id { get=> _Id; set =>_Id = value; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
