using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Info { get; set; }
        public bool IsCompulsory { get; set; }
        [Required]
        public int CourseNum { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
    }
}