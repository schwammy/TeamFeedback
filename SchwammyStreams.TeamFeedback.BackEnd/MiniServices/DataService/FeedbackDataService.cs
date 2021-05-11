using SchwammyStreams.CommonDotNet.Data.DataService;
using SchwammyStreams.TeamFeedback.BackEnd.Domain;
using SchwammyStreams.TeamFeedback.BackEnd.Integration.Repository;

namespace SchwammyStreams.TeamFeedback.BackEnd.MiniServices.DataService
{
    public interface IFeedbackDataService : IDataService<Feedback>
    {
    }

    public class FeedbackDataService : DataService<Feedback>, IFeedbackDataService
    {
        public FeedbackDataService(IFeedbackRepository feedbackRepository) : base(feedbackRepository)
        {

        }
    }
}
