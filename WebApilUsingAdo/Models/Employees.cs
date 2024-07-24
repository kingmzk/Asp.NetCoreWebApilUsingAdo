using System.ComponentModel.DataAnnotations;

namespace WebApilUsingAdo.Models
{
    public class Employees
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public String Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string City { get; set; }
    }
}
