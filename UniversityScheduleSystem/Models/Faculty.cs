using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class Faculty
    {
        public Faculty()
        {
            Groups = new List<Group>();
            Teachings = new List<Teaching>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
    }
}
