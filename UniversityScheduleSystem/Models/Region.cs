using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class Region
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
