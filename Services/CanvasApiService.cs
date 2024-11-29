using CanvasRubricExporter.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace CanvasRubricExporter.Services
{
    public class CanvasApiService
    {
        private readonly RestClient _client;
        private readonly string _apiToken;

        public CanvasApiService(string baseUrl, string apiToken)
        {
            _client = new RestClient(baseUrl);
            _apiToken = apiToken;
        }

        public async Task<List<Assignment>> GetAssignmentsAsync(string courseId)
        {
            var request = new RestRequest($"/api/v1/courses/{courseId}/assignments", Method.Get);
            request.AddHeader("Authorization", $"Bearer {_apiToken}");

            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Error fetching assignments: {response.ErrorMessage}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var assignments = JsonSerializer.Deserialize<List<Assignment>>(response.Content, options);

            return assignments ?? new List<Assignment>();
        }

        public async Task<dynamic> GetRubricAsync(string rubricId)
        {
            var request = new RestRequest($"/api/v1/rubrics/{rubricId}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {_apiToken}");

            var response = await _client.ExecuteAsync<dynamic>(request);
            if (response.IsSuccessful && response.Data != null)
            {
                return response.Data;
            }

            throw new Exception($"Error fetching rubric: {response.ErrorMessage}");
        }

        public async Task<List<Module>> GetModulesAsync(string courseId)
        {
            var request = new RestRequest($"/api/v1/courses/{courseId}/modules", Method.Get);
            request.AddHeader("Authorization", $"Bearer {_apiToken}");
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Failed to fetch modules: {response.ErrorMessage}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var modules = JsonSerializer.Deserialize<List<Module>>(response.Content, options);

            return modules ?? new List<Module>();
        }

        public async Task<List<ModuleItem>> GetModuleItemsAsync(string courseId, string moduleId)
        {
            var request = new RestRequest($"/api/v1/courses/{courseId}/modules/{moduleId}/items", Method.Get);
            request.AddHeader("Authorization", $"Bearer {_apiToken}");
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Failed to fetch module items: {response.ErrorMessage}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var items = JsonSerializer.Deserialize<List<ModuleItem>>(response.Content, options);

            return items ?? new List<ModuleItem>();
        }

        public async Task<Rubric> GetRubricForAssignmentAsync(string courseId, string assignmentId)
        {
            var request = new RestRequest($"/api/v1/courses/{courseId}/assignments/{assignmentId}", Method.Get);
            request.AddHeader("Authorization", $"Bearer {_apiToken}");
            var response = await _client.ExecuteAsync(request);

            if (!response.IsSuccessful)
                throw new Exception($"Failed to fetch assignment {assignmentId}: {response.ErrorMessage}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var assignment = JsonSerializer.Deserialize<Assignment>(response.Content, options);

            if (assignment?.rubric != null && assignment.rubric.Count > 0)
            {
                var rubric = new Rubric
                {
                    title = assignment.rubric_settings?.title ?? assignment.name,
                    criteria = assignment.rubric
                };

                return rubric;
            }

            return null;
        }
    }
}
