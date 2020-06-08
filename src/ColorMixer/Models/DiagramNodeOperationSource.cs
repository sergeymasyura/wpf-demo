// Copyright 2015 Sergey Masyura. All rights reserved.

using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace ColorMixer.Models
{
    /// <summary>
    /// Items source of the operation modes.
    /// </summary>
    internal class DiagramNodeOperationSource : IItemsSource
    {
        /// <summary>
        /// Gets the collection of possible values.
        /// </summary>
        public ItemCollection GetValues()
        {
            var modes = new ItemCollection
            {
                {DiagramNodeOperation.OperationMode.BlendPercent10, "Blend 10%"},
                {DiagramNodeOperation.OperationMode.BlendPercent20, "Blend 20%"},
                {DiagramNodeOperation.OperationMode.BlendPercent30, "Blend 30%"},
                {DiagramNodeOperation.OperationMode.BlendPercent40, "Blend 40%"},
                {DiagramNodeOperation.OperationMode.BlendPercent50, "Blend 50%"},
                {DiagramNodeOperation.OperationMode.BlendPercent60, "Blend 60%"},
                {DiagramNodeOperation.OperationMode.BlendPercent70, "Blend 70%"},
                {DiagramNodeOperation.OperationMode.BlendPercent80, "Blend 80%"},
                {DiagramNodeOperation.OperationMode.BlendPercent90, "Blend 90%"}
            };

            return modes;
        }
    }
}
