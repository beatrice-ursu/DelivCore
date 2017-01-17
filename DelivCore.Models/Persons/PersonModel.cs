using System.Collections.Generic;
using DelivCore.Models.Core;

namespace DelivCore.Models.Persons
{
    public class PersonModel: Model
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string PersonType { get; set; }

    }
}
