using Business.DTOs;
using Business.Entities;
using System.Net.Http.Json;

namespace BlazorWasm.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient httpClient;

        public StudentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ServiceResponse> AddAsync(Student student)
        {
            var data = await httpClient.PostAsJsonAsync("api/student", student);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var data = await httpClient.DeleteAsync($"api/student/{id}");
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;

        }

        public async Task<List<Student>> GetAsync() =>
            await httpClient.GetFromJsonAsync<List<Student>>("api/student")!;

        public async Task<Student> GetByIdAsync(int id) =>
            await httpClient.GetFromJsonAsync<Student>($"api/student/{id}")!;

        public async Task<ServiceResponse> UpdateAsync(Student student)
        {
            var data = await httpClient.PutAsJsonAsync("api/student", student);
            var response = await data.Content.ReadFromJsonAsync<ServiceResponse>();
            return response!;
        }
    }
}
