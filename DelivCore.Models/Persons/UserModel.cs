using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.Models.Core;

namespace DelivCore.Models.Persons
{
    public class UserModel: PersonModel
    {
        public string PersonType { get; set; }
    }
}
