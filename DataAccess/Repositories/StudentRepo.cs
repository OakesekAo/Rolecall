using Business.DTOs;
using Business.Entities;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StudentRepo : IStudent
    {
        private readonly AppDbContext appDbContext;

        public StudentRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ServiceResponse> AddAsync(Student student)
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

        public async Task<List<Student>> GetAsync()
        {
            return await appDbContext.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await appDbContext.Students.FindAsync(id);
        }

        public async Task<ServiceResponse> UpdateAsync(Student student)
        {
            appDbContext.Update(student);
            await appDbContext.SaveChangesAsync();
            return new ServiceResponse(true, "Updated");
        }

    }
}
