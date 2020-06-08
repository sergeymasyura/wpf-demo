// Copyright 2015 Sergey Masyura. All rights reserved.

using System.Linq;
using System.Windows.Media;
using ColorMixer.Models;
using Northwoods.GoXam;

namespace ColorMixer.Utils
{
    /// <summary>
    /// Helper class for the diagram nodes.
    /// </summary>
    public static class DiagramHelper
    {
        /// <summary>
        /// Checks if 'parent' node contains 'child' node in the sub-graph.
        /// </summary>
        public static bool IsAncestor(Node parent, Node child)
        {
            var result = false;

            if (! parent.NodesInto.Any())
            {
                return false;
            }

            if (parent.NodesInto.Contains(child))
            {
                return true;
            }

            foreach (var node in parent.NodesInto)
            {
                result = result || IsAncestor(node, child);
            }

            return result;
        }

        /// <summary>
        /// Gets the color of the node.
        /// </summary>
        public static Color GetColor(this Node node)
        {
            var result = ((DiagramNode) node.Data).GetColor();

            return result;
        }

        /// <summary>
        /// Sets the color of the node.
        /// </summary>
        public static void SetColor(this Node node, Color color)
        {
            if (node.Data is DiagramNodeColor)
            {
                ((DiagramNodeColor)(node.Data)).Color = color;
            }
            else if (node.Data is DiagramNodeOperation)
            {
                ((DiagramNodeOperation)(node.Data)).Color = color;
            }
        }

        /// <summary>
        /// Gets the color of the diagram node.
        /// </summary>
        public static Color GetColor(this DiagramNode node)
        {
            var result = Colors.Transparent;

            if (node is DiagramNodeColor)
            {
                result = ((DiagramNodeColor)(node)).Color;
            }
            else if (node is DiagramNodeOperation)
            {
                result = ((DiagramNodeOperation)(node)).Color;
            }

            return result;
        }
    }
}
