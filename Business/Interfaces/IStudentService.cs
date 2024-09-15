using Business.DTOs;

namespace Business.Interfaces
{
    public interface IStudentService
    {
        Task<BllServiceResponse> AddStudentAsync(StudentDTO studentDTO);
        Task<BllServiceResponse> UpdateStudentAsync(StudentDTO studentDTO);
        Task<BllServiceResponse> DeleteStudentAsync(int id);
        Task<List<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
    }
}
