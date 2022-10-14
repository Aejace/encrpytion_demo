namespace Encryption_Demo
{
    internal class Message
    {
        public string Content { get; set; }
        public string Subject { get; set; }
        public List<string> RecipientsList { get; }

        public Message(string subject, string message, List<string> recipientsList)
        {
            this.Subject = subject;
            this.Content = message;
            this.RecipientsList = recipientsList;
        }
    }
}
