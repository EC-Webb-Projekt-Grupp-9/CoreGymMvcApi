
using System.ComponentModel.DataAnnotations;

namespace Service.Dtos;

public class EditSessionDto
{
    public string Id { get; set; } = null!;

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public int Duration { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public string Trainer { get; set; } = null!;

    [Required]
    public string Location { get; set; } = null!;

    [Required]
    public int Spots { get; set; }
}
