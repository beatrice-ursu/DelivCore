using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.Models.Core;

namespace DelivCore.Models.Persons
{
    public class MessageModel: Model
    {
        public string MessageBody { get; set; }
        public string PersonTo { get; set; }
        public string PersonFrom { get; set; }
    }
}
