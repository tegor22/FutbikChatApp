using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class UserDto
    {
        public Guid? UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
