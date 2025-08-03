
using Microsoft.AspNetCore.Mvc;
using ModelObjects;
using System.Net;

namespace ChatRoomAPI.Controllers
{
    public class ChatRoomController : ControllerBase
    {
        private static Dictionary<string, Chatroom> Chatrooms = new Dictionary<string, Chatroom>();
        private static HashSet<User> Users = new HashSet<User>();

        private Chatroom EmptyChatroom = new Chatroom() { Messages = new HashSet<Message>(), Users = new HashSet<User>(), IsActive = false, RoomType = 0 };
        private User EmptyUser = new User() { Username = string.Empty, Password = string.Empty };

        // User Get Systems:
        [HttpGet("GetUser")]
        public User? GetUser(string userName)
            => Users.FirstOrDefault(u => u.Username == userName) ?? EmptyUser;
        [HttpGet("GetAllUsers")]
        public HashSet<User> GetAllUsers(string chatRoomName)
            => Chatrooms[chatRoomName].Users;
        // User Post Systems:
        [HttpPost("PostNewUser")]
        public User PostNewUser(string userName, string password)
        {
            User user = new User() { Username = userName, Password = password};
            Users.Add(user);
            return user;
        }

        // Message Get Systems:
        [HttpGet("GetAllMessages")]
        public HashSet<Message> GetAllMessages(string chatRoomName)
            => Chatrooms[chatRoomName].Messages;
        //Message Post Systems:
        [HttpPost("PostMessage")]
        public HttpResponseMessage PostMessage(string chatRoomName, string message, string username)
        {
            Chatrooms[chatRoomName].Messages.Add(new Message() { Text = message, Timestamp = DateTime.Now, User = GetUser(username) });
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //Chatroom Get Systems:
        [HttpGet("GetChatroom")]
        public Chatroom? GetChatroom(string chatRoomName)
            => Chatrooms.ContainsKey(chatRoomName) ? Chatrooms[chatRoomName] : EmptyChatroom;
        //Chatroom Post Systems:
        [HttpPost("PostNewChatroom")]
        public HttpResponseMessage PostNewChatroom(string chatRoomName)
        {
            Chatrooms.Add(chatRoomName, new Chatroom() { Messages = new(), Users = new(), RoomType = Chatroom.RoomTypes.Server, IsActive = true });
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost("PostNewDirectMessages")]
        public HttpResponseMessage PostNewDirectMessages(string chatRoomName, string user1, string user2)
        {
            Chatrooms.Add(chatRoomName, new Chatroom() { Messages = new(), Users = new(), RoomType = Chatroom.RoomTypes.DirectMessages, IsActive = true });
            Chatrooms.Last().Value.Users.Add(GetUser(user1));
            Chatrooms.Last().Value.Users.Add(GetUser(user2));
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
