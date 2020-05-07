using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.API.Database;
using Users.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Users.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> PostGroup([FromBody] User @user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(@user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = @user.Id }, @user);
        }
    }
}
