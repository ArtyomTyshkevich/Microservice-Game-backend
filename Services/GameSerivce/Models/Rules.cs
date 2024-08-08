using GameSerivce.Enums;
using System.ComponentModel.DataAnnotations;

namespace GameSerivce.Models
{
    public class Rules
    {
        [Key]
        public Guid Id {  get; set; }
        public GameMove FirstPlayerMove { get; set; }
        public GameMove SecondPlayerMove { get; set; }
        public GameResult GameResults {  get; set; }
    }
}
