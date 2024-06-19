using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileService.Data;
using ProfileService.Models;

namespace ProfileService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProfileDbContext profileDbContext;
        public HomeController(ProfileDbContext profileDbContext)
        {
            this.profileDbContext = profileDbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await profileDbContext.Users.ToListAsync();
            return users;
        }
        [HttpGet("{UserId:string}")]
        public async Task<User> GetById(string UserId)
        {
            var user = await profileDbContext.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            return user;
        }
        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            await profileDbContext.Users.AddAsync(user);
            await profileDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(User user)
        {
            profileDbContext.Users.Update(user);
            await profileDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{UserId:string}")]
        public async Task<ActionResult> Delete(string UserId)
        {
            var user = await profileDbContext.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            profileDbContext.Users.Remove(user);
            return Ok();
        }
    }
}
