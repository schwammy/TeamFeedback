using System.Collections.Generic;

namespace SchwammyStreams.TeamFeedback.Shared
{
    public class Result
    {
        public Result()
        {
            Messages = new List<string>();
        }
        public bool Status { get; set; }
        public List<string> Messages { get; set; }

    }
}
