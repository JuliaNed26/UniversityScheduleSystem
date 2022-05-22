using System.ComponentModel.DataAnnotations;

namespace UniversityScheduleSystem.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public int LessonNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? LessonLink { get; set; }
        public int? AudienceNumber { get; set; }
        public int TeachingId { get; set; }
        public Teaching Teaching { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string DayOfWeek { get; set; }
        public string Type { get; set; }
        public int? SubgroupNum { get; set; }

    }
}