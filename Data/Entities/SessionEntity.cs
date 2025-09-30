using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class SessionEntity
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Trainer { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Spots { get; set; }
    }
}
