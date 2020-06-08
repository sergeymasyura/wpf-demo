// Copyright 2015 Sergey Masyura. All rights reserved.

using System.Windows.Media;

namespace ColorMixer.Utils
{
    /// <summary>
    /// Helper class for color mixing operations.
    /// </summary>
    public static class ColorHelper
    {
        /// <summary>
        /// Blends the specified colors together.
        /// </summary>
        /// <param name="color">
        /// Color to blend onto the background color.
        /// </param>
        /// <param name="backColor">
        /// Color to blend the other color onto.
        /// </param>
        /// <param name="amount">
        /// How much of 'color' to keep on top of 'backColor'.
        /// </param>
        public static Color Blend(this Color color, Color backColor, double amount)
        {
            var r = (byte)((color.R * amount) + backColor.R * (1 - amount));
            var g = (byte)((color.G * amount) + backColor.G * (1 - amount));
            var b = (byte)((color.B * amount) + backColor.B * (1 - amount));

            return Color.FromRgb(r, g, b);
        }
    }
}
