using FlowTask_Backend;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FlowTask_WinForms_Frontent
{
    public class NodeDecorator : Node
    {
        public NodeDecorator(Node n) : base(n.NodeID, n.Name, n.TimeWeight, n.Complete, n.Date, n.Text, n.GraphID, n.NodeIndex)
        {

        }

        private Color c = Color.FromArgb(0, 0, 0);

        public Color DrawColor
        {
            get
            {
                if (c != Color.FromArgb(0, 0, 0))
                    return c;
                return (c = RandColor());
            }
        }

        static readonly List<string> UsedColors = new List<string>();

        private Color RandColor()
        {
            Random x = new Random();
            int r, g, b;
            Color myRgbColor = new Color();
            while (true)
            {
                r = x.Next(100, 200);
                g = x.Next(100, 200);
                b = x.Next(100, 200);
                if (!UsedColors.Contains(r + "," + g + "," + b))
                {
                    UsedColors.Add(r + "," + g + "," + b);
                    break;
                }
            }
            myRgbColor = Color.FromArgb(r, g, b);
            return myRgbColor;
        }
    }
}
