

using System.ComponentModel.DataAnnotations;

namespace SchwammyStreams.TeamFeedback.BlazorServer.Data
{
    public class FeedbackEntry
    {
        [Required(ErrorMessage = "'Things Went Well' is required.")]
        public string ThingsWentWell { get; set; }
        [Required(ErrorMessage = "'Things went better' is required.")]
        public string IsBetterThanLast { get; set; }

    }
}
