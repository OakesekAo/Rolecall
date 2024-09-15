using Business.DTOs;
using Business.Interfaces;
using Business.Entities;
using DataAccess.Interfaces;
using DataAccess.Entities;

namespace Business.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public async Task<BllServiceResponse> AddStudentAsync(StudentDTO studentDTO)
        {
            var student = new StudentEntity
            {
                Name = studentDTO.Name,
                Grade = studentDTO.Grade
            };

            // Call the repository method to add the student
            var response = await _studentRepository.AddAsync(student);
            return new BllServiceResponse(response.Flag, response.Message);
        }

        public async Task<BllServiceResponse> DeleteStudentAsync(int id)
        {
            var response = await _studentRepository.DeleteAsync(id);
            return new BllServiceResponse(response.Flag, response.Message);
        }

        public async Task<List<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAsync();

            var studentDTOs = students.Select(s => new StudentDTO
            {
                Id = s.Id,
                Name = s.Name,
                Grade = s.Grade
            }).ToList();

            return studentDTOs;
        }

        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);

            if (student != null)
            {
                return new StudentDTO
                {

                    Id = student.Id,
                    Name = student.Name,
                    Grade = student.Grade
                };
            }

            return null;
        }

        public async Task<BllServiceResponse> UpdateStudentAsync(StudentDTO studentDTO)
        {
            var student = new StudentEntity
            {
                Id = studentDTO.Id,
                Name = studentDTO.Name,
                Grade = studentDTO.Grade
            };

            var response = await _studentRepository.UpdateAsync(student);
            return new BllServiceResponse(response.Flag, response.Message);
        }
    }
}
