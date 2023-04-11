using System.Windows;
using System.Windows.Controls;

namespace TPWProject.Presentation.ViewModel
{
    public class Size
    {
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.RegisterAttached(
                name: "Size",
                propertyType: typeof(bool),
                ownerType: typeof(Size),
                new FrameworkPropertyMetadata(OnValueChanged));

        public static bool GetSize(DependencyObject obj)
        {
            return (bool)obj.GetValue(SizeProperty);
        }
        public static void SetSize(DependencyObject obj, bool value)
        {
            obj.SetValue(SizeProperty, value);
        }

        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)sender;

            frameworkElement.SizeChanged += (sender, e) =>
            {
                if (frameworkElement.DataContext is MainViewModel vm)
                {
                    vm.Width = frameworkElement.ActualWidth;
                    vm.Height = frameworkElement.ActualHeight;
                }
            };
        }
    }
}
