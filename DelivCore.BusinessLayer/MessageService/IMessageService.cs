using System.Collections.Generic;
using System.Security.Principal;
using DelivCore.Models.Persons;

namespace DelivCore.BusinessLayer.MessageService
{
    public interface IMessageService
    {
        IList<MessageModel> GetMessagesByUser(string username);
        void SaveMessage(List<MessageModel> messageList, string currentUser);
        void DeleteMessage(int id);
        MessageModel GetById(int id);
    }
}