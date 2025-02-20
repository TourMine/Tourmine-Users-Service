using System.ComponentModel.DataAnnotations;

namespace Tourmine.Users.Application.Requests
{
    public class UpdateUserRequest
    {
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
