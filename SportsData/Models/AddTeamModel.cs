using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportsData.Models
{
    public class AddTeamModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Спорт ИД между 0 и 6")]
        public int SportName { get; set; }
        [Required]
        [DisplayName("Треньор ИД")]
        public int Coach { get; set; }
        
        [Required]
        [DisplayName("Стадион ИД")]
        public int Stadium { get; set; }



    }
}
