using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivCore.BusinessLayer.UserService
{
    public interface IUserService
    {
        Task<List<string>> GetUserNames();
    }
}
