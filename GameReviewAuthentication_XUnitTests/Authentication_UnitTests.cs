using GameReviewAuthentication_Data.Dtos;
using GameReviewAuthentication_Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameReviewAuthentication_XUnitTests
{
    public class Authentication_UnitTests
    {
        //[Fact]
        //[Theory]
        //[InlineData()]

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetUserById_UserDoesExist(int id)
        {
            // Arrange
            AuthenticationMemoryContext context = new AuthenticationMemoryContext();

            // Act
            LoginDto user = context.GetUserById(id);

            // Assert
            Assert.NotNull(user);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void GetUserById_UserDoesNotExist(int id)
        {
            // Arrange
            AuthenticationMemoryContext context = new AuthenticationMemoryContext();

            // Act
            LoginDto user = context.GetUserById(id);

            // Assert
            Assert.Null(user);
        }

        [Theory]
        [InlineData("Padoru", "umu!")]
        [InlineData("test", "test")]
        public void GetUserByInput_UserDoesExist(string username, string password)
        {
            // Arrange
            AuthenticationMemoryContext context = new AuthenticationMemoryContext();

            // Act
            LoginDto user = context.GetUserByInput(username, password);

            // Assert
            Assert.NotNull(user);
        }

        [Theory]
        [InlineData("User", "User")]
        [InlineData("lol", "lol")]
        public void GetUserByInput_UserDoesNotExist(string username, string password)
        {
            // Arrange
            AuthenticationMemoryContext context = new AuthenticationMemoryContext();

            // Act
            LoginDto user = context.GetUserByInput(username, password);

            // Assert
            Assert.Null(user);
        }

        [Theory]
        [InlineData("Excalibur", "Morgan")]
        [InlineData("test", "test")]
        public void CreateUser_XUnitTest(string username, string password)
        {
            // Arrange
            AuthenticationMemoryContext context = new AuthenticationMemoryContext();
            LoginDto user = new LoginDto(username, password);

            // Act
            context.CreateUser(user);
            LoginDto newUser = context.mockDb.Find(a => a.Username == user.Username && a.Password == user.Password);

            // Assert
            Assert.NotNull(newUser);
        }

        [Theory]
        [InlineData(1, "Padoru", "umu")]
        [InlineData(2, "test123", "test")]
        public void UpdateUser_XUnitTest(int userId, string username, string password)
        {
            // Arrange
            AuthenticationMemoryContext context = new AuthenticationMemoryContext();
            LoginDto user = new LoginDto(userId, username, password);

            // Act
            context.UpdateUser(user);
            LoginDto updatedUser = context.mockDb.Find(a => a.UserId == user.UserId &&
                                                            a.Username == user.Username &&
                                                            a.Password == user.Password);

            // Assert
            Assert.NotNull(updatedUser);
        }
    }
}
