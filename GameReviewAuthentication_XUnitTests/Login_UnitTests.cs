using GameReviewAuthentication_Data.DTOs;
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
        [InlineData("Padoru", "umu!")]
        public void GetUserByInput_UserDoesExists(string username, string password)
        {
            // Arrange
            AuthenticationMemoryContext mockDb = new AuthenticationMemoryContext();

            // Act
            LoginDTO user = mockDb.GetUserByInput(username, password);

            // Assert
            Assert.NotNull(user);
        }

        [Theory]
        [InlineData("User", "User")]
        public void GetUserByInput_UserDoesNotExists(string username, string password)
        {
            // Arrange
            AuthenticationMemoryContext mockDb = new AuthenticationMemoryContext();

            // Act
            LoginDTO user = mockDb.GetUserByInput(username, password);

            // Assert
            Assert.Null(user);
        }
    }
}
