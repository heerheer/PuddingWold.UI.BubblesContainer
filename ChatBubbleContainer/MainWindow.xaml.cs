using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatBubbleContainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<IBubbleContext> BubbleContexts { get; set; } = new(); 

        public string SendingMessage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

        }

        void AddMessage(string content,string from,string sender)
        {
            BubbleContexts.Add(new ChatMessage(content, from,sender));
        }
        void AddEvent(string content, string from, string sender)
        {
            BubbleContexts.Add(new ChatMessage(content, from, sender,1));
        }


        private void AddMsgBtn_Right(object sender, RoutedEventArgs e)
        {
            AddMessage(SendingMessage, "10000", "10000");
        }

        private void AddMsgBtn_Left(object sender, RoutedEventArgs e)
        {
            AddMessage(SendingMessage, "10001", "10001");

        }

        private void AddEventBtn(object sender, RoutedEventArgs e)
        {
            AddEvent(SendingMessage, "10001", "10001");

        }
    }
}
