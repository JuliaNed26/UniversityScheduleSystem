using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class University
    {
        public University()
        {
            Faculties = new List<Faculty>();
            Teachers = new List<Teacher>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}
