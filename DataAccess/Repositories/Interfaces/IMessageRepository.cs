using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<MessageDto> GetMessages(string owner);
    }
}
