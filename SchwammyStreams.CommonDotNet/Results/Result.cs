using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace SchwammyStreams.CommonDotNet.Results
{
    /// <summary>
    /// An object use to represent the result of an operation.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Result
    {
        /// <summary>
        /// An class that wraps status and messages into a single type.
        /// </summary>
        public Result()
        {
            Messages = new List<Message>();
        }
        /// <summary>
        /// A value that provides the overall status of the operation.
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        /// A list of messages supporting the result status.
        /// </summary>
        public List<Message> Messages { get; set; }

        /// <summary>
        /// A helper method for validation failed situations.
        /// </summary>
        /// <param name="messageText">the message text</param>
        public void SetValidationFailed(string messageText)
        {
            Status = StatusType.ValidationFailed;
            Message message = new Message
            {
                Text = messageText
            };

            Messages.Add(message);
        }

        /// <summary>
        /// A helper method for validation failed situations.
        /// </summary>
        /// <param name="identifier">a string to identify the field or object for which the validation failed.</param>
        /// <param name="messageText">the message text</param>
        public void SetValidationFailed(string identifier, string messageText)
        {
            Status = StatusType.ValidationFailed;
            Messages.Add(new Message
            {
                Identifier = identifier,
                Text = messageText
            });
        }

        /// <summary>
        /// A helper method for validation failed situations.
        /// </summary>
        /// <param name="messageText">the message text</param>
        /// <param name="details">A list of strings that further explains the validation issue(s).</param>
        public void SetValidationFailed(string messageText, List<string> details)
        {
            Status = StatusType.ValidationFailed;
            Message message = new Message { Text = messageText };
            foreach (var detail in details)
            {
                message.Details.Add(new KeyValuePair<string, string>(Message.PlainTextKey, detail));
            }

            Messages.Add(message);
        }

        /// <summary>
        /// A helper method for validation failed situations.
        /// </summary>
        /// <param name="identifier">a string to identify the field or object for which the validation failed.</param>
        /// <param name="messageText">the message text</param>
        /// <param name="details">A list of strings that further explains the validation issue(s).</param>
        public void SetValidationFailed(string identifier, string messageText, List<string> details)
        {
            Status = StatusType.ValidationFailed;
            Messages.Add(new Message
            {
                Identifier = identifier,
                Text = messageText,
                Details = details.Select(d => new KeyValuePair<string,string>(Message.PlainTextKey, d )).ToList()
            });
        }
        /// <summary>
        /// A helper method for validation failed situations.
        /// </summary>
        /// <param name="identifier">a string to identify the field or object for which the validation failed.</param>
        /// <param name="messageText">the message text</param>
        /// <param name="details">A list of KeyValuePairs that further explains the validation issue(s).</param>
        public void SetValidationFailed(string identifier, string messageText, List<KeyValuePair<string, string>> details)
        {
            Status = StatusType.ValidationFailed;
            Messages.Add(new Message
            {
                Identifier = identifier,
                Text = messageText,
                Details = details
            });
        }
    }
}
