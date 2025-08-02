using ChatRoomAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChatRoomAPI.Controllers
{
    public class ChatRoomController : ControllerBase
    {
        static Dictionary<string, ChatRoom> chatrooms = new Dictionary<string, ChatRoom>();

        // User Get Systems:
        [HttpGet("GetUser")]
        public User? GetUser(string chatRoomName, string userName)
            => chatrooms[chatRoomName].users.FirstOrDefault(u => u.Username == userName) ?? new User() { Username = string.Empty };

        // User Post Systems:
        [HttpPost("PostNewUser")]
        public User PostNewUser(string chatRoomName, string userName)
        {
            User user = new User() { Username = userName };
            chatrooms[chatRoomName].users.Add(user);
            return user;
        }

        // Message Get Systems:
        [HttpGet("GetMessage")]
        public Message GetMessage(string chatRoomName, int index)
            => chatrooms[chatRoomName].messages.ElementAtOrDefault(index) ?? new Message() { Text = "No message found", Timestamp = DateTime.Now, User = new User() { Username = string.Empty } };
        [HttpGet("GetAllMessages")]
        public List<Message> GetAllMessage(string chatRoomName)
            => chatrooms[chatRoomName].messages;


        //Message Post Systems:
        [HttpPost("PostMessage")]
        public HttpResponseMessage PostMessage(string chatRoomName, string message, string username)
        {
            chatrooms[chatRoomName].messages.Add(new Message() { Text = message, Timestamp = DateTime.Now, User = GetUser(chatRoomName, username) });
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        //Chatroom Get Systems:
        [HttpGet("GetChatroom")]
        public ChatRoom? GetChatroom(string chatRoomName)
            => !chatrooms[chatRoomName].Equals(null) ? chatrooms[chatRoomName] : null;
        

        //Chatroom Post Systems:
        [HttpPost("PostNewChatroom")]
        public HttpResponseMessage PostNewChatroom(string chatRoomName)
        {
            chatrooms.Add(chatRoomName, new ChatRoom());
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
