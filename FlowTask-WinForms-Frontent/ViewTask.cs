using FlowTask_Backend;
using Syncfusion.Windows.Forms.Diagram;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public partial class ViewTask : Form
    {
        readonly Task myTask;

        ObservableCollection<NodeDecorator> nodes = ObservableCollections.ObservableNodeCollection;

        public ViewTask(Task toShow)
        {
            InitializeComponent();

            myTask = toShow;
            Text = string.Format("View Task {0}", myTask.AssignmentName);
            foreach (var n in myTask.Decomposition.Nodes)
                nodes.Add(new NodeDecorator(n));

            diagram1.BeginUpdate();
            DiagramAppearance();
            PopulateNodes();

            DirectedTreeLayoutManager dtlm = new DirectedTreeLayoutManager(diagram1.Model, 0, 40, 50)
            {
                TopMargin = 1,
                LeftMargin = 50,
            };
            diagram1.LayoutManager = dtlm;
            diagram1.LayoutManager.UpdateLayout(null);

            diagram1.View.SelectionList.Clear();

            diagram1.EndUpdate();

            DoubleBuffered = true;

            sfCalendarOverview.DrawCell += SfCalendarDrawCell;
            sfCalendarOverview.SelectionChanged += SfCalendarOverview_SelectionChanged;
        }

        #region Diagram
        private void DiagramAppearance()
        {
           diagram1.Model.LineStyle.LineColor = Color.LightGray;
           diagram1.Model.RenderingStyle.SmoothingMode = SmoothingMode.HighQuality;
           diagram1.Model.BoundaryConstraintsEnabled = false;
           diagram1.View.BackgroundColor = Color.White;
           diagram1.View.HandleRenderer.HandleColor = Color.AliceBlue;
           diagram1.View.HandleRenderer.HandleOutlineColor = Color.SkyBlue;
           diagram1.View.SelectionList.Clear();
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

            diagram1.Model.AppendChild(rootRectangle);

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
            diagram1.Model.AppendChild(childRect);

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
                diagram1.Model.AppendChild(lConnector);
                diagram1.Model.SendToBack(lConnector);
            }
        }
        #endregion

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
                    System.Windows.Forms.Label info = new System.Windows.Forms.Label()
                    {
                        Font = f2,
                        Text = string.Format("{0}. {1} ({2})", ++number, node.Name, node.Text),
                        Margin = new Padding(0),
                        Padding = new Padding(15, 4, 4, 4),
                        Height = 35,
                        BackColor = Color.White,
                        ForeColor = node.DrawColor,
                        Width = flowLayout.Width,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    flowLayout.Controls.Add(info);
                }
        }

        private void SfCalendarOverview_SelectionChanged(SfCalendar sender, Syncfusion.WinForms.Input.Events.SelectionChangedEventArgs e)
        {
            drawDue(sender.SelectedDate.Value);
            
        }

        void SfCalendarDrawCell(SfCalendar sender, Syncfusion.WinForms.Input.Events.DrawCellEventArgs args)
        {
            args.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            if (args.IsTrailingDate)
            {
                // Customize the cell appearance using options from DrawCellEventArgs
                args.ForeColor = Color.DarkGray;
            }

            List<NodeDecorator> to_draw = new List<NodeDecorator>();

            DateTime here = args.Value.Value;

            foreach (var node in nodes)
                if (here.Day == node.Date.Day && here.Month == node.Date.Month && here.Year == node.Date.Year)
                    to_draw.Add(node);

            int startPosition = 0;

            foreach (var task in to_draw)
            {
                args.Handled = true;

                TextRenderer.DrawText(args.Graphics, args.Value.Value.Day.ToString(), new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular), args.CellBounds, Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                args.Graphics.FillRectangle(new SolidBrush(task.DrawColor), new System.Drawing.Rectangle((args.CellBounds.X + (args.CellBounds.Width - args.CellBounds.Width / 2)) - (to_draw.Count * 2) - (to_draw.Count * 6) - startPosition, (args.CellBounds.Y + (args.CellBounds.Height - 20)), 12, 12));
                startPosition -= 18;
            }

        }

    }
}
