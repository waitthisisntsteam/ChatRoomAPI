using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public static class ChatRoomApi
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

        public static async Task<User?> PostNewUser(string username)
        {
            string path = $"PostNewUser?userName={username}";
            var result = await Client.GetFromJsonAsync<User>(path);
            
            return result;
        }

        public static async Task<Message?> GetMessage(int index)
        {
            string path = $"GetMessage?index={index}";
            var result = await Client.GetFromJsonAsync<Message>(path);

            return result;
        }

        public static async Task<HttpResponseMessage> PostMessage(string message, string username)
        {
            string path = $"PostMessage?message={message}&username={username}";
            var result = await Client.PostAsync(path, null);

            return result;
        }
    }
}
