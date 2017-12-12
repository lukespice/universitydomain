using System;
using System.Collections.Generic;
using System.Linq;

namespace LanternUniversity.Models
{
    public class Student : IIdentifier
    {
        public Student()
        {
            Enrolments = new List<Subject>();
        }
        
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Subject> Enrolments { get; set; }

        public TimeSpan EnrolledTime
        {
            get
            {
                var lengths = Enrolments
                    .SelectMany(e => e.Lectures)
                    .Select(l => l.Length);
                TimeSpan totalTime;
                foreach (var time in lengths)
                {
                    totalTime += time;
                }   
                return totalTime;
            }
        }

        public void AddSubject(Subject subject)
        {
            Enrolments.Add(subject);
        }
    }
}
