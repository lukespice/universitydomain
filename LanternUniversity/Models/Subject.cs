using System;
using System.Collections.Generic;

namespace LanternUniversity.Models
{
    public class Subject : IIdentifier
    {
        public Subject()
        {
            EnroledStudents = new List<Student>();
            Lectures = new List<Lecture>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<Lecture> Lectures { get; private set; }

        public IList<Student> EnroledStudents { get; private set; }

        public void AddLecture(Lecture lecture)
        {
            Lectures.Add(lecture);
        }

        public void AddStudent(Student student)
        {
            EnroledStudents.Add(student);
        }
    }
}