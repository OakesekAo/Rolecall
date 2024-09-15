using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponse> AddAsync(StudentEntity student)
        {
            var check = await appDbContext.Students
                .FirstOrDefaultAsync(c => c.Name.ToLower() == student.Name.ToLower());
            if (check != null)
                return new ServiceResponse(false, "User already exists");

           appDbContext.Students.Add(student);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Added");
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var student = await appDbContext.Students.FindAsync(id);
            if (student == null)
                return new ServiceResponse(false, "User not found");
            appDbContext.Students.Remove(student);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }

        public async Task<List<StudentEntity>> GetAsync()
        {
            return await appDbContext.Students.AsNoTracking().ToListAsync();
        }

        public async Task<StudentEntity> GetByIdAsync(int id)
        {
            return await appDbContext.Students.FindAsync(id);
        }

        public async Task<ServiceResponse> UpdateAsync(StudentEntity student)
        {
            appDbContext.Update(student);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }

    }
}
