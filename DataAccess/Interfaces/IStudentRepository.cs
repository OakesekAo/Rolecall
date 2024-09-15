using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IStudentRepository
    {
        Task<ServiceResponse> AddAsync(StudentEntity student);
        Task<ServiceResponse> UpdateAsync(StudentEntity student);
        Task<ServiceResponse> DeleteAsync(int id);
        Task<List<StudentEntity>> GetAsync();
        Task<StudentEntity> GetByIdAsync(int id);
    }
}
