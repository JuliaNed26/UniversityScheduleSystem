using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityScheduleSystem.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Teachings = new List<Teaching>();
            Universities = new List<University>();
        }
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Rank { get; set; }
        public int? AudienceNumber { get; set; }
        public string? PhD { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
        public ICollection<University> Universities { get; set; }
    }
}