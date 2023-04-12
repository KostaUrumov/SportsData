using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportsData.Models
{
    public class AddTeamModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [DisplayName("Спорт ИД между 0 и 6")]
        public string SportName { get; set; } = null!;

        [Required]
        [DisplayName("Треньор ИД")]
        public int Coach { get; set; }
        
        [Required]
        [DisplayName("Стадион ИД")]
        public int Stadium { get; set; }



    }
}
