using System.ComponentModel.DataAnnotations;

namespace MobileApplication.Manager.DTOs
{
    public class MobileSpecsDto
    {
            [Required]
            public int Id { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "RAM information can't be longer than 50 characters.")]
            public string RAM { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "Storage information can't be longer than 50 characters.")]
            public string Storage { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "CPU information can't be longer than 100 characters.")]
            public string CPU { get; set; }

            [StringLength(100, ErrorMessage = "Charging information can't be longer than 100 characters.")]
            public string Charging { get; set; }

            [StringLength(100, ErrorMessage = "Camera information can't be longer than 100 characters.")]
            public string Camera { get; set; }

            [StringLength(100, ErrorMessage = "Battery information can't be longer than 100 characters.")]
            public string Battery { get; set; }

            [StringLength(100, ErrorMessage = "Sensors information can't be longer than 100 characters.")]
            public string Sensors { get; set; }

            [Required]
            public int MobileInfoId { get; set; }

    }
}
