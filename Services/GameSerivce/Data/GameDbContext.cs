using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using GameSerivce.Models;
using GameSerivce.Enums;


namespace ProfileService.Data
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {      
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DbSet<Player> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Rules> Rules { get; set; }
        public DbSet<Round> Rounds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Создание начальных данных для Room и Round
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = Guid.NewGuid(), RoomStatus = RoomStatus.ReadyToPlay },
                new Room { Id = Guid.NewGuid(), RoomStatus = RoomStatus.ReadyToPlay },
                new Room { Id = Guid.NewGuid(), RoomStatus = RoomStatus.ReadyToPlay }
            );

            // Получаем идентификаторы Room, чтобы использовать их при инициализации Round
            var roomIds = modelBuilder.Entity<Room>().Metadata.GetSeedData().Select(data => (Guid)data["Id"]).ToList();

            modelBuilder.Entity<Round>().HasData(
                new Round { Id = Guid.NewGuid(), FirstPlayerMove = null, SecondPlayerMove = null, GameResult = null, RoomId = roomIds[0] },
                new Round { Id = Guid.NewGuid(), FirstPlayerMove = null, SecondPlayerMove = null, GameResult = null, RoomId = roomIds[0] },
                new Round { Id = Guid.NewGuid(), FirstPlayerMove = null, SecondPlayerMove = null, GameResult = null, RoomId = roomIds[0] },

                new Round { Id = Guid.NewGuid(), FirstPlayerMove = null, SecondPlayerMove = null, GameResult = null, RoomId = roomIds[1] },
                new Round { Id = Guid.NewGuid(), FirstPlayerMove = null, SecondPlayerMove = null, GameResult = null, RoomId = roomIds[1] },
                new Round { Id = Guid.NewGuid(), FirstPlayerMove = null, SecondPlayerMove = null, GameResult = null, RoomId = roomIds[1] },

                new Round { Id = Guid.NewGuid(), FirstPlayerMove = null, SecondPlayerMove = null, GameResult = null, RoomId = roomIds[2] },
                new Round { Id = Guid.NewGuid(), FirstPlayerMove = null, SecondPlayerMove = null, GameResult = null, RoomId = roomIds[2] },
                new Round { Id = Guid.NewGuid(), FirstPlayerMove = null, SecondPlayerMove = null, GameResult = null, RoomId = roomIds[2] }
            );

            // Создание начальных данных для Rules
            modelBuilder.Entity<Rules>().HasData(
                new Rules { Id = Guid.NewGuid(), FirstPlayerMove = GameMove.Rock, SecondPlayerMove = GameMove.Scissors, GameResults = GameResult.Win },
                new Rules { Id = Guid.NewGuid(), FirstPlayerMove = GameMove.Scissors, SecondPlayerMove = GameMove.Paper, GameResults = GameResult.Win },
                new Rules { Id = Guid.NewGuid(), FirstPlayerMove = GameMove.Paper, SecondPlayerMove = GameMove.Rock, GameResults = GameResult.Win },

                new Rules { Id = Guid.NewGuid(), FirstPlayerMove = GameMove.Scissors, SecondPlayerMove = GameMove.Rock, GameResults = GameResult.Loss },
                new Rules { Id = Guid.NewGuid(), FirstPlayerMove = GameMove.Paper, SecondPlayerMove = GameMove.Scissors, GameResults = GameResult.Loss },
                new Rules { Id = Guid.NewGuid(), FirstPlayerMove = GameMove.Rock, SecondPlayerMove = GameMove.Paper, GameResults = GameResult.Loss },

                new Rules { Id = Guid.NewGuid(), FirstPlayerMove = GameMove.Rock, SecondPlayerMove = GameMove.Rock, GameResults = GameResult.Draw },
                new Rules { Id = Guid.NewGuid(), FirstPlayerMove = GameMove.Paper, SecondPlayerMove = GameMove.Paper, GameResults = GameResult.Draw },
                new Rules { Id = Guid.NewGuid(), FirstPlayerMove = GameMove.Scissors, SecondPlayerMove = GameMove.Scissors, GameResults = GameResult.Draw }
            );
        }
    }
}
