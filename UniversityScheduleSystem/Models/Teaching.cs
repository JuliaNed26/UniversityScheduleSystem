namespace UniversityScheduleSystem.Models
{
    public class Teaching
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
