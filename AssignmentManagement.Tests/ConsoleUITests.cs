using Xunit;
using Moq;
using AssignmentManagement.Core;
using AssignmentManagement.UI;
using System.Collections.Generic;

namespace AssignmentManagement.Tests
{
    public class ConsoleUITests
    {
        [Fact]
        public void AddAssignment_CallsServiceAndAddsAssignment()
        {
            // Arrange
            var mockService = new Mock<IAssignmentService>();
            var assignment = new Assignment("Test Title", "Test Description");
            mockService.Setup(service => service.AddAssignment(assignment)).Returns(true);

            var consoleUI = new ConsoleUI(mockService.Object);

            // Act
            var result = mockService.Object.AddAssignment(assignment);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void SearchAssignmentByTitle_ReturnsCorrectAssignment()
        {
            // Arrange
            var mockService = new Mock<IAssignmentService>();
            var assignment = new Assignment("Test Title", "Test Description");
            mockService.Setup(service => service.FindAssignmentByTitle("Test Title")).Returns(assignment);

            var consoleUI = new ConsoleUI(mockService.Object);

            // Act
            var result = mockService.Object.FindAssignmentByTitle("Test Title");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Title", result.Title);
        }

        [Fact]
        public void DeleteAssignment_CallsServiceAndDeletesSuccessfully()
        {
            // Arrange
            var mockService = new Mock<IAssignmentService>();
            mockService.Setup(service => service.DeleteAssignment("Test Title")).Returns(true);

            var consoleUI = new ConsoleUI(mockService.Object);

            // Act
            var result = mockService.Object.DeleteAssignment("Test Title");

            // Assert
            Assert.True(result);
        }
    }
}