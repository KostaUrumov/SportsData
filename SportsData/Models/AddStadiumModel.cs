using System.ComponentModel.DataAnnotations;

namespace SportsData.Models
{
    public class AddStadiumModel
    {
        public int StadiumId { get; set; }

        [Required]
        public string StadiumName { get; set; } = null!;
        [Required]
        public int Capacity { get; set; }
    }
}
