using System.ComponentModel.DataAnnotations;

namespace Dottor16DvdRental.Web.models;

public class Actor
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(45)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(45)]
    public string LastName { get; set; }
    public DateTime LastUpdate { get; set; }
}
