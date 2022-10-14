namespace Encryption_Demo
{
    internal class User
    {
        public string Name { get; }
        public List<IKey> Keys = new List<IKey>();
        public List<Message> Inbox = new List<Message>();
        public List<Message> InterceptedMessages = new List<Message>();
        public List<Message> DecryptedInbox = new List<Message>();
        public Message stillComposing = new Message();
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

        public void CreateNewMessage(string subject, string content, List<string> recipientsList)
        {
            Message message = new Message(subject, content, recipientsList);
            Drafts.Add(message);
        }

        public void EncryptMessage(Message message, IKey key)
        {
            Message encryptedMessage = key.Encrypt(message);
            EncryptedDrafts.Add(encryptedMessage);
        }

        public Message SendMessage(Message message)
        {
            Sent.Add(message);
            return message;
        }

        public void RefreshInbox(List<Message> messages)
        {
            Inbox = messages;
        }

        public void InterceptMessage(Message message)
        {
            InterceptedMessages.Add(message);
        }

        public void DecryptMessage(Message message, IKey key)
        {
            Message decryptedMessage = key.Decrypt(message);
            DecryptedInbox.Add(decryptedMessage);
        }
    }
}
