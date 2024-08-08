using System.ComponentModel.DataAnnotations;

namespace GameSerivce.Models
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

    }
}
