using FlowTask_Backend;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FlowTask_WinForms_Frontend
{
    /// <summary>
    /// Decorates a node with a draw color
    /// </summary>
    public class NodeDecorator : Node
    {
        /// <summary>
        /// create a node decorator for a given node
        /// </summary>
        /// <param name="n"></param>
        public NodeDecorator(Node n) : base(n.NodeID, n.Name, n.TimeWeight, n.Complete, n.Date, n.Text, n.GraphID, n.NodeIndex)
        {

        }

        private Color c = Color.FromArgb(0, 0, 0);

        /// <summary>
        /// Retrieve a color for this node
        /// </summary>
        public Color DrawColor
        {
            get
            {
                if (c != Color.FromArgb(0, 0, 0))
                    return c;
                return (c = randColor());
            }
        }

        static readonly List<string> UsedColors = new List<string>();

        static readonly Random randy = new Random();

        /// <summary>
        /// Generate a random and unused node color
        /// </summary>
        /// <returns></returns>
        private Color randColor()
        {
            int r, g, b;
            while (true)
            {
                r = randy.Next(100, 200);
                g = randy.Next(100, 200);
                b = randy.Next(100, 200);
                if (!UsedColors.Contains(r + "," + g + "," + b))
                {
                    UsedColors.Add(r + "," + g + "," + b);
                    break;
                }
            }
            Color myRgbColor = Color.FromArgb(r, g, b);
            return myRgbColor;
        }
    }
}
