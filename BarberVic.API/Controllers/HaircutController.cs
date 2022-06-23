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
    public class HaircutController : ControllerBase
    {
        public static Haircut haircut = new Haircut();
        private readonly IConfiguration _configuration;
        private readonly IHaircutService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly IImageService _imageService;
        private readonly BarberVicDbContext Context;



        public HaircutController(IConfiguration configuration, IHaircutService service, IHttpContextAccessor accessor, BarberVicDbContext dataContext, IImageService img)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;
            _imageService = img;

        }
        [HttpGet]
        public async Task<ActionResult<List<Haircut>>> Get()
        {
            return Ok(await Context.Haircuts.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Haircut>> Get(int id)
        {
            var haircut = await Context.Haircuts.FindAsync(id);
            if (haircut == null)
                return BadRequest("Haircut not found");
            return Ok(haircut);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Haircut>>> AddHaircuts([FromForm]HaircutDto request)
        {
        
            haircut.HaircutName = request.HaircutName;
            haircut.Photo = await _imageService.Upload(request.Photo);
            haircut.Price = request.Price;

            PostHaircut(haircut);

            return Ok(haircut);
        }

        private Haircut PostHaircut(Haircut haircut)
        {

            var haircutFromService = _service.CreateHaircut(haircut);
            return haircutFromService;
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Haircut>>> UpdateHaircuts(int id, [FromForm]HaircutDto request)
        {
            var haircut = await Context.Haircuts.FindAsync(id);
            if (haircut == null)
                return BadRequest("Haircut not found.");

            haircut.HaircutName = request.HaircutName;
            haircut.Photo = await _imageService.Upload(request.Photo);
            haircut.Price = request.Price;



            await Context.SaveChangesAsync();

            return Ok(await Context.Haircuts.ToListAsync());
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Haircut>>> Delete(int id)
        {
            var haircut = await Context.Haircuts.FindAsync(id);
            if (haircut == null)
                return BadRequest("Haircut not found");

            Context.Haircuts.Remove(haircut);
            await Context.SaveChangesAsync();
            return Ok(await Context.Haircuts.ToListAsync());
        }
    }
}
