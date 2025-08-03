namespace ModelObjects
{
    public class Chatroom
    {
        public required HashSet<Message> Messages { get; set; }
        public required HashSet<User> Users { get; set; } //only for Direct Messages type
        public required RoomTypes RoomType { get; set; }
        public required bool IsActive { get; set; } //check for if its an existent chatroom

        public enum RoomTypes
        {
            Server = 0,
            DirectMessages = 1
        };
    }
}
