using System;
using SchwammyStreams.CommonDotNet.Data;

namespace SchwammyStreams.TeamFeedback.BackEnd.Domain
{
    public class Feedback : Entity
    {
        public int TeamId { get; set; }
        public DateTime SprintEnd { get; set; }
        public int Value { get; set; }
        public int Compared { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }

    }
}
