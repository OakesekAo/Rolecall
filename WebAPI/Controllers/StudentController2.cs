using Business.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]

    public class StudentController2 : ControllerBase
    {
        private readonly IStudent student;

        public StudentController2(IStudent student)
        {
            this.student = student;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await student.GetAsync();
            return Ok(data);
        }

        [HttpGet("{id")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await student.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Student studentDto)
        {
            var result = await student.AddAsync(studentDto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Student studentDto)
        {
            var result = await student.UpdateAsync(studentDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await student.DeleteAsync(id);
            return Ok(result);
        }
    }
}
