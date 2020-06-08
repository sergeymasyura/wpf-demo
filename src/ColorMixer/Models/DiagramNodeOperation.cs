// Copyright 2015 Sergey Masyura. All rights reserved.

using System;
using System.ComponentModel;
using System.Windows.Media;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace ColorMixer.Models
{
    /// <summary>
    /// Node which represents the operation on two colors.
    /// </summary>
    public class DiagramNodeOperation : DiagramNode
    {
        private OperationMode _node;
        private Color _color;

        /// <summary>
        /// Mode of the operation on color nodes.
        /// </summary>
        /// <remarks>
        /// Defines amount of the color to blend on top of the other.
        /// </remarks>
        public enum  OperationMode
        {
            BlendPercent10 = 10,
            BlendPercent20 = 20,
            BlendPercent30 = 30,
            BlendPercent40 = 30,
            BlendPercent50 = 50,
            BlendPercent60 = 60,
            BlendPercent70 = 70,
            BlendPercent80 = 80,
            BlendPercent90 = 90
        }

        public DiagramNodeOperation()
        {
            IsLinkableTo = true;
            Color = Colors.Transparent;
            Icon = new Uri("pack://application:,,,/ColorMixer;component/Assets/NodeOperation.png");
            Mode = OperationMode.BlendPercent50;
        }

        /// <summary>
        /// Mode of the operation on color nodes.
        /// </summary>
        [DisplayName(@"Mode")]
        [Description(@"The blending mode this node represents.")]
        [ItemsSource(typeof(DiagramNodeOperationSource))]
        public OperationMode Mode
        {
            get { return _node; }
            set
            {
                var oldValue = _node;
                _node = value;

                RaisePropertyChanged("Mode", oldValue, value);
            }
        }

        /// <summary>
        /// The resulting color of the operation.
        /// </summary>
        [Browsable(false)]
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
