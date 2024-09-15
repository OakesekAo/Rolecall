using Business.DTOs;
using Business.Entities;

namespace BlazorHybrid.Services
{
    public interface IStudentService
    {
        Task<BllServiceResponse> AddAsync(Student student);
        Task<BllServiceResponse> UpdateAsync(Student student);
        Task<BllServiceResponse> DeleteAsync(int id);
        Task<List<Student>> GetAsync();
        Task<Student> GetByIdAsync(int id);
    }
}
