using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class TeacherUniversity
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
    }
}
