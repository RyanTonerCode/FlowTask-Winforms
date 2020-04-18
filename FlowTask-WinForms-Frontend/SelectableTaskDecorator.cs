using FlowTask_Backend;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FlowTask_WinForms_Frontend
{
    /// <summary>
    /// Decorator that allows tasks to be selected in the grid view and associated with a given color
    /// </summary>
    public class SelectableTaskDecorator : Task
    {

        /// <summary>
        /// Construct a selectable task decorator for a given task
        /// </summary>
        /// <param name="t"></param>
        public SelectableTaskDecorator(Task t) : base(t.TaskID, t.AssignmentName, t.GraphID, t.SubmissionDate, t.Category, t.UserID)
        {
            AddGraph(t.Decomposition);
        }

        public bool Selected { get; set; }

        private Color c = Color.FromArgb(0, 0, 0);

        /// <summary>
        /// Retrieve a color for this Task
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
        /// Generate a random and unused task color
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
