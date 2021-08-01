using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows;

namespace ChatBubbleContainer
{
    class ChatBubbleSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var u = container as FrameworkElement;

            IBubbleContext message = item as IBubbleContext;

            if (message.BubbleType != 0)
                return u.FindResource("EventBubble") as DataTemplate;

            if (message.BubbleSender == "10000")
            {
                //Self
                return u.FindResource("LeftBubble") as DataTemplate;
            }
            else
            {
                //Others
                return u.FindResource("RightBubble") as DataTemplate;
            }

        }
    }

}
