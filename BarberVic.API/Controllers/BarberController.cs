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
    public class BarberController : ControllerBase
    {
        public static Barber barber = new Barber();
        private readonly IConfiguration _configuration;
        private readonly IBarberService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly IImageService _imageService;
        private readonly BarberVicDbContext Context;



        public BarberController(IConfiguration configuration, IBarberService service, IHttpContextAccessor accessor, BarberVicDbContext dataContext, IImageService img)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;
            _imageService = img;

        }
        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Barber>>> Get()
        {
            return Ok(await Context.Barbers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Barber>> Get(int id)
        {
            var barber = await Context.Barbers.FindAsync(id);
            if (barber == null)
                return BadRequest("Barber not found");
            return Ok(barber);
        }

        [HttpPost]
        public async Task<ActionResult<List<Barber>>> AddBarbers([FromForm] BarberDto request)
        {

            barber.BarberName = request.BarberName;
            barber.BarberPhoto = await _imageService.Upload(request.BarberPhoto);
            barber.Experience = request.Experience;
            barber.StartDate = request.StartDate;

            PostBarber(barber);

            return Ok(barber);
        }

        private Barber PostBarber(Barber barber)
        {

            var barberFromService = _service.CreateBarber(barber);
            return barberFromService;
        }

        [HttpPut]
        public async Task<ActionResult<List<Barber>>> UpdateBarbers([FromForm] BarberDto request)
        {
            var barber = await Context.Barbers.FindAsync(request.Id);
            if (barber == null)
                return BadRequest("Barber not found.");


            barber.BarberName = request.BarberName;
            barber.BarberPhoto = await _imageService.Upload(request.BarberPhoto);
            barber.Experience = request.Experience;
            barber.StartDate = request.StartDate;


            await Context.SaveChangesAsync();

            return Ok(await Context.Barbers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Barber>>> Delete(int id)
        {
            var barber = await Context.Barbers.FindAsync(id);
            if (barber == null)
                return BadRequest("Barber not found");

            Context.Barbers.Remove(barber);
            await Context.SaveChangesAsync();
            return Ok(await Context.Barbers.ToListAsync());
        }
    }
}
