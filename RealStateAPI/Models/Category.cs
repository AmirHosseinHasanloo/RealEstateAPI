using System.ComponentModel.DataAnnotations;

namespace RealStateAPI.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Display(Name = "Real State Name")]
    [Required(ErrorMessage = "Please enter the {0}")]
    [MaxLength(200, ErrorMessage = "The field {0} do not exceed a maximum length {1}")]
    public string Name { get; set; }
    [Display(Name = "Image Url")]
    [Required(ErrorMessage = "Please enter the {0}")]
    [MaxLength(200, ErrorMessage = "The field {0} do not exceed a maximum length {1}")]
    public string ImageUrl { get; set; }
}