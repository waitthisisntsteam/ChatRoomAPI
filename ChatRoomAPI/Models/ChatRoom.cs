namespace ChatRoomAPI.Models
{
    public class ChatRoom
    {
        public List<Message> messages = new List<Message>();
        public List<User> users = new List<User>();
    }
}
