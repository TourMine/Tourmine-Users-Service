using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.Requests;
using Tourmine.Users.WebAPI.Controllers;

namespace WebApi.Tests.Controllers
{
    public class UsersControllerTests
    {
        private readonly Faker _faker;
        private readonly UserController _controller;

        public UsersControllerTests()
        {
            _faker = new Faker();
            _controller = new UserController(); 
        }

        [Fact]
        public async Task Register_WhenCalled_ReturnsOK()
        {
            // Arrange
            var useCaseMock = new Mock<IRegisterUserUseCase>();
            var registerRequest = new RegisterRequest
            {
                Email = _faker.Internet.Email(),
                Password = _faker.Internet.Password()
            };

            var expectedResponse = true;

            useCaseMock.Setup(useCase => useCase.Execute(It.IsAny<RegisterRequest>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.Register(registerRequest, useCaseMock.Object);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.Equal(expectedResponse, returnValue);
        }
    }
}
