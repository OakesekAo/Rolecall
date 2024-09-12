using Business.DTOs;
using Business.Entities;

namespace DataAccess.Repositories
{
    public interface IStudent
    {
        Task<ServiceResponse> AddAsync(Student student);
        Task<ServiceResponse> UpdateAsync(Student student);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<Student>> GetAsync();
        Task<Student> GetByIdAsync(int id);
    }
}
