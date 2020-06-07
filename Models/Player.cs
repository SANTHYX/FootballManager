using FootballManagerApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [Range(0,int.MaxValue,ErrorMessage ="Wartość nie może być ujemna")]
        public int Goal { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Wartość nie może być ujemna")]
        public int Assist { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Wartość nie może być ujemna")]
        public int RedCard { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Wartość nie może być ujemna")]
        public int YellowCard { get; set; }

        [Required]
        public Position Position { get; set; }
    }
}
