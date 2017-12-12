using System.Linq;
using LanternUniversity.Models;

namespace LanternUniversity.Services
{
    public static class EnrolmentService
    {
        static readonly int MaxHoursPerStudent = 10;

        public static bool CanStudentEnrolInSubject(Student student, Subject subject)
        {
            return (IsThereRoomInTheLectureTheatures(subject) &&
                    DoesTheStudentHaveEnoughTime(student));
        }

        static bool IsThereRoomInTheLectureTheatures(Subject subject)
        {
            var maxCapacity = subject.Lectures
                            .Select(l => l.LectureTheatre)
                            .Min(lts => lts.MaxCapacity);

            return maxCapacity > subject.EnroledStudents.Count;
        }

        static bool DoesTheStudentHaveEnoughTime(Student student)
        {
            return student.EnrolledTime.Hours < MaxHoursPerStudent;
        }
    }
}
