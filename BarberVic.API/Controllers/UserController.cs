using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberVic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BarberVicDbContext Context;
        private readonly User? user;

        public UserController(BarberVicDbContext dataContext)
        {
            Context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await Context.User.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await Context.User.FindAsync(id);
            if (user == null)
                return BadRequest("User not found");
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUsers(User user)
        {
            Context.User.Add(user);
            await Context.SaveChangesAsync();

            return Ok(await Context.User.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUsers(User request)
        {
            var user = await Context.User.FindAsync(request.Id);
            if (user == null)
                return BadRequest("User not found.");

            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Phone = request.Phone;
            user.roles = request.roles;


            await Context.SaveChangesAsync();

            return Ok(await Context.User.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var user = await Context.User.FindAsync(id);
            if (user == null)
                return BadRequest("User not found");

            Context.User.Remove(user);
            await Context.SaveChangesAsync();
            return Ok(await Context.User.ToListAsync());
        }
    }
}
