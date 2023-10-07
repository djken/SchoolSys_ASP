namespace SchoolSysMo.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public double Value { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

}
