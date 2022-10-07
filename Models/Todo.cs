using System.ComponentModel.DataAnnotations;
namespace _net.Models;

public class Todo
{

    public int Id { get; set; }
    [Required]
    public string? Titulo { get; set; }
    public bool Done { get; set; }

}