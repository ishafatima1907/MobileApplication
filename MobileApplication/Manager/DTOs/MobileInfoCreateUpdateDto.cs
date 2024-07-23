using System.ComponentModel.DataAnnotations;

namespace MobileApplication.Manager.DTOs
{
    public class MobileInfoCreateUpdateDto
    {
            [Required]
            [StringLength(100, ErrorMessage = "Brand name can't be longer than 100 characters.")]
            public string BrandName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Model name can't be longer than 100 characters.")]
            public string ModelName { get; set; }

            [Range(1900, 2100, ErrorMessage = "Year of make must be between 1990 and 2100.")]
            public int YearOfMake { get; set; }

            [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
            public decimal Price { get; set; }
        
    }
}
