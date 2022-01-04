using System;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Client
{
    public class Helper
    {
        public static string url  = "https://localhost:5003";

        public static void CheckException(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.Content.ToString());
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

        public static string Serialize(object o)
        {
            var serialize = JsonSerializer.Serialize(o, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return serialize;
        }
    }
}