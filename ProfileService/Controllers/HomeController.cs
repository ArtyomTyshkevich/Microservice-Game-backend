using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileService.Data;
using ProfileService.Models;

namespace ProfileService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ProfileDbContext _profileDbContext;

        public HomeController(ProfileDbContext profileDbContext)
        {
            _profileDbContext = profileDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _profileDbContext.Users.ToListAsync();
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetById(string userId)
        {
            var user = await _profileDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            await _profileDbContext.Users.AddAsync(user);
            await _profileDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { userId = user.Id }, user);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Update(string userId, User user)
        {
            if (userId != user.Id)
            {
                return BadRequest();
            }

            _profileDbContext.Entry(user).State = EntityState.Modified;

            try
            {
                await _profileDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_profileDbContext.Users.Any(e => e.Id == userId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            var user = await _profileDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound();
            }

            _profileDbContext.Users.Remove(user);
            await _profileDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
