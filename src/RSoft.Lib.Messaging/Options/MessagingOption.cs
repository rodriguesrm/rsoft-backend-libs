namespace RSoft.Lib.Messaging.Options
{
    public class MessagingOption
    {

        /// <summary>
        /// Message broker server address (host server)
        /// </summary>
        public string ServerAddress { get; set; }

        /// <summary>
        /// Virtual host name
        /// </summary>
        public string VirtualHost { get; set; }

        /// <summary>
        /// Username to connect
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// User password to connect
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Return RabbitMQ Uri
        /// </summary>
        public string Uri()
        {
            string uri = $"{ServerAddress}";
            if (!string.IsNullOrWhiteSpace(VirtualHost))
            {
                if (!uri.EndsWith("/"))
                    uri += "/";
                uri += VirtualHost;
            }
            return uri;
        }

    }

}
