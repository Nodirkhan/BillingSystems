using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Billing.UserApi.Domains.Models
{
    public class UserDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int Position { get; set; }

        public List<string> Permission { get; set; }

        public string Role { get; set; }

    }
}
