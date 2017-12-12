using System;

namespace LanternUniversity.Models
{
    public class LectureTheatre : IIdentifier
    {
        public Guid Id { get; set; }

        public int MaxCapacity { get; set; }
    }
}
