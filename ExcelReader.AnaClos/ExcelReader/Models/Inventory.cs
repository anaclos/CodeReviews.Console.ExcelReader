using System.ComponentModel.DataAnnotations;
namespace ExcelReader.Models;

public class Inventory
{
    public int Id { get; set; }
    [Required]
    public string Product { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public double Price { get; set; }
}
