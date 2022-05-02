using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        [Required]
        public int LessonNumber { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public string? LessonLink { get; set; }
        public int? AudienceNumber { get; set; }
        public int TeachingId { get; set; }
        public Teaching Teaching { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        [Required]
        public string DayOfWeek { get; set; }
        [Required]
        public string Type { get; set; }
        public int? SubgroupNum { get; set; }

    }
}