using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// BubblesContainer.xaml 的交互逻辑
    /// </summary>
    public partial class BubblesContainer : UserControl
    {
        public ObservableCollection<IBubbleContext> BubbleContexts
        {
            get { return (ObservableCollection<IBubbleContext>)GetValue(BubbleContextsProperty); }
            set { SetValue(BubbleContextsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BubbleContexts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BubbleContextsProperty =
            DependencyProperty.Register("BubbleContexts", typeof(ObservableCollection<IBubbleContext>), typeof(BubblesContainer), new PropertyMetadata(null));



        public BubblesContainer()
        {
            InitializeComponent();
            Listbox.DataContext = this;
        }
    }
}
