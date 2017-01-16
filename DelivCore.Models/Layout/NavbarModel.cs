using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.Models.Persons;

namespace DelivCore.Models.Layout
{
    public class NavbarModel
    {
        public int AcceptedToday { get; set; }
        public int ProcessedToday { get; set; }
        public string UserLoggedIn { get; set; }
        public IList<MessageModel> Messages { get; set; }
    }
}
