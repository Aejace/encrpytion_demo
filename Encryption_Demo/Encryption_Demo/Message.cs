namespace Encryption_Demo
{
    internal class Message
    {
        public string Content { get; set; }
        public string Subject { get; set; }
        public List<string> RecipientsList { get; }

        public Message()
        {
            Content = "";
            Subject = "";
            RecipientsList = new List<string>();
        }

        public Message(string subject, string message, List<string> recipientsList)
        {
            this.Subject = subject;
            this.Content = message;
            this.RecipientsList = recipientsList;
        }

        public string PrintMessage()
        {
            string recipients = RecipientsList.Aggregate("", (current, recipient) => current + recipient);
            return "TO:" + recipients + "\n" + "SUBJECT: " + this.Subject + "\n" + "BODY: " + this.Content;
        }
    }
}
