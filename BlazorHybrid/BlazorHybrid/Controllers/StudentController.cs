using Business.DTOs;
using Business.Entities;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorHybrid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService student;

        public StudentController(IStudentService student)
        {
            this.student = student;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await student.GetAllStudentsAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await student.GetStudentByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentDTO studentDto)
        {
            var result = await student.AddStudentAsync(studentDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StudentDTO studentDto)
        {
            var result = await student.UpdateStudentAsync(studentDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await student.DeleteStudentAsync(id);
            return Ok(result);
        }
    }
}

