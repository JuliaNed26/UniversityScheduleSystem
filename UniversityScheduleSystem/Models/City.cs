using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityScheduleSystem.Models
{
    public class City
    {
        public City()
        {
            Universities = new List<University>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
        public ICollection<University> Universities { get; set; }
    }
}
