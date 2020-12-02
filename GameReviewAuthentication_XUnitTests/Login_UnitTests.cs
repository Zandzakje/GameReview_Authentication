using GameReviewAuthentication_Data.Dtos;
using GameReviewAuthentication_Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GameReviewAuthentication_XUnitTests
{
    public class Login_UnitTests
    {
        //[Fact]
        //[Theory]
        //[InlineData()]

        // Arrange
        // Act
        // Assert

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetUserById_UserDoesExist(int userId)
        {
            // Arrange
            AuthenticationMemoryContext mockDb = new AuthenticationMemoryContext();

            // Act
            LoginDto user = mockDb.GetUserById(userId);

            // Assert
            Assert.NotNull(user);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void GetUserById_UserDoesNotExist(int userId)
        {
            // Arrange
            AuthenticationMemoryContext mockDb = new AuthenticationMemoryContext();

            // Act
            LoginDto user = mockDb.GetUserById(userId);

            // Assert
            Assert.Null(user);
        }

        [Theory]
        [InlineData("Padoru", "umu!")]
        [InlineData("Test", "test123")]
        public void GetUserByInput_UserDoesExist(string username, string password)
        {
            // Arrange
            AuthenticationMemoryContext mockDb = new AuthenticationMemoryContext();

            // Act
            LoginDto user = mockDb.GetUserByInput(username, password);

            // Assert
            Assert.NotNull(user);
        }

        [Theory]
        [InlineData("User", "User")]
        [InlineData("lol", "lol")]
        public void GetUserByInput_UserDoesNotExist(string username, string password)
        {
            // Arrange
            AuthenticationMemoryContext mockDb = new AuthenticationMemoryContext();

            // Act
            LoginDto user = mockDb.GetUserByInput(username, password);

            // Assert
            Assert.Null(user);
        }
    }
}
