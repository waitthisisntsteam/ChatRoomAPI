using Microsoft.VisualBasic.ApplicationServices;
using ModelObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Message = ModelObjects.Message;
using User = ModelObjects.User;

namespace ChatRoom
{
    public static class ChatRoomAPIHandler
    {
        public static HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5150/") // Adjust the base address as needed
        };

        public static async Task<User?> GetUser(string username)
        {
            string path = $"GetUser?userName={username}";
            var result = await Client.GetFromJsonAsync<User>(path);

            return result;
        }

        public static async Task<HttpResponseMessage> PostNewUser(string username, string password)
        {
            string path = $"PostNewUser?userName={username}&password={password}";
            var result = await Client.PostAsync(path, null);

            return result;
        }

        public static async Task<HashSet<Message>?> GetAllMessages(string chatRoomName)
        {
            string path = $"GetAllMessages?chatRoomName={chatRoomName}";
            var result = await Client.GetFromJsonAsync<HashSet<Message>>(path);

            return result;
        }

        public static async Task<HttpResponseMessage> PostMessage(string chatRoomName, string message, string username)
        {
            string path = $"PostMessage?chatRoomName={chatRoomName}&message={message}&username={username}";
            var result = await Client.PostAsync(path, null);

            return result;
        }

        public static async Task<Chatroom?> GetChatroom(string chatRoomName)
        {
            string path = $"GetChatroom?chatRoomName={chatRoomName}";
            var result = await Client.GetFromJsonAsync<Chatroom>(path);

            return result;
        }

        public static async Task<HttpResponseMessage> PostNewChatroom(string chatRoomName)
        {
            string path = $"PostNewChatroom?chatRoomName={chatRoomName}";
            var result = await Client.PostAsync(path, null);

            return result;
        }

        public static async Task<HttpResponseMessage> PostNewDirectMessages(string chatRoomName, string user1, string user2)
        {
            string path = $"PostNewDirectMessages?chatRoomName={chatRoomName}&user1={user1}&user2={user2}";
            var result = await Client.PostAsync(path, null);

            return result;
        }
    }
}
