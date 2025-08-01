using ChatRoomAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ChatRoomAPI.Controllers
{
    public class ChatRoomController : ControllerBase
    {
        static List<Message> messages = new List<Message>();
        static List<User> users = new List<User>();

        // User Get Systems:
        [HttpGet("GetUser")]
        public User? GetUser(string userName) => users.FirstOrDefault(u => u.Username == userName) ?? new User() { Username = string.Empty };

        // User Post Systems:
        [HttpPost("PostNewUser")]
        public User PostNewUser(string userName)
        {
            User user = new User() { Username = userName};
            users.Add(user);
            return user;
        }
        //[HttpPost("DeleteUser")]
        //public void DeleteUser(string userName) => users.Remove(GetUser(userName));

        // Message Get Systems:
        [HttpGet("GetMessage")]
        public Message GetMessages(int index)
        {
            return messages.ElementAtOrDefault(index) ?? new Message() { Text = "No message found", Timestamp = DateTime.Now, User = null};
        }

        //Message Post Systems:
        [HttpPost("PostMessage")]
        public HttpResponseMessage PostMessage(string message, string username)
        { 
            messages.Add(new Message() { Text = message, Timestamp = DateTime.Now, User = GetUser(username) }); 

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
