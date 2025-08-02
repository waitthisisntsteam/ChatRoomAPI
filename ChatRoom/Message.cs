using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class Message
    {
        public required string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public User? User { get; set; }

        public override string ToString()
        {
            return $"[{Timestamp.Hour}:{Timestamp.Minute}] {User.Username}: {Text}";
        }
    }
}
