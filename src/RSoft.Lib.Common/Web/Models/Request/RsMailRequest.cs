using System.Collections.Generic;

namespace RSoft.Lib.Common.Web.Models.Request
{

    /// <summary>
    /// RSoft mail service request model
    /// </summary>
    public class RsMailRequest
    {

        /// <summary>
        /// Email sender
        /// </summary>
        public EmailAddressRequest From { get; set; }

        /// <summary>
        /// Response receiving email
        /// </summary>
        public EmailAddressRequest ReplyTo { get; set; }

        /// <summary>
        /// Email subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Content (body) of email
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// List of email recipients
        /// </summary>
        public List<EmailAddressRequest> To { get; set; } = new List<EmailAddressRequest>();

        /// <summary>
        /// Copy recipient list
        /// </summary>
        public List<EmailAddressRequest> Cc { get; set; } = new List<EmailAddressRequest>();

        /// <summary>
        /// Blind copy recipient list
        /// </summary>
        public List<EmailAddressRequest> Bcc { get; set; } = new List<EmailAddressRequest>();

        /// <summary>
        /// List of files to be sent as an attachment
        /// </summary>
        public List<FileAttachmentRequest> Files { get; set; } = new List<FileAttachmentRequest>();

        /// <summary>
        /// Indicates whether the content will be sent in HTML format or in plain text
        /// </summary>
        public bool EnableHtml { get; set; } = true;

    }
}
