

using System.ComponentModel.DataAnnotations;

namespace Business.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Grade is required.")]
        public string? Grade { get; set; }
    }
}
