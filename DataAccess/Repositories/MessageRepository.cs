using DataAccess.DbModels;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly FutbikDbContext _db;
        public MessageRepository(FutbikDbContext db)
        {
            _db = db;
        }
        public IEnumerable<MessageDto> GetMessages(string owner)
        {
            return _db.Message.Include(s => s.FkUserNavigation).Select(p => new MessageDto { 
                MessageId = p.PkMessage,
                Author = p.FkUserNavigation.Name,
                Message = p.Message1,
                CreatedAt = p.CreatedAt,
                IsOwn = owner == p.FkUserNavigation.Name
            });
        }
    }
}
