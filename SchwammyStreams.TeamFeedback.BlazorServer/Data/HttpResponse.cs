using System.Collections.Generic;

namespace SchwammyStreams.TeamFeedback.BlazorServer.Data
{
    public class HttpResponse
    {
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string traceId { get; set; }
        public Dictionary<string, string[]> errors { get; set; }
    }

}
