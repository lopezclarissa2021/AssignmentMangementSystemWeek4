using AssignmentManagement.API;
using AssignmentManagement.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Text;

namespace AssignmentManagement.APITests
{
    public class AssignmentAPITests : IClassFixture<WebApplicationFactory<AssignmentManagement.API.Program>>
    {
        private readonly HttpClient _client;

        public AssignmentAPITests(WebApplicationFactory<AssignmentManagement.API.Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Can_Create_Assignment()
        {
            var assignment = new Assignment("Test Task", "Description of task");
            var response = await _client.PostAsJsonAsync("/api/assignment", assignment);

            response.EnsureSuccessStatusCode(); // 201 Created
        }

        [Fact]
        public async Task Can_Get_Assignments()
        {
            var response = await _client.GetAsync("/api/assignment");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            Assert.Contains("title", json, StringComparison.OrdinalIgnoreCase); // crude check
        }
    }
}