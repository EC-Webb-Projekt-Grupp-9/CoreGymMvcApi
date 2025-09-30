using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dtos
{
    public class AddSessionDto
    {
        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Trainer { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public int Spots { get; set; }

    }
}
