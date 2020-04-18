using FlowTask_Backend;
using Syncfusion.Windows.Forms.Diagram;
using Syncfusion.WinForms.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public partial class ViewTaskForm : Form
    {
        /// <summary>
        /// The task this form is displaying
        /// </summary>
        private readonly Task myTask;

        /// <summary>
        /// Get an observable collection for this task's nodes
        /// </summary>
        readonly ObservableCollection<NodeDecorator> nodes = ObservableCollections.ObservableNodeCollection;

        /// <summary>
        /// Create a task view form for the inut task
        /// </summary>
        /// <param name="toShow"></param>
        public ViewTaskForm(Task toShow)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;

            //update ui relative to task info
            myTask = toShow;
            DateTime firstDate = DateTime.Now;
            if (myTask != null)
            {

                foreach (var n in myTask.Decomposition.Nodes)
                    nodes.Add(new NodeDecorator(n));

                firstDate = myTask.Decomposition.GetSoonestDate();
            }

            //create the diagram and set layout manager
            sfDecompositionDiagram.BeginUpdate();
            diagramAppearance();
            populateNodes();

            var dtlm = new DirectedTreeLayoutManager(sfDecompositionDiagram.Model, 0, 40, 50)
            {
                TopMargin = 1,
                LeftMargin = 50,
                AutoLayout = false
            };
            sfDecompositionDiagram.LayoutManager = dtlm;
            sfDecompositionDiagram.LayoutManager.UpdateLayout(null);
            sfDecompositionDiagram.View.SelectionList.Clear();
            sfDecompositionDiagram.EndUpdate();

            sfNodeCalendar.DrawCell += sfCalendarDrawCell;
            sfNodeCalendar.SelectionChanged += sfCalendarOverview_SelectionChanged;
            sfNodeCalendar.SelectedDate = firstDate;
            sfNodeCalendar.GoToDate(firstDate);

            sfNodeCalendar.TrailingDatesVisible = true;
        }

        #region Diagram Generation
        /// <summary>
        /// Set the model appearance
        /// </summary>
        private void diagramAppearance()
        {
            sfDecompositionDiagram.Model.LineStyle.LineColor = Color.LightGray;
            sfDecompositionDiagram.Model.RenderingStyle.SmoothingMode = SmoothingMode.HighQuality;
            sfDecompositionDiagram.Model.BoundaryConstraintsEnabled = false;
            sfDecompositionDiagram.View.BackgroundColor = Color.White;
            sfDecompositionDiagram.View.HandleRenderer.HandleColor = Color.AliceBlue;
            sfDecompositionDiagram.View.HandleRenderer.HandleOutlineColor = Color.SkyBlue;
            sfDecompositionDiagram.View.SelectionList.Clear();
        }

        /// <summary>
        /// Get the rectangle text for a given node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        string getNodeText(FlowTask_Backend.Node node)
        {
            return string.Format("{0} due on {1}", node.Name, node.Date.ToString("dddd, dd MMMM yyyy"));
        }

        /// <summary>
        /// Initialize the nodes in daigram
        /// </summary>
        private void populateNodes()
        {
            //get the root rode
            FlowTask_Backend.Node root = nodes[0];

            //first level of nodes
            Syncfusion.Windows.Forms.Diagram.Rectangle rootRectangle = new Syncfusion.Windows.Forms.Diagram.Rectangle(0, 0, 120, 80);
            rootRectangle.FillStyle.Color = Color.FromArgb(242, 242, 242);
            rootRectangle.FillStyle.Type = FillStyleType.LinearGradient;
            rootRectangle.FillStyle.ForeColor = Color.White;

            //give it a label with the node text
            Syncfusion.Windows.Forms.Diagram.Label label = new Syncfusion.Windows.Forms.Diagram.Label(rootRectangle, getNodeText(root));
            label.FontStyle.Family = "Segoe UI";
            label.FontStyle.Size = 10;
            label.FontColorStyle.Color = Color.Black;
            rootRectangle.Labels.Add(label);

            sfDecompositionDiagram.Model.AppendChild(rootRectangle);

            //recursively populate children
            foreach (var neighbor in myTask.Decomposition.GetNeighbors(root.NodeIndex))
                generateInnerLevelNodes(rootRectangle, nodes[neighbor.NodeIndex]);
        }

        /// <summary>
        /// Generates the inner level nodes
        /// </summary>
        /// <param name="parentRect">Parent Node</param>
        /// <param name="maxSubNodes">Maximum sub nodes</param>
        /// <param name="LevelColor">Node's Fill color</param>
        /// <param name="connectionColor">Node's fore color</param>
        /// <param name="n">nodes level count</param>
        private void generateInnerLevelNodes(Syncfusion.Windows.Forms.Diagram.Node parentRect, NodeDecorator curNode)
        {
            Syncfusion.Windows.Forms.Diagram.Rectangle childRect = new Syncfusion.Windows.Forms.Diagram.Rectangle(0, 0, 120, 80);
            childRect.FillStyle.Color = Color.FromArgb(242, 242, 242);
            childRect.FillStyle.Type = FillStyleType.LinearGradient;
            childRect.FillStyle.ForeColor = curNode.DrawColor;
            sfDecompositionDiagram.Model.AppendChild(childRect);

            Syncfusion.Windows.Forms.Diagram.Label label = new Syncfusion.Windows.Forms.Diagram.Label(childRect, getNodeText(curNode));
            label.FontStyle.Family = "Segoe UI";
            label.FontStyle.Size = 10;
            label.FontColorStyle.Color = Color.Black;
            childRect.Labels.Add(label);

            connectNodes(parentRect, childRect);

            //recursively populate children
            foreach (var neighbor in myTask.Decomposition.GetNeighbors(curNode.NodeIndex))
                generateInnerLevelNodes(childRect, nodes[neighbor.NodeIndex]);

        }

        /// <summary>
        /// Connects the given nodes with an arrow
        /// </summary>
        /// <param name="parentNode">Parent Node</param>
        /// <param name="childNode">Child node</param>
        /// <param name="connectionColor">Connector Color</param>
        private void connectNodes(Syncfusion.Windows.Forms.Diagram.Node parentNode, Syncfusion.Windows.Forms.Diagram.Node childNode)
        {
            if (parentNode != null && childNode != null)
            {
                LineConnector lConnector = new LineConnector(PointF.Empty, new PointF(0, 1));
                lConnector.HeadDecorator.DecoratorShape = DecoratorShape.Filled45Arrow;
                lConnector.HeadDecorator.FillStyle.Color = Color.Black;
                parentNode.CentralPort.TryConnect(lConnector.TailEndPoint);
                childNode.CentralPort.TryConnect(lConnector.HeadEndPoint);
                sfDecompositionDiagram.Model.AppendChild(lConnector);
                sfDecompositionDiagram.Model.SendToBack(lConnector);
            }
        }
        #endregion Information

        private static readonly Font nodeHeadingFont = new Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0);
        private static readonly Font nodeLabelFont = new Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, GraphicsUnit.Point, 0);

        private void drawNodesDue(DateTime here)
        {
            int nodesRemain = myTask.RemainingFlowSteps;
            Text = string.Format("View Task: {0} - {1} Node{2} Remaining", myTask.AssignmentName, nodesRemain, Mediator.IsPlural(nodesRemain));

            flowLayout.FlowDirection = FlowDirection.TopDown;

            flowLayout.ForeColor = Color.White;
            flowLayout.BackColor = Color.White;

            flowLayout.Controls.Clear();
            var lblHeader = new System.Windows.Forms.Label()
            {
                Font = nodeHeadingFont,
                Text = string.Format("Nodes due on {0}", here.ToString("dddd, dd MMMM yyyy")),
                Padding = new Padding(4, 4, 4, 4),
                Margin = new Padding(0),
                Height = 40,
                Width = flowLayout.Width,
                ForeColor = Color.Black,
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle,
            };

            flowLayout.Controls.Add(lblHeader);

            var now = DateTime.Now;

            int number = 0;
            foreach (var node in getDrawListForDay(here))
            {
                string node_subtext = string.IsNullOrEmpty(node.Text) ? "" : string.Format("({0})", node.Text);

                if (!node.Complete)
                {
                    if (now > node.Date && now.DayOfYear > node.Date.DayOfYear)
                    {
                        var offset_days = (now - node.Date).Days;
                        node_subtext = string.Format("{0} overdue by {1} day{2}", node_subtext, offset_days, Mediator.IsPlural(offset_days));
                    }
                    else if (now.DayOfYear == node.Date.DayOfYear && now.Year == node.Date.Year)
                    {
                        node_subtext = string.Format("{0} is due today!", node_subtext);
                    }
                    else
                    {
                        //due in the future
                        var offset_days = (node.Date - DateTime.Now).Days;
                        node_subtext = string.Format("{0} Due in {1} day{2}", node_subtext, offset_days, Mediator.IsPlural(offset_days));
                    }
                }
                else
                {
                    node_subtext = string.Format("{0} is complete!", node_subtext);
                }

                System.Windows.Forms.Label lblNodeInfo = new System.Windows.Forms.Label()
                {
                    Font = nodeLabelFont,
                    Text = string.Format("{0}. {1} {2}", ++number, node.Name, node_subtext),
                    Margin = new Padding(0),
                    Padding = new Padding(28, 4, 4, 4),
                    Height = 36,
                    BackColor = Color.White,
                    ForeColor = node.DrawColor,
                    Width = flowLayout.Width,
                    BorderStyle = BorderStyle.FixedSingle
                };

                //completion checkbox to left of label
                CheckBox chbx = new SizableCheckBox
                {
                    Size = new Size(22, 22),
                    Margin = new Padding(0),
                    Location = new Point(7, 7),
                    Padding = new Padding(0, 0, 0, 0),
                    Checked = node.Complete,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                //tool tip to say what the chckbox does
                var toolTip = new ToolTip
                {
                    ToolTipIcon = ToolTipIcon.Info,
                    IsBalloon = true,
                    ShowAlways = true
                };

                string toolTipText = "This node is incomplete. Check to mark as complete.";
                if (chbx.Checked)
                {

                    FlowTask_Backend.Node next = myTask.Decomposition.GetSoonestNode();

                    if (next != null && !string.IsNullOrEmpty(next.Name))
                        toolTipText = string.Format("This node is complete! The next node is {0}.", next.Name);
                    else
                        toolTipText = "This node is complete! There are no remaining nodes in this task.";
                }

                toolTip.SetToolTip(chbx, toolTipText);

                chbx.CheckedChanged += (object sender, EventArgs e) =>
                {
                    var result = chbx.Checked;
                    var (Success, ErrorMessage) = DatabaseController.GetDBController().UpdateComplete(Mediator.AuthCookie, myTask.UserID, node.NodeID, result);
                    if (Success)
                    {
                        node.SetCompleteStatus(result);
                        //update the task node to reflect the change.
                        myTask.Decomposition.Nodes[node.NodeIndex].SetCompleteStatus(result);
                        int x = myTask.RemainingFlowSteps;

                        drawNodesDue(here);
                        Mediator.MainForm.Redraw();
                    }
                    else
                    {
                        //the database failed to process the node completion update
                        MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                lblNodeInfo.Controls.Add(chbx);

                flowLayout.Controls.Add(lblNodeInfo);
            }
        }

        /// <summary>
        /// Redraw the nodes due panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sfCalendarOverview_SelectionChanged(SfCalendar sender, Syncfusion.WinForms.Input.Events.SelectionChangedEventArgs e)
        {
            //show nodes due on this date
            if (sender.SelectedDate.HasValue)
            {
                drawNodesDue(sender.SelectedDate.Value);
                //sfNodeCalendar.GoToDate(sender.SelectedDate.Value);
            }
        }

        /// <summary>
        /// List of nodes to draw for the day
        /// </summary>
        /// <param name="here"></param>
        /// <returns></returns>
        private List<NodeDecorator> getDrawListForDay(DateTime here)
        {
            return nodes.Where(x => x.Date.DayOfYear == here.DayOfYear && x.Date.Year == here.Year).ToList();
        }

        private void sfCalendarDrawCell(SfCalendar sender, Syncfusion.WinForms.Input.Events.DrawCellEventArgs args)
        {
            args.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (args.IsTrailingDate)
                args.ForeColor = Color.DarkGray;


            //ensure a date is selected
            if (!args.Value.HasValue)
                return;

            DateTime here = args.Value.Value;

            var drawList = getDrawListForDay(here);

            int startPosition = 0;

            foreach (var task in drawList)
            {
                args.Handled = true;

                Color c = args.IsTrailingDate ? Color.DarkGray : Color.Black;

                TextRenderer.DrawText(args.Graphics, args.Value.Value.Day.ToString(), new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular), args.CellBounds, c, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                args.Graphics.FillRectangle(new SolidBrush(task.DrawColor), new System.Drawing.Rectangle((args.CellBounds.X + (args.CellBounds.Width - args.CellBounds.Width / 2)) - (drawList.Count * 2) - (drawList.Count * 6) - startPosition, (args.CellBounds.Y + (args.CellBounds.Height - 20)), 13, 13));
                startPosition -= 18;
            }

        }

    }
}
