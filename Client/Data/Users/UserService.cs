using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Shared.Models;

namespace Client.Data.Users
{
    public class UserService : IUserService
    {
        private HttpClient client;

        public UserService(HttpClient client)
        {
            this.client = client;
        }
        
        public async Task<User> TryLoginUserAsync(User user)
        {
            var serialize = Helper.Serialize(user);
            var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
            var postAsync = await client.PostAsync($"{Helper.url}/login", stringContent);
            Helper.CheckException(postAsync);
            var readAsStringAsync = await postAsync.Content.ReadAsStringAsync();
            var deserialize = Helper.Deserialize<User>(readAsStringAsync);
            return deserialize;
        }
    }
}