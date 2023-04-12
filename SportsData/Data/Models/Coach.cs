﻿using SportsData.Constraints;
using System.ComponentModel.DataAnnotations;

namespace SportsData.Data.Models
{
    public class Coach
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstraints.CoachNameMax)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstraints.CoachNameMax)]
        [MinLength(GlobalConstraints.CoachNameMin)]
        public string? LastName { get; set; }

        [Required]
        [MinLength(GlobalConstraints.CoachAgeMin)]
        [MaxLength(GlobalConstraints.CoachAgeMax)]
        public int Age { get; set; }
    }
}