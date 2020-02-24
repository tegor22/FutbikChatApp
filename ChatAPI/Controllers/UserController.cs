using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepo;
        public UserController(ILogger<UserController> logger, IUserRepository userRepo)
        {
            _userRepo = userRepo;
            _logger = logger;
        }

        [HttpPost]
        public UserDto GetAuthData([FromBody]UserDto user)
        {
            return _userRepo.GetAuthData(user);
        }
    }
}