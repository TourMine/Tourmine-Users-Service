using Tourmine.Users.Domain.Enums;
using Tourmine.Users.Domain.Validation;

namespace Tourmine.Users.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EUserType UserType { get; set; }

        public User(string name, string email, string password, EUserType userType)
        {
            ValidateDomain(name, email, password);
            UserType = userType;
        }

        private void ValidateDomain(string name, string email, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                "Invalid email. Email is required.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(password),
                "Invalid password. Password is required.");

            DomainExceptionValidation.When(password.Length < 6,
                "Invalid password. Password is too short.");

            Name = name;
            Email = email;
            Password = password;
        }
    }
}
