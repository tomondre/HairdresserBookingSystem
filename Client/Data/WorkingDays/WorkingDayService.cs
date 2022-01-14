using System;
using System.Collections.Generic;
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
        
        public async Task<WorkingDayList> GetWorkingDayAsync(int companyId)
        {
            WorkingDayList list = new WorkingDayList();
            
            for (int i = 0; i < 5; i++)
            {
                WorkingDay workingDay = new WorkingDay();

                List<Appointment> appointments = new List<Appointment>()
                {
                    new Appointment
                    {
                        Start = DateTime.Today.AddDays(i).AddHours(7),
                        Product = new Product()
                        {
                            Name = "Pánsky Strih",
                            ProcedureLengthInMinutes = 90
                        }
                    },
                    new Appointment
                    {
                        Start = DateTime.Today.AddDays(i).AddHours(9),
                        Product = new Product()
                        {
                            Name = "Pánsky Strih",
                            ProcedureLengthInMinutes = 60
                        }
                    },
                    new Appointment
                    {
                        Start = DateTime.Today.AddDays(i).AddHours(10),
                        Product = new Product()
                        {
                            Name = "Dámsky Strih",
                            ProcedureLengthInMinutes = 60
                        }
                    },
                    new Appointment
                    {
                        Start = DateTime.Today.AddDays(i).AddHours(11),
                        Product = new Product()
                        {
                            Name = "Pánsky Strih",
                            ProcedureLengthInMinutes = 60
                        }
                    }
                };
                workingDay.Appointments = appointments;

                workingDay.Start = DateTime.Today.AddDays(i);
                workingDay.End = DateTime.Today.AddDays(i).AddDays(1);
                
                list.Days.Add(workingDay);
            }

            return list;
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
    }
}