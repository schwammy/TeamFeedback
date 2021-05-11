using System.Threading.Tasks;
using SchwammyStreams.CommonDotNet.Data;
using SchwammyStreams.TeamFeedback.BackEnd.Domain;
using SchwammyStreams.TeamFeedback.BackEnd.MiniServices.Converter;
using SchwammyStreams.TeamFeedback.BackEnd.MiniServices.DataService;
using SchwammyStreams.TeamFeedback.Shared;

namespace SchwammyStreams.TeamFeedback.BackEnd.Orchestrator
{
    public class FeedbackOrchestrator
    {
        private readonly IFeedbackConverter _feedbackConverter;
        private readonly IFeedbackDataService _feedbackDataService;
        private readonly IUnitOfWork<FeedbackDbContext> _unitOfWork;

        public FeedbackOrchestrator(IFeedbackConverter feedbackConverter,
            IFeedbackDataService feedbackDataService,
            IUnitOfWork<FeedbackDbContext> unitOfWork)
        {
            _feedbackConverter = feedbackConverter;
            _feedbackDataService = feedbackDataService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> AddFeedbackAsync(FeedbackEntry feedbackEntry)
        {
            Result result = new();

            // validate -- may not need that just yet, thanks to Attributes

            // convert it Domain object
            var domain = _feedbackConverter.ToDomain(feedbackEntry);

            // save it
            _feedbackDataService.Add(domain);

            await _unitOfWork.SaveAllAsync();

            return result;
        }
    }
}
