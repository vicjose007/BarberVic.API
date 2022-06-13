using BarberVic.Application.Common.Interfaces;
using BarberVic.Application.Dtos;
using BarberVic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Common.Interfaces
{
    public interface IAppointmentService : IEntityCRUDService<Appointment, AppointmentDto>
    {
        List<Appointment> GetAllAppointments();

        Appointment CreateAppointment(Appointment appointment);

        Appointment DeleteAppointment(Appointment appointmentId);


    }
}

