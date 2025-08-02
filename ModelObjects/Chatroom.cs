namespace ModelObjects
{
    public class Chatroom
    {
        public required HashSet<Message> Messages { get; set; }
        public required HashSet<User> Users { get; set; }
        public required bool IsActive { get; set; }
    }
}
