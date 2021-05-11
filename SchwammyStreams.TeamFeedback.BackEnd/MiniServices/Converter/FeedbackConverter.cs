using SchwammyStreams.TeamFeedback.BackEnd.Domain;
using SchwammyStreams.TeamFeedback.Shared;

namespace SchwammyStreams.TeamFeedback.BackEnd.MiniServices.Converter
{
    public interface IFeedbackConverter
    {
        Feedback ToDomain(FeedbackEntry feedbackEntry);
    }

    public class FeedbackConverter : IFeedbackConverter
    {
        public Feedback ToDomain(FeedbackEntry feedbackEntry)
        {
            Feedback result = new Feedback();

            return result;
        }
    }
}
