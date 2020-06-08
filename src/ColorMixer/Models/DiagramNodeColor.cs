// Copyright 2015 Sergey Masyura. All rights reserved.

using System;
using System.ComponentModel;
using System.Windows.Media;

namespace ColorMixer.Models
{
    /// <summary>
    /// Node which represents the colors.
    /// </summary>
    public class DiagramNodeColor : DiagramNode
    {
        private Color _color;

        public DiagramNodeColor()
        {
            IsLinkableTo = false;
            Color = Colors.LightSkyBlue;
            Icon = new Uri("pack://application:,,,/ColorMixer;component/Assets/NodeColor.png");
        }

        /// <summary>
        /// The color this node represents.
        /// </summary>
        [DisplayName(@"Color")]
        [Description(@"The color this node represents.")]
        public Color Color
        {
            get { return _color; }
            set
            {
                var oldValue = _color;
                _color = value;

                RaisePropertyChanged("Color", oldValue, value);
            }
        }
    }
}
