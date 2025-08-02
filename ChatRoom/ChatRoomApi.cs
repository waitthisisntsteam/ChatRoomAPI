using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChatRoom
{
    public static class ChatRoomApi
    {
        public static HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5150/") // Adjust the base address as needed
        };

        public static async Task<User?> GetUser(string chatRoomName, string username)
        {
            string path = $"GetUser?chatRoomName={chatRoomName}&userName={username}";
            var result = await Client.GetFromJsonAsync<User>(path);

            return result;
        }

        public static async Task<HttpResponseMessage> PostNewUser(string chatRoomName, string username)
        {
            string path = $"PostNewUser?chatRoomName={chatRoomName}&userName={username}";
            var result = await Client.PostAsync(path, null);

            return result;
        }

        public static async Task<Message?> GetMessage(string chatRoomName, int index)
        {
            string path = $"GetMessage?chatRoomName={chatRoomName}&index={index}";
            var result = await Client.GetFromJsonAsync<Message>(path);

            return result;
        }

        public static async Task<List<Message>> GetAllMessages(string chatRoomName)
        {
            string path = "GetAllMessages";
            var result = await Client.GetFromJsonAsync<List<Message>>(path);

            return result;
        }

        public static async Task<HttpResponseMessage> PostMessage(string chatRoomName, string message, string username)
        {
            string path = $"PostMessage?chatRoomName={chatRoomName}&message={message}&username={username}";
            var result = await Client.PostAsync(path, null);

            return result;
        }

        public static async Task<ChatRoom> GetChatroom(string chatRoomName)
        {
            string path = $"GetChatroom?chatRoomName={chatRoomName}";
            var result = await Client.GetFromJsonAsync<ChatRoom>(path);

            return result;
        }

        public static async Task<HttpResponseMessage> PostNewChatroom(string chatRoomName)
        {
            string path = $"PostNewChatroom?chatRoomName={chatRoomName}";
            var result = await Client.PostAsync(path, null);

            return result;
        }
    }
}
