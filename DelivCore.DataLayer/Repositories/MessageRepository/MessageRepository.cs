using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelivCore.DataLayer.DbContext;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.GenericRepository;

namespace DelivCore.DataLayer.Repositories.MessageRepository
{
    public class MessageRepository: GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(DelivCoreDbContext context) : base(context)
        {
        }
    }
}
