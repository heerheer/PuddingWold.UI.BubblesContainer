using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// BubbleContentPresenter.xaml 的交互逻辑
    /// </summary>
    partial class BubbleContentPresenter : UserControl
    {



        public string BubbleContent
        {
            get { return (string)GetValue(BubbleContentProperty); }
            set { SetValue(BubbleContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BubbleContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BubbleContentProperty =
            DependencyProperty.Register("BubbleContent", typeof(string), typeof(BubbleContentPresenter), new PropertyMetadata(""));



        public BubbleContentPresenter()
        {
            InitializeComponent();
            DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(BubbleContentPresenter.BubbleContentProperty, typeof(BubbleContentPresenter));
            if (dpd != null)
            {
                dpd.AddValueChanged(this, OnContentChanged);
            }
            Render();
        }

        private void OnContentChanged(object? sender, EventArgs e)
        {
            this.Render();
        }

        private void Render()
        {
            List<ContentComponent> contents = new();
            var content = BubbleContent?.ToString() ?? "";

            var matches = Regex.Matches(content, @"\[(.*?)=+(.*?)\]|\S[^\[\]]*");

            foreach (Match match in matches)
            {
                contents.Add(ContentComponentFactory.Create(
                    match.Value,
                    match.Groups[1].Value,
                    match.Groups[2].Value
                    )
                    );
            }

            //显示到页面
            wrapPanel.Children.Clear();
            //清除原来的
            contents.ForEach(x =>
            {
                wrapPanel.Children.Add(x.element);
            });
        }

    }

    record ContentComponent(string text, UIElement element, ComponentType type);

    enum ComponentType
    {
        Text,
        Image,
        Voice,
        Media,
        File

    }

    class ContentComponentFactory
    {
        /// <summary>
        /// 创建一个表示部件的记录
        /// </summary>
        /// <param name="tempstr">原始文本</param>
        /// <param name="typestr">类型文本</param>
        /// <param name="valuestr">值文本</param>
        /// <returns></returns>
        public static ContentComponent Create(string tempstr, string typestr = "", string valuestr = "")
        {
            ComponentType type = default;
            if (tempstr.StartsWith("[") && tempstr.EndsWith("]"))
            {
                //Special
                type = typestr switch
                {

                    "pic" => ComponentType.Image,
                    "voi" => ComponentType.Voice,
                    "file" => ComponentType.File,
                    "meida" => ComponentType.Media,
                    "text" => ComponentType.Text,
                    _ => ComponentType.Text

                };//获取种类
                Debug.WriteLine(type.ToString());
            }
            else
            {
                //Text
                type = ComponentType.Text;
            }
            return new(tempstr, GetUIElement(type, tempstr, valuestr), type);
        }

        static UIElement GetUIElement(ComponentType type, string str, string valuestr = "")
        {
            UIElement element;
            try
            {
                element = type switch
                {
                    ComponentType.Text => new TextBlock() { Text = str },
                    ComponentType.Image => new Image()
                    {
                        Source = new BitmapImage(new Uri(valuestr)),
                    },
                    _ => new TextBlock() { Text = str }
                };

            }
            catch (Exception)
            {
                element = new TextBlock() { Text = str };
            }
            return element;
        }
    }


}
