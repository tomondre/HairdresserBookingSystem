using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Client.Models;

namespace Client.Data.WorkingDays
{
    public class WorkingDayService : IWorkingDayService
    {

        private HttpClient client;

        public WorkingDayService(HttpClient client)
        {
            this.client = client;
        }
        
        public async Task<WorkingDayList> GetWorkingDayListAsync(int companyId)
        {
            var httpResponseMessage = await client.GetAsync($"{Helper.url}/companies/{companyId}/workingdays");
            await Helper.CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var workingDay = Helper.Deserialize<WorkingDayList>(readAsStringAsync);
            return workingDay;
        }

        public async Task<WorkingDay> CreateWorkingDayAsync(WorkingDay model)
        {
            var serialize = Helper.Serialize(model);
            var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync($"{Helper.url}/workingdays", stringContent);
            await Helper.CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var workingDay = Helper.Deserialize<WorkingDay>(readAsStringAsync);
            return workingDay;
        }

        public async Task<WorkingDay> DeleteWorkingDay(int workingDayId)
        {
            var httpResponseMessage = await client.DeleteAsync($"{Helper.url}/WorkingDays/{workingDayId}");
            await Helper.CheckException(httpResponseMessage);
            var workingDay = await Helper.Deserialize<WorkingDay>(httpResponseMessage);
            return workingDay;
        }
    }
}