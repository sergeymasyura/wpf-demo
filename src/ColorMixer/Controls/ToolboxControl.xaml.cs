// Copyright 2015 Sergey Masyura. All rights reserved.

using System;
using System.Collections.Generic;
using System.Windows.Controls;
using ColorMixer.Models;
using Northwoods.GoXam.Model;

namespace ColorMixer.Controls
{
    /// <summary>
    /// Toolbox control.
    /// </summary>
    public partial class ToolboxControl : UserControl
    {
        public ToolboxControl()
        {
            InitializeComponent();
            InitializePallete();
        }

        private void InitializePallete()
        {
            Palette.Model = new GraphLinksModel<DiagramNode, String, String, DiagramLink>
            {
                NodesSource = new List<DiagramNode>
                {
                    new DiagramNodeColor
                    {
                        Key = "ColorNode",
                        Name = "Color"
                    },
                    new DiagramNodeOperation
                    {
                        Key = "OperationNode",
                        Name = "Operation"
                    }
                }
            };
        }
    }
}
