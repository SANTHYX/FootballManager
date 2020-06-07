using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerApp.Models
{
    public class Training
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime BeginOf { get; set; }

        [Required]
        public DateTime EndOf { get; set; }

        [Required]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [Required]
        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; }
    }
}
