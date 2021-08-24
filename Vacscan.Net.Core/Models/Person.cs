using System;
using System.Collections.Generic;
using System.Text;

namespace Vacscan.Net.Core.Models
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
