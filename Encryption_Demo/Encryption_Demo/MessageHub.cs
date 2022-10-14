namespace Encryption_Demo
{
    internal class MessageHub
    {
        private List<Message> MessageHistory = new List<Message>();

        public void SendMessage(Message message)
        {
            MessageHistory.Add(message);
        }

        public List<Message> GetUsersMessages(string name)
        {
            return MessageHistory.Where(message => message.RecipientsList.Contains(name)).ToList();
        }

        public List<Message> HackTheHub()
        {
            return MessageHistory.ToList();
        }
    }
}
