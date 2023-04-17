using SportsData.Constraints;
using System.ComponentModel.DataAnnotations;

namespace SportsData.Data.Models
{
    public class Stadium
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstraints.StadiumNameMax)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(GlobalConstraints.StadiumCapacityMax)]
        public int Capacity { get; set; }
    }
}
