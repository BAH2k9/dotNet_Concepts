using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_Tutorial.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public PersonModel()
        {

        }

    }
}
