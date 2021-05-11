using SchwammyStreams.TeamFeedback.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchwammyStreams.TeamFeedback.BackEnd.Orchestrator
{
    public class FeedbackOrchestrator
    {
        public Task<Result> AddFeedbackAsync(FeedbackEntry feedbackEntry)
        {
            Result result = new ();
            // call a few "mini services"

            // validate

            // convert it Domain object

            // save it

            return Task.FromResult(result);
        }
    }
}
