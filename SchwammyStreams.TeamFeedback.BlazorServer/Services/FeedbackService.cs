using Newtonsoft.Json;
using SchwammyStreams.TeamFeedback.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchwammyStreams.TeamFeedback.BlazorServer.Services
{
    public interface IFeedbackService
    {
        Task<Result> SendFeedbackAsync(FeedbackEntry feedbackInput);
    }

    public class FeedbackService : IFeedbackService
    {
        private readonly HttpClient _httpClient;

        public FeedbackService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result> SendFeedbackAsync(FeedbackEntry feedbackInput)
        {
            HttpRequestMessage message = new(HttpMethod.Post, "https://localhost:44375/api/feedback"); //use config

            var json = JsonConvert.SerializeObject(feedbackInput);
            //construct content to send
            var content = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");


            message.Content = content;
            var httpResult = await _httpClient.SendAsync(message);

            Result result = new Result();
            result.Status = httpResult.StatusCode == System.Net.HttpStatusCode.OK;

            return result;
        }
    }
}
