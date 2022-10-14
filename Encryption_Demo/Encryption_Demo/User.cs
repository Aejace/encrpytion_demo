namespace Encryption_Demo
{
    internal class User
    {
        public string Name { get; }
        public List<IKey> Keys = new List<IKey>();
        public List<Message> Inbox = new List<Message>();
        public List<Message> DecryptedInbox = new List<Message>();
        public List<Message> Drafts = new List<Message>();
        public List<Message> EncryptedDrafts = new List<Message>();
        public List<Message> Sent = new List<Message>();

        public User(string name)
        {
            Name = name;
        }

        public void CreateBasicKey(string seed)
        {
            BasicKey key = new BasicKey(seed);
            Keys.Add(key);
        }

        public void createNewMessage(string subject, string content, List<string> recipientsList)
        {
            Message message = new Message(subject, content, recipientsList);
            Drafts.Add(message);
        }
    }
}
