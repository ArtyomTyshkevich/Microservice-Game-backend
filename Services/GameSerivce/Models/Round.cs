using GameSerivce.Enums;
using System.ComponentModel.DataAnnotations;

namespace GameSerivce.Models
{
    public class Round
    {
        [Key]
        public Guid Id { get; set; }
        public GameMove? FirstPlayerMove { get; set; } = null;
        public GameMove? SecondPlayerMove { get; set; } = null;
        public GameResult? GameResult { get; set; } = null;
        public Guid RoomId { get; set; }
    }
}
