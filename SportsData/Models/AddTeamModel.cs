using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportsData.Models
{
    public class AddTeamModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("0 till 6")]
        public int SportName { get; set; }
        [Required]
        public int  Coach { get; set; }
        
        [Required]
        public int Stadium { get; set; }



    }
}
