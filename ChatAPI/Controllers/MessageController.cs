using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace ChatAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;
        private readonly IMessageRepository _messageRepo;

        public MessageController(ILogger<MessageController> logger, IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MessageDto> Get()
        {
            var user = "Egor";
            return _messageRepo.GetMessages(user);
        }
    }
}
