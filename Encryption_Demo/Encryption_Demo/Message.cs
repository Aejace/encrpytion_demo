using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Demo
{
    internal class Message
    {
        public string message { get; set; }
        public string subject { get; set; }

        public Message(string subject, string message)
        {
            this.subject = subject;
            this.message = message;
        }
    }
}
