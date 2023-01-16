

using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [ApiController]
    [Route("DatingApp/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()// Asynchroniczne burger i kelner 
        {
            var users = await _context.Users.ToListAsync();

            return users;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>GetUser(int id)
        {
            return await _context.Users.FindAsync(id);

        }
    }
}