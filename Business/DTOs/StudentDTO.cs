using System.ComponentModel.DataAnnotations;


namespace Business.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; } // Include ID for updates

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; } // Non-nullable string

        [Required(ErrorMessage = "Grade is required.")]
        public string? Grade { get; set; } // Non-nullable string

    }
}
