using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int RegionId { get; set; }
        [Required]
        public Region Region { get; set; }
        public ICollection<University> Universities { get; set; }
    }
}
