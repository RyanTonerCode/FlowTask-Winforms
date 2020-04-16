using FlowTask_Backend;
using Syncfusion.Windows.Forms.Diagram;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public partial class ViewTaskForm : Form
    {
        private Task myTask;

        readonly ObservableCollection<NodeDecorator> nodes = ObservableCollections.ObservableNodeCollection;

        public ViewTaskForm(Task toShow)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;

            myTask = toShow;
            DateTime firstDate = DateTime.Now;
            if (myTask != null)
            {
                Text = string.Format("View Task {0}", myTask.AssignmentName);
                foreach (var n in myTask.Decomposition.Nodes)
                    nodes.Add(new NodeDecorator(n));

                firstDate = myTask.Decomposition.GetSoonestDate();
            }

            sfTreeDiagram.BeginUpdate();
            DiagramAppearance();
            PopulateNodes();


            DirectedTreeLayoutManager dtlm = new DirectedTreeLayoutManager(sfTreeDiagram.Model, 0, 40, 50)
            {
                TopMargin = 1,
                LeftMargin = 50,
                AutoLayout = false
            };
            sfTreeDiagram.LayoutManager = dtlm;
            sfTreeDiagram.LayoutManager.UpdateLayout(null);

            sfTreeDiagram.AlignCenter();

            sfTreeDiagram.View.SelectionList.Clear();

            sfTreeDiagram.EndUpdate();

            sfNodeCalendar.DrawCell += SfCalendarDrawCell;
            sfNodeCalendar.SelectionChanged += SfCalendarOverview_SelectionChanged;
            sfNodeCalendar.SelectedDate = firstDate;
            sfNodeCalendar.GoToDate(firstDate);

            sfNodeCalendar.TrailingDatesVisible = true;
        }

        #region Diagram
        private void DiagramAppearance()
        {
            sfTreeDiagram.Model.LineStyle.LineColor = Color.LightGray;
            sfTreeDiagram.Model.RenderingStyle.SmoothingMode = SmoothingMode.HighQuality;
            sfTreeDiagram.Model.BoundaryConstraintsEnabled = false;
            sfTreeDiagram.View.BackgroundColor = Color.White;
            sfTreeDiagram.View.HandleRenderer.HandleColor = Color.AliceBlue;
            sfTreeDiagram.View.HandleRenderer.HandleOutlineColor = Color.SkyBlue;
            sfTreeDiagram.View.SelectionList.Clear();
        }

        string GetNodeText(FlowTask_Backend.Node n)
        {
            return string.Format("{0} due on {1}", n.Name, n.Date.ToString("dddd, dd MMMM yyyy"));
        }

        /// <summary>
        /// Initialize the nodes in daigram
        /// </summary>
        private void PopulateNodes()
        {
            //get the root rode
            FlowTask_Backend.Node root = nodes[0];

            //first level of nodes
            Syncfusion.Windows.Forms.Diagram.Rectangle rootRectangle = new Syncfusion.Windows.Forms.Diagram.Rectangle(0, 0, 120, 80);
            rootRectangle.FillStyle.Color = Color.FromArgb(242, 242, 242);
            rootRectangle.FillStyle.Type = FillStyleType.LinearGradient;
            rootRectangle.FillStyle.ForeColor = Color.White;

            Syncfusion.Windows.Forms.Diagram.Label label = new Syncfusion.Windows.Forms.Diagram.Label(rootRectangle, GetNodeText(root));
            label.FontStyle.Family = "Segoe UI";
            label.FontStyle.Size = 10;
            label.FontColorStyle.Color = Color.Black;
            rootRectangle.Labels.Add(label);

            sfTreeDiagram.Model.AppendChild(rootRectangle);


            foreach (var neighbor in myTask.Decomposition.GetNeighbors(root.NodeIndex))
                GenerateInnerLevelNodes(rootRectangle, nodes[neighbor.NodeIndex]);
        }

        /// <summary>
        /// Generates the inner level nodes
        /// </summary>
        /// <param name="parentRect">Parent Node</param>
        /// <param name="maxSubNodes">Maximum sub nodes</param>
        /// <param name="LevelColor">Node's Fill color</param>
        /// <param name="connectionColor">Node's fore color</param>
        /// <param name="n">nodes level count</param>
        private void GenerateInnerLevelNodes(Syncfusion.Windows.Forms.Diagram.Node parentRect, NodeDecorator curNode)
        {
            Syncfusion.Windows.Forms.Diagram.Rectangle childRect = new Syncfusion.Windows.Forms.Diagram.Rectangle(0, 0, 120, 80);
            childRect.FillStyle.Color = Color.FromArgb(242, 242, 242);
            childRect.FillStyle.Type = FillStyleType.LinearGradient;
            childRect.FillStyle.ForeColor = curNode.DrawColor;
            sfTreeDiagram.Model.AppendChild(childRect);

            Syncfusion.Windows.Forms.Diagram.Label label = new Syncfusion.Windows.Forms.Diagram.Label(childRect, GetNodeText(curNode));
            label.FontStyle.Family = "Segoe UI";
            label.FontStyle.Size = 10;
            label.FontColorStyle.Color = Color.Black;
            childRect.Labels.Add(label);

            ConnectNodes(parentRect, childRect);

            foreach (var neighbor in myTask.Decomposition.GetNeighbors(curNode.NodeIndex))
                GenerateInnerLevelNodes(childRect, nodes[neighbor.NodeIndex]);

        }

        /// <summary>
        /// Connects the given nodes
        /// </summary>
        /// <param name="parentNode">Parent Node</param>
        /// <param name="childNode">Child node</param>
        /// <param name="connectionColor">Connector Color</param>
        private void ConnectNodes(Syncfusion.Windows.Forms.Diagram.Node parentNode, Syncfusion.Windows.Forms.Diagram.Node childNode)
        {
            if (parentNode != null && childNode != null)
            {
                LineConnector lConnector = new LineConnector(PointF.Empty, new PointF(0, 1));
                lConnector.HeadDecorator.DecoratorShape = DecoratorShape.Filled45Arrow;
                lConnector.HeadDecorator.FillStyle.Color = Color.Black;
                parentNode.CentralPort.TryConnect(lConnector.TailEndPoint);
                childNode.CentralPort.TryConnect(lConnector.HeadEndPoint);
                sfTreeDiagram.Model.AppendChild(lConnector);
                sfTreeDiagram.Model.SendToBack(lConnector);
            }
        }
        #endregion

        private string isPlural(int value)
        {
            if (value == 1)
                return "";
            return "s";
        }

        private void drawDue(DateTime here)
        {
            Font f = new Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0);
            Font f2 = new Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0);

            flowLayout.FlowDirection = FlowDirection.TopDown;

            flowLayout.ForeColor = Color.White;
            flowLayout.BackColor = Color.White;

            flowLayout.Controls.Clear();
            var header = new System.Windows.Forms.Label()
            {
                Font = f,
                Text = string.Format("Nodes due on {0}", here.ToString("dddd, dd MMMM yyyy")),
                Padding = new Padding(4, 4, 4, 4),
                Margin = new Padding(0),
                Height = 40,
                Width = flowLayout.Width,
                ForeColor = Color.Black,
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
            };

            flowLayout.Controls.Add(header);

            int number = 0;
            foreach (var node in nodes)
                if (here.Day == node.Date.Day && here.Month == node.Date.Month && here.Year == node.Date.Year)
                {
                    string node_subtext = string.IsNullOrEmpty(node.Text) ? "" : string.Format("({0})", node.Text);

                    if (!node.Complete)
                    {
                        if (DateTime.Now > node.Date)
                        {
                            var amt = (DateTime.Now - node.Date).Days;
                            node_subtext = string.Format("{0} overdue by {1} day{2}", node_subtext, amt, isPlural(amt));
                        }
                        else if (DateTime.Now.Day == node.Date.Day)
                        {
                            node_subtext = string.Format("{0} is due today!", node_subtext);
                        }
                        else
                        {
                            var amt = (node.Date - DateTime.Now).Days;
                            node_subtext = string.Format("{0} Due in {1} day{2}", node_subtext, amt, isPlural(amt));
                        }
                    }
                    else
                    {
                        node_subtext = string.Format("{0} is complete!", node_subtext);
                    }

                    System.Windows.Forms.Label info = new System.Windows.Forms.Label()
                    {
                        Font = f2,
                        Text = string.Format("{0}. {1} {2}", ++number, node.Name, node_subtext),
                        Margin = new Padding(0),
                        Padding = new Padding(28, 4, 4, 4),
                        Height = 36,
                        BackColor = Color.White,
                        ForeColor = node.DrawColor,
                        Width = flowLayout.Width,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    CheckBox chbx = new SizableCheckBox
                    {
                        Size = new Size(22, 22),
                        Margin = new Padding(0),
                        Location = new Point(7, 7),
                        Padding = new Padding(0, 0, 0, 0),
                        Checked = node.Complete,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    chbx.CheckedChanged += (object sender, EventArgs e) => {
                        var result = chbx.Checked;
                        var (Success, ErrorMessage) = DatabaseController.dbController.UpdateComplete(Mediator.AuthCookie, myTask.UserID, node.NodeID, result);
                        if (Success)
                        {
                            node.SetCompleteStatus(result);
                            //update the task node to reflect the change.
                            myTask.Decomposition.Nodes[node.NodeIndex].SetCompleteStatus(result);
                            int x = myTask.RemainingFlowSteps;

                            drawDue(here);
                            Mediator.MainForm.Redraw();
                        }
                        else
                        {
                            MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    info.Controls.Add(chbx);

                    flowLayout.Controls.Add(info);
                }
        }

        private void SfCalendarOverview_SelectionChanged(SfCalendar sender, Syncfusion.WinForms.Input.Events.SelectionChangedEventArgs e)
        {
            drawDue(sender.SelectedDate.Value);
            sfNodeCalendar.GoToDate(sender.SelectedDate.Value);
        }

        void SfCalendarDrawCell(SfCalendar sender, Syncfusion.WinForms.Input.Events.DrawCellEventArgs args)
        {
            args.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            List<NodeDecorator> to_draw = new List<NodeDecorator>();

            if (args.IsTrailingDate)
                args.ForeColor = Color.DarkGray;

            DateTime here = args.Value.Value;

            foreach (var node in nodes)
                if (here.Day == node.Date.Day && here.Month == node.Date.Month && here.Year == node.Date.Year)
                    to_draw.Add(node);

            int startPosition = 0;

            foreach (var task in to_draw)
            {
                args.Handled = true;

                Color c = args.IsTrailingDate ? Color.DarkGray : Color.Black;

                TextRenderer.DrawText(args.Graphics, args.Value.Value.Day.ToString(), new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular), args.CellBounds, c, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                args.Graphics.FillRectangle(new SolidBrush(task.DrawColor), new System.Drawing.Rectangle((args.CellBounds.X + (args.CellBounds.Width - args.CellBounds.Width / 2)) - (to_draw.Count * 2) - (to_draw.Count * 6) - startPosition, (args.CellBounds.Y + (args.CellBounds.Height - 20)), 12, 12));
                startPosition -= 18;
            }

        }

    }
}
