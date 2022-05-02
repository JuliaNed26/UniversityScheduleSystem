using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class University
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
    }
}
