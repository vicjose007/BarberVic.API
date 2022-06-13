using BarberVic.Application.Common.Interfaces;
using BarberVic.Application.Services;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public static List<Appointment> Appointments = new List<Appointment>()
        {

        };
        private readonly BarberVicDbContext _appointmentDbContext;

        public AppointmentRepository(BarberVicDbContext appointmentDbContext)
        {
            _appointmentDbContext = appointmentDbContext;
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            _appointmentDbContext.Appointments.Add(appointment);
            _appointmentDbContext.SaveChanges();
            return appointment;
        }

        public Appointment DeleteAppointment(Appointment appointment)
        {
            _appointmentDbContext.Appointments.Remove(appointment);
            _appointmentDbContext.SaveChanges();

            return null;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointmentDbContext.Appointments.ToList();
        }

    }
}
