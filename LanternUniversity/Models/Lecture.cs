using System;

namespace LanternUniversity.Models
{
    public class Lecture : IIdentifier
    {
        public Guid Id { get; set; }

        public Subject Subject { get; set; }

        public LectureTheatre LectureTheatre { get; set; }

        public DayOfWeek Day { get; set; }

        //TODO: Use a better format that just represents date
        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public TimeSpan Length => StartTime - EndTime;
    }
}