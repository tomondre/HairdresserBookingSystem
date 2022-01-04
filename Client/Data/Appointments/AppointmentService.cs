using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Data.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private HttpClient client;

        public AppointmentService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            var serialize = Helper.Serialize(appointment);
            var content = new StringContent(serialize, Encoding.UTF8, "application/json");
            var post = await client.PostAsync($"{Helper.url}/Appointments", content);
            Helper.CheckException(post);
            var readAsStringAsync = await post.Content.ReadAsStringAsync();
            var deserialize = Helper.Deserialize<Appointment>(readAsStringAsync);
            return deserialize;
        }
    }
}