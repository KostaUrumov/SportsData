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
        public string FirtsName { get; set; } = null!;
        [Required]
        [DisplayName("Фамилно име")]
        public string LastName { get; set; } = null!;

        [Required]
        [DisplayName("Възраст")]
        public int Age { get; set; }


    }
}
