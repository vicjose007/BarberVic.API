using BarberVic.Application.Common.Interfaces;
using BarberVic.Application.Dtos;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberVic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        public static Appointment appointment = new Appointment();
        private readonly IConfiguration _configuration;
        private readonly IAppointmentService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly BarberVicDbContext Context;



        public AppointmentController(IConfiguration configuration, IAppointmentService service, IHttpContextAccessor accessor, BarberVicDbContext dataContext)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;

        }
        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Appointment>>> Get()
        {
            return Ok(await Context.Appointments.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> Get(int id)
        {
            var appointment = await Context.Appointments.FindAsync(id);
            if (appointment == null)
                return BadRequest("Appointment not found");
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult<List<Appointment>>> AddAppointments(AppointmentDto request)
        {
            var user = await Context.Users.FindAsync(request.UserId);
            if (user == null)
                return BadRequest("User not found.");

            var newAppointment = new Appointment
            {
                User = user,
                BarberId = request.BarberId,
                HaircutId = request.HaircutId,
                BarberName = request.BarberName,
                Date = request.Date,


            };

            PostAppointment(newAppointment);

            return Ok(newAppointment);
        }

        private Appointment PostAppointment(Appointment appointment)
        {

            var appointmentFromService = _service.CreateAppointment(appointment);
            return appointmentFromService;
        }

        [HttpPut]
        public async Task<ActionResult<List<Appointment>>> UpdateAppointments(AppointmentDto request)
        {
            var appointment = await Context.Appointments.FindAsync(request.Id);
            if (appointment == null)
                return BadRequest("Appointment not found.");

            appointment.UserId = request.UserId;
            appointment.BarberId = request.BarberId;
            appointment.HaircutId = request.HaircutId;
            appointment.BarberName = request.BarberName;
            appointment.Date = request.Date;


            await Context.SaveChangesAsync();

            return Ok(await Context.Appointments.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Appointment>>> Delete(int id)
        {
            var appointment = await Context.Appointments.FindAsync(id);
            if (appointment == null)
                return BadRequest("Appointment not found");

            Context.Appointments.Remove(appointment);
            await Context.SaveChangesAsync();
            return Ok(await Context.Appointments.ToListAsync());
        }
    }
}
