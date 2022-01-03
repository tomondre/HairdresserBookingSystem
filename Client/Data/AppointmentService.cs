using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Client.Models;

namespace Client.Data
{
    public class AppointmentService : IAppointmentService
    {
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
    }
}