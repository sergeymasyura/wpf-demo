// Copyright 2015 Sergey Masyura. All rights reserved.

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorMixer.Converters
{
    /// <summary>
    /// Converts from the Color to SolidColorBrush.
    /// </summary>
    class ColorToBrushConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new SolidColorBrush((Color)value);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}