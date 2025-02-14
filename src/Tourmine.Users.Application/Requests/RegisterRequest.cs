using System.ComponentModel.DataAnnotations;
using Tourmine.Users.Domain.Enums;

namespace Tourmine.Users.Application.Requests
{
    public class RegisterRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EnumDataType(typeof(EUserType))]
        public EUserType UserType { get; set; }
    }
}
