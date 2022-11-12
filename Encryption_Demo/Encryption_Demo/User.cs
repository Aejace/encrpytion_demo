namespace Encryption_Demo
{
    internal class User
    {
        public string Name { get; }
        public List<Key> Keys = new List<Key>();
        public Key CurrentKey = new BasicKey();
        public List<Message> Inbox = new List<Message>();
        public List<Message> InterceptedMessages = new List<Message>();
        public List<Message> DecryptedInbox = new List<Message>();
        public Message PartialMessage = new Message();
        public List<Message> Drafts = new List<Message>();
        public List<Message> EncryptedDrafts = new List<Message>();
        public List<Message> Sent = new List<Message>();

        public User(string name)
        {
            Name = name;
        }

        public void CreateBasicKey(string name, string seed)
        {
            BasicKey key = new BasicKey(name, seed);
            Keys.Add(key);
        }

        public void SetCurrentKey(Key key)
        {
            CurrentKey = key;
        }

        public void AddToDrafts()
        {
            Drafts.Add(PartialMessage);
            PartialMessage = new Message();
        }

        public void EncryptMessage(Message message)
        {
            Message encryptedMessage = CurrentKey.Encrypt(message);
            EncryptedDrafts.Add(encryptedMessage);
        }

        public void EncryptMessageTo(Message message, List<string> usernames)
        {
            Message encryptedMessage = CurrentKey.Encrypt(message);
            List<string> verifiedNames = new List<string>();
            foreach (string name in usernames)
            {
                if (encryptedMessage.RecipientsList.Contains(name))
                {
                    verifiedNames.Add(name);
                }
            }
            encryptedMessage.RecipientsList = verifiedNames;
            EncryptedDrafts.Add(encryptedMessage);
        }

        public void SendMessage(Message message)
        {
            Sent.Add(message);
        }

        public void RefreshInbox(List<Message> messages)
        {
            Inbox = messages;
        }

        public void InterceptMessage(Message message)
        {
            InterceptedMessages.Add(message);
        }

        public void DecryptMessage(Message message)
        {
            Message decryptedMessage = CurrentKey.Decrypt(message);
            DecryptedInbox.Add(decryptedMessage);
        }
    }
}
