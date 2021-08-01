using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBubbleContainer
{
    class ChatMessage:IBubbleContext
    {
        public ChatMessage(string content, string from, string sender)
        {
            Content = content;
            From = from;
            Sender = sender;
            Type = 0;
        }

        public ChatMessage(string content, string from, string sender, int type) : this(content, from, sender)
        {
            Type = type;
        }

        public string Content { get; set; }
        public string From { get; set; }
        public string Sender { get; set; }
        public int Type { get; set; }

        public string BubbleContent => Content;
        public string BubbleFrom =>From;
        public string BubbleSender => Sender;
        public int BubbleType => Type;
    }




    public interface IBubbleContext
    {
        public string BubbleContent { get; }
        public string BubbleFrom { get; }
        public string BubbleSender { get; }
        public int BubbleType { get; }
    }
}
