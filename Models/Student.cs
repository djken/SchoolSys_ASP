﻿namespace SchoolSysMo.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
