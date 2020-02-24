using System;

namespace Models
{
    public class MessageDto
    {
        public Guid MessageId { get; set; }
        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsOwn { get; set; }
    }
}
