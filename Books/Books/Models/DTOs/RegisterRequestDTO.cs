using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Books.Models.DTOs
{
    public class RegisterRequestDTO
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
