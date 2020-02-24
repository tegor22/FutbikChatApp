using System;
using System.Collections.Generic;

namespace DataAccess.DbModels
{
    public partial class Message
    {
        public Guid PkMessage { get; set; }
        public Guid FkUser { get; set; }
        public string Message1 { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual User FkUserNavigation { get; set; }
    }
}
