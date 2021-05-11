using SchwammyStreams.CommonDotNet.Data;
using SchwammyStreams.TeamFeedback.BackEnd.Domain;

namespace SchwammyStreams.TeamFeedback.BackEnd.Integration.Repository
{
    public interface IFeedbackRepository : IGenericWriteableRepository<Feedback>
    {
    }


    public class FeedbackRepository : GenericRepository<Feedback, FeedbackDbContext>, IFeedbackRepository
    {
        public FeedbackRepository(FeedbackDbContext feedbackDbContext) : base(feedbackDbContext)
        {
        }
    }
}
