using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
    }
}
