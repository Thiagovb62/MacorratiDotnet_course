using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Name is required")]
        [MaxLength(100)]
        [MinLength(3)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Required (ErrorMessage = "Description is required")]
        [MaxLength(200)]
        [MinLength(5)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Required (ErrorMessage = "Price is required")]
        [Range(0.01, 9999.99, ErrorMessage = "Price must be between 0.01 and 9999.99")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        
    }
}