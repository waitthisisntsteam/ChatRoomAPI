namespace ChatRoomAPI.Models
{
    public class Message
    {
        public required string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public User? User { get; set; }
    }
}
