using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Client
{
    public class Helper
    {
        public static string url  = "https://localhost:5003";

        public static async Task CheckException(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception( await response.Content.ReadAsStringAsync());
            }
        }

        public static T Deserialize<T>(string s)
        {
            var deserialize = JsonSerializer.Deserialize<T>(s, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }
        
        public static async Task<T> Deserialize<T>(HttpResponseMessage message)
        {
            var s = await message.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<T>(s, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public static string Serialize(object o)
        {
            var serialize = JsonSerializer.Serialize(o, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return serialize;
        }
        
        public static string Hash(string rawData) {  
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
  
                StringBuilder builder = new StringBuilder();  
                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  
                return builder.ToString();  
            }  
        }  
    }
}