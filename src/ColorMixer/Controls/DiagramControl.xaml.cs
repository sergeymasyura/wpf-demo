// Copyright 2015 Sergey Masyura. All rights reserved.

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ColorMixer.Models;
using ColorMixer.Utils;
using Northwoods.GoXam;
using Northwoods.GoXam.Model;

namespace ColorMixer.Controls
{
    /// <summary>
    /// Diagram editor control.
    /// </summary>
    public partial class DiagramControl : UserControl
    {
        /// <summary>
        /// Action is node is selected on the diagram.
        /// </summary>
        public event Action<DiagramNode> SelectionChanged;

        /// <summary>
        /// Command to copy the color from the node to clipboard.
        /// </summary>
        public static RoutedCommand CopyColorCommand = new RoutedCommand();

        public DiagramControl()
        {
            InitializeComponent();
            InitializeDiagram();
        }

        private void InitializeDiagram()
        {
            var model = new GraphLinksModel<DiagramNode, String, String, DiagramLink>
            {
                NodesSource = new ObservableCollection<DiagramNode>(),
                LinksSource = new ObservableCollection<DiagramLink>(),
                Modifiable = true,
                HasUndoManager = true
            };

            model.Changed += OnDiagramModelChanged;

            Diagram.LinkingTool = new DiagramLinkingTool();
            Diagram.Model = model;
            Diagram.AllowDrop = true;

            Diagram.LinkDrawn += (sender, args) =>
            {
                DiagramProcessor.Process(Diagram.Nodes);
            };

            Diagram.LinkRelinked += (sender, args) =>
            {
                DiagramProcessor.Process(Diagram.Nodes);
            };
        }

        private void OnDiagramSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChanged.SafeInvoke(SelectedNode);
        }

        private void OnDiagramModelChanged(object sender, ModelChangedEventArgs args)
        {
            var colorNodeChangedColor = (args.Change == ModelChange.Property && args.PropertyName == "Color" && (args.Data is DiagramNodeColor));
            var operationNodeChangedMode = (args.Change == ModelChange.Property && args.PropertyName == "Mode" && (args.Data is DiagramNodeOperation));
            var removedLink = (args.Change == ModelChange.RemovedLink);

            if (colorNodeChangedColor || operationNodeChangedMode || removedLink)
            {
                DiagramProcessor.Process(Diagram.Nodes);
            }
        }

        private void ExecutedCopyColor(object sender, ExecutedRoutedEventArgs e)
        {
            var node = SelectedNode;

            if (node != null)
            {
                var color = node.GetColor();

                Clipboard.SetText(color.ToString());
            }
        }

        private void CanExecuteCopyColor(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        private DiagramNode SelectedNode
        {
            get
            {
                var elements = Diagram.SelectedParts.OfType<Node>().Select(i => i.Data).OfType<DiagramNode>();
                var selectedElement = elements.FirstOrDefault();

                return selectedElement;
            }
        }
    }
}
