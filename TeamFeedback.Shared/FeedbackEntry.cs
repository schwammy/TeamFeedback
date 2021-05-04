using System;
using System.ComponentModel.DataAnnotations;

namespace SchwammyStreams.TeamFeedback.Shared
{
    public class FeedbackEntry
    {
        [Required(ErrorMessage = "'Team' is required.")]
        public int? TeamId { get; set; }

        [Required(ErrorMessage = "'Sprint End' is required.")]
        public DateTime? SprintEnd { get; set; }

        [Required(ErrorMessage = "'Things Went Well' is required.")]
        public string ThingsWentWell { get; set; }
        [Required(ErrorMessage = "'Things went better' is required.")]
        public string IsBetterThanLast { get; set; }

    }
}
