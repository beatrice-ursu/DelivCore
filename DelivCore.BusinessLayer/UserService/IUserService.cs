using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.Models.Persons;

namespace DelivCore.BusinessLayer.UserService
{
    public interface IUserService
    {
        Task<List<string>> GetUserNames();
        Task<List<UserDropdownModel>> GetUsersList();
    }
}
