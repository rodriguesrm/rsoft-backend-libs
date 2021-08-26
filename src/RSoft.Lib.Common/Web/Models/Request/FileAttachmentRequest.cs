namespace RSoft.Lib.Common.Web.Models.Request
{

    /// <summary>
    /// File attachment request model
    /// </summary>
    public class FileAttachmentRequest
    {

        #region Constructors

        /// <summary>
        /// Initialize a new instance of FileAttachmentRequest
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="type">File type (mime-type)</param>
        /// <param name="content">File content (base64 expression)</param>
        public FileAttachmentRequest(string filename, string type, string content)
        {
            Filename = filename;
            Type = type;
            Content = content;
        }

        #endregion

        #region Properties

        /// <summary>
        /// File name
        /// </summary>
        public string Filename { get; private set; }

        /// <summary>
        /// File type (mime-type)
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// File content (base64 expression)
        /// </summary>
        public string Content { get; private set; }

        #endregion

    }
}
