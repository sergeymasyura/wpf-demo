// Copyright 2015 Sergey Masyura. All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using ColorMixer.Utils;
using Northwoods.GoXam;

namespace ColorMixer.Models
{
    /// <summary>
    /// Processes the nodes trees and mixes the colors.
    /// </summary>
    public static class DiagramProcessor
    {
        /// <summary>
        /// Processes all nodes/links and calculate colors of operation nodes.
        /// </summary>
        /// <param name="nodes">Nodes on the diagram.</param>
        public static void Process(IEnumerable<Node> nodes)
        {
            var operationNodes = new List<Node>();

            foreach (var node in nodes)
            {
                if (node.Data is DiagramNodeOperation)
                {
                    operationNodes.Add(node);
                    node.SetColor(Colors.Transparent);
                }
            }

            if (!operationNodes.Any())
            {
                return;
            }

            foreach (Node node in operationNodes)
            {
                ProcessOperationNode(node);
            }
        }

        /// <summary>
        /// Recusively goes through the sub-tree to calculate colors of operation nodes.
        /// </summary>
        private static void ProcessOperationNode(Node node)
        {
            if (node.LinksInto.Count() != 2)
            {
                node.SetColor(Colors.Transparent);
            }
            else
            {
                var nodesInto = node.NodesInto.ToList();
                var operationNode = (DiagramNodeOperation)node.Data;

                if (nodesInto.Count == 2 && nodesInto.All(n => n.Data is DiagramNodeColor))
                {
                    MixNodes(nodesInto[0], nodesInto[1], operationNode);
                }
                else
                {
                    var operationSubnodes = nodesInto.Where(n => n.Data is DiagramNodeOperation).ToList();

                    if (operationSubnodes.All(sn => (sn.GetColor() != Colors.Transparent)))
                    {
                        MixNodes(nodesInto[0], nodesInto[1], operationNode);
                    }
                    else
                    {
                        foreach (var subnode in operationSubnodes)
                        {
                            ProcessOperationNode(subnode);
                        }

                        if (operationSubnodes.All(sn => (sn.GetColor() != Colors.Transparent)))
                        {
                            MixNodes(nodesInto[0], nodesInto[1], operationNode);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Blends the colors from two nodes and set it to operationNode.
        /// </summary>
        private static void MixNodes(Node subnode1, Node subnode2, DiagramNodeOperation operationNode)
        {
            var color1 = subnode1.GetColor();
            var color2 = subnode2.GetColor();
            var blend = ((int)operationNode.Mode) / 100f;

            operationNode.Color = color1.Blend(color2, blend);
        }
    }
}
