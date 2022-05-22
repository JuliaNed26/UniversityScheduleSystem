using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class Group
    {
        public Group()
        {
            Students = new List<Student>();
            Lessons = new List<Lesson>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}