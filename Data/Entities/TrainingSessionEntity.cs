using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities;

public class TrainingSessionEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public string Location { get; set; } = null!;
    public int Spots { get; set; }
    public string Trainer { get; set; } = null!;
}
