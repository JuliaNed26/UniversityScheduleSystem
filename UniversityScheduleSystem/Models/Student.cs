using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? Surname { get; set; }
        [Required]
        public int Course { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}