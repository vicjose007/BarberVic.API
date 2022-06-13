using AutoMapper;
using BarberVic.Application.Common.Interfaces;
using BarberVic.Application.Dtos;
using BarberVic.Application.Services;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;
using BarberVic.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Infrastructure.Generic.Services
{

    public class AppointmentService : EntityCRUDService<Appointment, AppointmentDto>, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IMapper mapper, IUnitOfWork<IBarberVicDbContext> uow, IAppointmentRepository appointmentRepository)
            : base(mapper, uow)
        {
            _appointmentRepository = appointmentRepository;
        }
        public Appointment CreateAppointment(Appointment appointment)
        {
            _appointmentRepository.CreateAppointment(appointment);
            return appointment;
        }

        public Appointment DeleteAppointment(Appointment appointment)
        {
            _appointmentRepository.DeleteAppointment(appointment);
            return appointment;
        }
        public List<Appointment> GetAllAppointments()
        {
            var appointments = _appointmentRepository.GetAllAppointments();

            return appointments;
        }
    }
}