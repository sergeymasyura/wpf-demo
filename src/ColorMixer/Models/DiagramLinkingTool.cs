// Copyright 2015 Sergey Masyura. All rights reserved.

using System.Windows;
using ColorMixer.Utils;
using Northwoods.GoXam;
using Northwoods.GoXam.Tool;

namespace ColorMixer.Models
{
    /// <summary>
    /// Tool to validate links between all posible nodes/ports.
    /// </summary>
    public class DiagramLinkingTool : LinkingTool
    {
        /// <summary>
        /// This predicate should be true when it is logically valid to connect a link
        /// from one node/port to another node/port.
        /// </summary>
        public override bool IsValidLink(Node fromnode, FrameworkElement fromport, Node tonode, FrameworkElement toport)
        {
            if (! base.IsValidLink(fromnode, fromport, tonode, toport))
            {
                return false;
            }

            var colorToOperation = (fromnode.Data is DiagramNodeColor && tonode.Data is DiagramNodeOperation);
            var operationToOperation = (fromnode.Data is DiagramNodeOperation && tonode.Data is DiagramNodeOperation &&
                                        (fromnode.Data != tonode.Data) && !DiagramHelper.IsAncestor(fromnode, tonode));

            var result = colorToOperation || operationToOperation;

            return result;
        }
    }
}
