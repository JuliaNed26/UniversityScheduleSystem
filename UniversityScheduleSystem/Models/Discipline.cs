using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class Discipline
    {
        public Discipline()
        {
            Teachings = new List<Teaching>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Info { get; set; }
        public bool IsCompulsory { get; set; }
        public int CourseNum { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
    }
}