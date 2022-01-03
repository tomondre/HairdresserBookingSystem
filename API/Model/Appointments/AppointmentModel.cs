﻿using System.Threading.Tasks;
using API.Persistence.Appointments;
using Client.Models;

namespace API.Model.Appointments
{
    public class AppointmentModel : IAppointmentModel
    {
        private IAppointmentDao dao;

        public AppointmentModel(IAppointmentDao dao)
        {
            this.dao = dao;
        }

        public Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            return dao.CreateAppointmentAsync(appointment);
        }
    }
}