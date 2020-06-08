// Copyright 2015 Sergey Masyura. All rights reserved.

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ColorMixer.Converters
{
    /// <summary>
    /// Converts from the boolean to Visibility.
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool) value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
