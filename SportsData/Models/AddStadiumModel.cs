﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportsData.Models
{
    public class AddStadiumModel
    {
        public int StadiumId { get; set; }

        [Required]
        [DisplayName("Име")]
        public string StadiumName { get; set; } = null!;
        [Required]
        [DisplayName("Капацитет")]
        public int Capacity { get; set; }
    }
}
