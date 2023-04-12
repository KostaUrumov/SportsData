using SportsData.Constraints;
using SportsData.Data.Enm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsData.Data.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstraints.TeamNameMax)]
        public string? Name { get; set; }
        [Required]
        public SportName SportName { get; set; }

        [Required]
        [ForeignKey(nameof(Coach))]
        public int CoachID { get; set; }
        public virtual Coach Coach { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Stadium))]
        public int StadiumID { get; set; }
        public virtual Stadium Stadium { get; set; } = null!;

    }
}
