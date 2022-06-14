using AutoMapper;
using BarberVic.Application.Dtos;
using BarberVic.Application.Extensions;
using BarberVic.Domain.Entities;

namespace BarberVic.Application.Mappings
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            this._CreateMap_WithConventions_FromAssemblies<User, UserDto>();
            this._CreateMap_WithConventions_FromAssemblies<Appointment, AppointmentDto>();
            this._CreateMap_WithConventions_FromAssemblies<Barber, BarberDto>();
            this._CreateMap_WithConventions_FromAssemblies<Haircut, HaircutDto>();
        }
    }
}

