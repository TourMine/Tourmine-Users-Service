using Tourmine.Users.Domain.Entities;
using Tourmine.Users.Domain.Enums;
using Tourmine.Users.Domain.Validation;

namespace Domain.Tests;

public class UserTests
{
    [Fact]
    public void Should_Create_User_When_Valid_Data_Is_Provided()
    {
        var user = new User("John Doe", "john.doe@email.com", "securepassword", EUserType.Organizer);

        Assert.NotNull(user);
        Assert.Equal("John Doe", user.Name);
        Assert.Equal("john.doe@email.com", user.Email);
        Assert.Equal("securepassword", user.Password);
        Assert.Equal(EUserType.Organizer, user.UserType);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Should_Throw_Exception_When_Name_Is_Invalid(string invalidName)
    {
        var exception = Assert.Throws<DomainExceptionValidation>(() =>
            new User(invalidName, "john.doe@email.com", "securepassword", EUserType.Organizer));

        Assert.Equal("Invalid name. Name is required.", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Should_Throw_Exception_When_Email_Is_Invalid(string invalidEmail)
    {
        var exception = Assert.Throws<DomainExceptionValidation>(() =>
            new User("John Doe", invalidEmail, "securepassword", EUserType.Organizer));

        Assert.Equal("Invalid email. Email is required.", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Should_Throw_Exception_When_Password_Is_Invalid(string invalidPassword)
    {
        var exception = Assert.Throws<DomainExceptionValidation>(() =>
            new User("John Doe", "john.doe@email.com", invalidPassword, EUserType.Organizer));

        Assert.Equal("Invalid password. Password is required.", exception.Message);
    }

    [InlineData("12345")]
    public void Should_Throw_Exception_When_Password_Is_Too_Short(string shortPassword)
    {
        var exception = Assert.Throws<DomainExceptionValidation>(() =>
            new User("John Doe", "john.doe@email.com", shortPassword, EUserType.Organizer));

        Assert.Equal("Invalid password. Password is too short.", exception.Message);
    }
}
