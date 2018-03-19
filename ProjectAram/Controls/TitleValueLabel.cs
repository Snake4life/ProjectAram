using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectAram.Controls
{
    public class TitleValueLabel : Label
    {
        static TitleValueLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TitleValueLabel), new FrameworkPropertyMetadata(typeof(TitleValueLabel)));
        }

        public static readonly DependencyProperty TitleProperty
            = DependencyProperty.Register(
                "Title",
                typeof(string),
                typeof(TitleValueLabel),
                new PropertyMetadata(default(string))
            );

        public static readonly DependencyProperty ValueProperty
            = DependencyProperty.Register(
                "Value",
                typeof(string),
                typeof(TitleValueLabel),
                new PropertyMetadata(default(string))
            );

        public static readonly DependencyProperty SeparatorProperty
            = DependencyProperty.Register(
                "Separator",
                typeof(string),
                typeof(TitleValueLabel),
                new PropertyMetadata(":")
            );

        public static readonly DependencyProperty ValueColorProperty
            = DependencyProperty.Register(
                "ValueColor",
                typeof(Brush),
                typeof(TitleValueLabel),
                new PropertyMetadata(Brushes.Black)
            );

        public static readonly DependencyProperty TitleColorProperty
            = DependencyProperty.Register(
                "TitleColor",
                typeof(Brush),
                typeof(TitleValueLabel),
                new PropertyMetadata(Brushes.Black)
            );

        public string Separator
        {
            get => (string)GetValue(SeparatorProperty);
            set => SetValue(SeparatorProperty, value);
        }

        [Bindable(true)]
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        [Bindable(true)]
        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public Brush ValueColor
        {
            get => (Brush)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public Brush TitleColor
        {
            get => (Brush)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
    }
}