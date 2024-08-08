using GameSerivce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileService.Data;

namespace GameService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly GameDbContext gameDbContext;

        public PlayerController(GameDbContext gameDbContext)
        {
            this.gameDbContext = gameDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Player>> GetUsers()
        {
            return await gameDbContext.Users.ToListAsync();
        }

    }
}
