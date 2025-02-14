using System.ComponentModel.DataAnnotations;

namespace Tourmine.Users.Application.Requests
{
    public class ValidatePasswordRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
