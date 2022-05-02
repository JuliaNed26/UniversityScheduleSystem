using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public int CuratorId { get; set; }
        public Teacher Curator { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}