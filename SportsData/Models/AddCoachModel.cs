using Microsoft.AspNetCore.Mvc;
using SportsData.Constraints;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportsData.Models
{
    public class AddCoachModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Първо име")]

        [MaxLength(GlobalConstraints.CoachNameMax)]
        [MinLength(GlobalConstraints.CoachNameMin)]
        public string FirtsName { get; set; } = null!;


        [Required]
        [DisplayName("Фамилно име")]
        [MaxLength(GlobalConstraints.CoachNameMax)]
        [MinLength(GlobalConstraints.CoachNameMin)]

        public string LastName { get; set; } = null!;

        [Required]
        [DisplayName("Възраст")]
        [Range(GlobalConstraints.CoachAgeMin, GlobalConstraints.CoachAgeMax)]
        public int Age { get; set; }


    }
}
