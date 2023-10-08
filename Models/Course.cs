namespace SchoolSysMo.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Grade> Grades { get; set; } = new List<Grade>();


    }
}
