using Tourmine.Users.Domain.Enums;

namespace Tourmine.Users.Application.Requests
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EUserType UserType { get; set; }
    }
}
