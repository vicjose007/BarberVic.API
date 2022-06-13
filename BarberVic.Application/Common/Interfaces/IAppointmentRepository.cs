using BarberVic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Common.Interfaces
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAllAppointments();

        Appointment CreateAppointment(Appointment appointment);

        Appointment DeleteAppointment(Appointment appointment);


    }
}