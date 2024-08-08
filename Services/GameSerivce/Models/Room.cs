using GameSerivce.Enums;
using System.ComponentModel.DataAnnotations;

namespace GameSerivce.Models
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }
        public Player? FirstPlayers { get; set; } = null;
        public Player? LastPlayers { get; set; } = null;
        public Round[] Rounds { get; set; } = new Round[3];
        public RoomStatus RoomStatus { get; set; }
    }
}
