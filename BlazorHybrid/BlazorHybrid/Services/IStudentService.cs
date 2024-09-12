using Business.DTOs;
using Business.Entities;

namespace BlazorHybrid.Services
{
    public interface IStudentService
    {
        Task<ServiceResponse> AddAsync(Student student);
        Task<ServiceResponse> UpdateAsync(Student student);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Student>> GetAsync();
        Task<Student> GetByIdAsync(int id);
    }
}
