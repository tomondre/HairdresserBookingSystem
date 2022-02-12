﻿using System.Threading.Tasks;
using Client.Models;

namespace API.Model.Appointments
{
    public interface IAppointmentModel
    {
        Task<Appointment> CreateAppointmentAsync(Appointment appointment2);
        Task<AppointmentList> GetAllCompanyAppointmentsAsync(int id);
        Task<Appointment> DeleteAppointmentAsync(int id);
    }
}