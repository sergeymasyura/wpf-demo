// Copyright 2015 Sergey Masyura. All rights reserved.

using System;
using System.ComponentModel;
using Northwoods.GoXam.Model;

namespace ColorMixer.Models
{
    /// <summary>
    /// Base class for the nodes on the diagram.
    /// </summary>
    public class DiagramNode : GraphLinksModelNodeData<String>
    {
        /// <summary>
        /// Name of the node on the toolbox.
        /// </summary>
        [Browsable(false)]
        public string Name { get; set; }

        /// <summary>
        /// The icon of the node on the toolbox.
        /// </summary>
        [Browsable(false)]
        public Uri Icon { get; set; }

        /// <summary>
        /// Indicates if the node supports incoming links.
        /// </summary>
        [Browsable(false)]
        public bool IsLinkableTo { get; protected set; }
    }
}
