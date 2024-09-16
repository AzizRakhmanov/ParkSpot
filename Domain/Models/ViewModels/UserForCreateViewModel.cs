using System.ComponentModel.DataAnnotations;

namespace ParkSpot.Models.ViewModels
{
    public class UserForCreateViewModel
    {
        [Required]
        [MinLength(2), MaxLength(100)]
        public string FirstName { get; set; }


        [Required]
        [MinLength(2), MaxLength(100)]
        public string LastName { get; set; }


        [Required]
        [MinLength(2), MaxLength(100)]
        public string MiddleName { get; set; }


        [Required]
        [MinLength(2), MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
