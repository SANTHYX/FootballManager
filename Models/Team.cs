using FootballManagerApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public TypesOfTeams TeamType { get; set; }

        public List<Player> Player { get; set; }
    }
}
