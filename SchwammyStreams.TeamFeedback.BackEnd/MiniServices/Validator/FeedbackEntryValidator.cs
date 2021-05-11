using SchwammyStreams.TeamFeedback.Shared;
using System.Collections.Generic;

namespace SchwammyStreams.TeamFeedback.BackEnd.MiniServices.Validator
{
    public interface IFeedbackEntryValidator
    {
        List<string> Validate(FeedbackEntry feedbackEntry);
    }

    public class FeedbackEntryValidator : IFeedbackEntryValidator
    {
        // Todo: Do I need this at all with Annotations? Should this be for just complex stuff?
        public List<string> Validate(FeedbackEntry feedbackEntry)
        {
            List<string> messages = new List<string>();

            if (!feedbackEntry.TeamId.HasValue)
            {
                messages.Add("Team is required.");
            }
            if (feedbackEntry.SprintEnd == null)
            {
                // add more date specific validation

                messages.Add("Please specify the sprint.");
            }
            if (string.IsNullOrWhiteSpace(feedbackEntry.ThingsWentWell))
            {
                messages.Add("ThingsWentWell is required.");
            }
            if (string.IsNullOrWhiteSpace(feedbackEntry.IsBetterThanLast))
            {
                messages.Add("IsBetterThanLast is required.");
            }

            return messages;
        }
    }
}
