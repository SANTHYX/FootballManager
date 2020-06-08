using FootballManagerApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Models
{
    public class Match
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Versus { get; set; }

        [Required]
        public TypeOfMatches MachType { get; set; }

        [Required]
        public DateTime DateOfMatch { get; set; }

        [Required]
        public int TeamId { get; set; }

        public Team Team { get; set; }
    }
}
