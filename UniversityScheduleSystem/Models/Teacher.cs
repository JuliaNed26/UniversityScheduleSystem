using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityScheduleSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Rank { get; set; }
        public int? AudienceNumber { get; set; }
        public string? PhD { get; set; }
        public ICollection<Group> GroupsWhereCourator { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
    }
}