using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroupB_A2.Models;

public class Business
{
    public int ID { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Category is required")]
    public int CategoryID { get; set; }
    public Category Category { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
    public string NumberPhone { get; set; }
    public string Website { get; set; }
}