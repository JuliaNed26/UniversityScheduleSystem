using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UniversityScheduleSystem.Models
{
    public class Region
    {
        public Region()
        {
            Cities = new List<City>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
