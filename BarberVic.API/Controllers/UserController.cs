﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;
using BarberVic.Application.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using BarberVic.Application.Services;
using Microsoft.AspNetCore.Authorization;
using BarberVic.Application.Common.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BarberVic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserService _service;
        private readonly IHttpContextAccessor _accesor;
        private readonly BarberVicDbContext Context;



        public UserController(IConfiguration configuration, IUserService service, IHttpContextAccessor accessor, BarberVicDbContext dataContext)
        {
            Context = dataContext;
            _configuration = configuration;
            _service = service;
            _accesor = accessor;

        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromForm] UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);


            user.Name = request.Name;
            user.LastName = request.LastName;   
            user.Password = request.Password;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            PostUser(user);

            return Ok(user);
        }

        private User PostUser(User user)
        {

            var userFromService = _service.CreateUser(user);
            return userFromService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromForm] LoginDto request)
        {
            var userFind = _service.GetAllUsers().Where(x => x.Email == request.Email && x.Password == request.Password).FirstOrDefault();
            if (userFind is null)
            {
                return BadRequest("User not found.");
            }

            string token = CreateToken(userFind);

            return Ok(token);


        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.roles.ToString()),
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(

                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        [HttpGet,Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await Context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await Context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User not found");
            return Ok(user);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> AddUsers([FromForm] UserDto request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);


            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Password = request.Password;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.roles = request.roles;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            PostUser(user);

            return Ok(user);
        }

 
        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> UpdateUsers(int id, [FromForm]  UserDto request)
        {
            var user = await Context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User not found.");

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Password = request.Password;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.roles = request.roles;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;


            await Context.SaveChangesAsync();

            return Ok(await Context.Users.ToListAsync());
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var user = await Context.Users.FindAsync(id);
            if (user == null)
                return BadRequest("User not found");

            Context.Users.Remove(user);
            await Context.SaveChangesAsync();
            return Ok(await Context.Users.ToListAsync());
        }
    }
}
