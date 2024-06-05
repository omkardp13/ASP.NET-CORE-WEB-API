using System;
using System.ComponentModel.DataAnnotations;
using CustomValidationExample.Validators;

namespace CustomValidationExample.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }

        [ReleaseDateInFuture]
        public DateTime ReleaseDate { get; set; }
    }
}
