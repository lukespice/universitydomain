using System;
using System.Linq;
using LanternUniversity.Models;
using LanternUniversity.Services;
using Xunit;

namespace LanternUniversity.UnitTests
{
    public class EnrolmentServicesTests
    {

        private Subject CreateSubjectWithMaxCapacity(int maxCapacity)
        {
            var lt = new LectureTheatre
            {
                MaxCapacity = maxCapacity
            };
            var subject = new Subject();
            subject.AddLecture(new Lecture
            {
                LectureTheatre = lt
            });
            return subject;
        }

        /*
         * If the enrolment would cause any of the lectures to exceed the capacity 
         * of its nominated lecture theatre, the enrolment should be rejected
         */

        [Fact]
        public void Should_Enrol_With_NonFull_LectureTheatre()
        {
            var subject = CreateSubjectWithMaxCapacity(1);

            var result = EnrolmentService.CanStudentEnrolInSubject(new Student(), subject);

            Assert.True(result);
        }

        [Fact]
        public void Should_Not_Enrol_With_Full_LectureTheatre()
        {
            var subject = CreateSubjectWithMaxCapacity(1);
            subject.AddStudent(new Student());

            var result = EnrolmentService.CanStudentEnrolInSubject(new Student(), subject);

            Assert.False(result);
        }

        /*
         * If the enrolment would cause the student to have > 10 hours of lectures 
         * in a week, the enrolment should be rejected
         */

        [Fact]
        public void Should_Enrol_Student_With_Less_Than_10_Hours()
        {
            var student = new Student();

            var subject = CreateSubjectWithMaxCapacity(5);
            subject.Lectures.First().StartTime = new DateTimeOffset(1, 1, 1, 8, 0, 0, new TimeSpan()); // 10 am
            subject.Lectures.First().EndTime = new DateTimeOffset(1, 1, 1, 15, 0, 0, new TimeSpan());// 5 pm
           
            var result = EnrolmentService.CanStudentEnrolInSubject(new Student(), subject);

            Assert.True(result);
        }

        [Fact]
        public void Should_Not_Enrol_Student_With_Less_Than_10_Hours()
        {
            var student = new Student();

            var subject = CreateSubjectWithMaxCapacity(5);
            subject.Lectures.First().StartTime = new DateTimeOffset(1, 1, 1, 8, 0, 0, new TimeSpan()); // 10 am
            subject.Lectures.First().EndTime = new DateTimeOffset(1, 1, 1, 15, 0, 0, new TimeSpan());// 5 pm

            subject.AddLecture(new Lecture
            {
                LectureTheatre = new LectureTheatre(),
                StartTime = new DateTimeOffset(1, 1, 1, 15, 0, 0, new TimeSpan()), // 10 am
                EndTime = new DateTimeOffset(1, 1, 1, 20, 0, 0, new TimeSpan()) // 7 pm
            });

            var result = EnrolmentService.CanStudentEnrolInSubject(new Student(), subject);

            Assert.False(result);
        }
    }
}
