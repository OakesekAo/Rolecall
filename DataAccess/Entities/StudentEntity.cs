using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Grade is required.")]
        public string? Grade { get; set; }
    }
}
