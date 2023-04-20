using SportsData.Constraints;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportsData.Models
{
    public class AddStadiumModel
    {
        [Required]
        [DisplayName("Име")]
        [MaxLength(GlobalConstraints.StadiumNameMax)]
        public string StadiumName { get; set; } = null!;

        [Required]
        [DisplayName("Капацитет")]
        [Range(1, GlobalConstraints.StadiumCapacityMax)]
        public int Capacity { get; set; }
    }
}
