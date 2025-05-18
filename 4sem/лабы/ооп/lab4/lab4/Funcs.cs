using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace lab4
{
   
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool b && b ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int rating)
                return rating - 1; 
            return 2; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int index)
                return index + 1; 
            return 3; 
        }
    }
    public class StatusToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString() switch
            {
                "Active" => new SolidColorBrush(Colors.Green),
                "Cancelled" => new SolidColorBrush(Colors.Red),
                _ => new SolidColorBrush(Colors.Gray)
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class EmptyToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public static class Funcs
    {
        public static string ChangeTheme(string theme)
        {
            ResourceDictionary newtheme = new ResourceDictionary();
            string returnbuff;

            try
            {
                switch (theme)
                {
                    case "White":
                        newtheme.Source = new Uri("C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab4\\lab4\\themes\\DarkTheme.xaml");
                        returnbuff = "Dark";
                        break;
                    case "Dark":
                        newtheme.Source = new Uri("C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab4\\lab4\\themes\\AristocraticTheme.xaml");
                        returnbuff = "Gold";
                        break;
                    case "Gold":
                        newtheme.Source = new Uri("C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab4\\lab4\\themes\\WhiteTheme.xaml");
                        returnbuff = "White";
                        break;
                    default:
                        newtheme.Source = new Uri("C:\\Users\\леха\\Desktop\\2 курс\\4sem\\лабы\\ооп\\lab4\\lab4\\themes\\WhiteTheme.xaml");
                        returnbuff = "White";
                        break;
                }

                var currentheme = Application.Current.Resources.MergedDictionaries
                    .FirstOrDefault(d => d.Source != null && d.Source.ToString().Contains("Theme"));

                if (currentheme != null)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(currentheme);
                }

                Application.Current.Resources.MergedDictionaries.Add(newtheme);

                foreach (Window window in Application.Current.Windows)
                {
                    window.InvalidateVisual();
                }

                return returnbuff;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при смене темы: {ex.Message}");
                return theme;
            }
        }
    }
}
