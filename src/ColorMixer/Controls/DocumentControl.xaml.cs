// Copyright 2015 Sergey Masyura. All rights reserved.

using System.Windows.Controls;
using ColorMixer.Models;

namespace ColorMixer.Controls
{
    /// <summary>
    /// Document control to work with diagrams.
    /// </summary>
    public partial class DocumentControl : UserControl
    {
        public DocumentControl()
        {
            InitializeComponent();
        }

        private void DiagramControl_OnSelectionChanged(DiagramNode node)
        {
            PropertyGrid.SelectedObject = node;
        }
    }
}
