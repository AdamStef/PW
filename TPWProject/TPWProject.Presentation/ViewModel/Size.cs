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

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.RegisterAttached(
                name: "Width",
                propertyType: typeof(double),
                ownerType: typeof(Size));

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.RegisterAttached(
                name: "Height",
                propertyType: typeof(double),
                ownerType: typeof(Size));

        public static bool GetSize(DependencyObject obj)
        {
            return (bool)obj.GetValue(SizeProperty);
        }
        public static void SetSize(DependencyObject obj, bool value)
        {
            obj.SetValue(SizeProperty, value);
        }

        public static double GetWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(WidthProperty);
        }
        public static void SetWidth(DependencyObject obj, double value)
        {
            obj.SetValue(WidthProperty, value);
        }

        public static double GetHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HeightProperty);
        }
        public static void SetHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HeightProperty, value);
        }


        private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //var frameworkElement = (FrameworkElement)sender;
            //if ((bool)e.NewValue)
            //{
            //    frameworkElement.SizeChanged += OnFrameworkElementSizeChanged;
            //    UpdateObservedSizesForFrameworkElement(frameworkElement);
            //}
            //else
            //{
            //    frameworkElement.SizeChanged -= OnFrameworkElementSizeChanged;
            //}


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

        //private static void OnFrameworkElementSizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    UpdateObservedSizesForFrameworkElement((FrameworkElement)sender);
        //}

        //private static void UpdateObservedSizesForFrameworkElement(FrameworkElement frameworkElement)
        //{
        //    frameworkElement.SetCurrentValue(WidthProperty, frameworkElement.ActualWidth);
        //    frameworkElement.SetCurrentValue(HeightProperty, frameworkElement.ActualHeight);
        //}
    }
}
