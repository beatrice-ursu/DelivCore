using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.Models.Persons;

namespace DelivCore.BusinessLayer.ClientService
{
    public interface IClientService
    {
        IList<ClientModel> GetAll();
    }
}
