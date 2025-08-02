
using Microsoft.AspNetCore.Mvc;
using ModelObjects;
using System.Net;

namespace ChatRoomAPI.Controllers
{
    public class ChatRoomController : ControllerBase
    {
        private static Dictionary<string, Chatroom> Chatrooms = new Dictionary<string, Chatroom>();
        private Chatroom EmptyChatroom = new Chatroom() { Messages = new HashSet<Message>(), Users = new HashSet<User>(), IsActive = false };
        private User EmptyUser = new User() { Username = string.Empty };

        // User Get Systems:
        [HttpGet("GetUser")]
        public User? GetUser(string chatRoomName, string userName)
            => Chatrooms[chatRoomName].Users.FirstOrDefault(u => u.Username == userName) ?? EmptyUser;
        [HttpGet("GetAllUsers")]
        public HashSet<User> GetAllUsers(string chatRoomName)
            => Chatrooms[chatRoomName].Users;
        // User Post Systems:
        [HttpPost("PostNewUser")]
        public User PostNewUser(string chatRoomName, string userName)
        {
            User user = new User() { Username = userName };
            Chatrooms[chatRoomName].Users.Add(user);
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
            Chatrooms[chatRoomName].Messages.Add(new Message() { Text = message, Timestamp = DateTime.Now, User = GetUser(chatRoomName, username) });
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
            Chatrooms.Add(chatRoomName, new Chatroom() { Messages = new(), Users = new(), IsActive = true });
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
