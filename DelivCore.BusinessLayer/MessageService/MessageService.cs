using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DelivCore.DataLayer.Entities;
using DelivCore.DataLayer.Repositories.MessageRepository;
using DelivCore.Models.Core;
using DelivCore.Models.Persons;

namespace DelivCore.BusinessLayer.MessageService
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public IList<MessageModel> GetMessagesByUser(string username)
        {
            var messagesEntities = _messageRepository.GetAll().Where(x => x.PersonTo == username).OrderByDescending(x => x.CreatedOn);
            var messages = messagesEntities.Select(x => _mapper.Map<MessageModel>(x)).ToList();
            return messages;
        }

        public void SaveMessage(List<MessageModel> messageList, string currentUser)
        {
            messageList.Defaults(currentUser);
            var entities = messageList.Select(x => _mapper.Map<Message>(x)).ToList();

            foreach (var item in entities)
            {
                item.PersonFrom = currentUser;
                _messageRepository.Insert(item);
            }
 
            _messageRepository.SaveChanges();
        }

        public void DeleteMessage(int id)
        {
            var message = _messageRepository.GetById(id);
            _messageRepository.Delete(message);
            _messageRepository.SaveChanges();
        }

        public MessageModel GetById(int id)
        {
            var messageEntity = _messageRepository.GetById(id);

            return _mapper.Map<MessageModel>(messageEntity);
        }
    }
}
