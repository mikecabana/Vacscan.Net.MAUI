using System;

namespace Vacscan.Net.Core.Immunization.Identity
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
