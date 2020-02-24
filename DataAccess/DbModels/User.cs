using System;
using System.Collections.Generic;

namespace DataAccess.DbModels
{
    public partial class User
    {
        public User()
        {
            Message = new HashSet<Message>();
        }

        public Guid PkUser { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Message> Message { get; set; }
    }
}
