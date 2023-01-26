using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace RSoft.Lib.Messaging.Extensions
{

    /// <summary>
    /// Provides log extensions methods
    /// </summary>
    public static class LogExtension
    {

        /// <summary>
        /// Formats and writes an informational log message.
        /// </summary>
        /// <param name="logger">Microsoft.Extensions.Logging.ILogger to write to</param>
        /// <param name="message">Log text message</param>
        /// <param name="messageId">The messageId assigned to the message when it was initially Sent</param>
        /// <param name="messageContent">Adicional content to log</param>
        /// <param name="contentName">Tag content name to log</param>
        public static void LogInformation(this ILogger logger, string message, Guid? messageId, string messageContent, string contentName = "MessageContent")
        {
            IList<KeyValuePair<string, object>> pairs = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("MessageId", messageId),
                new KeyValuePair<string, object>(contentName, messageContent)
            };
            logger.Log(LogLevel.Information, new EventId(1010, "RSoft:Process:Message"), state: pairs, null, (i, e) => { return message; });
        }

    }

}
