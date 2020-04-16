using FlowTask_Backend;
using Syncfusion.Windows.Forms.Diagram;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public partial class ViewTask : Form
    {
        readonly Task myTask;
        public ViewTask(Task toShow)
        {
            InitializeComponent();

            myTask = toShow;
            Text = string.Format("View Task {0}", myTask.AssignmentName);

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
        }

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
            FlowTask_Backend.Node root = myTask.Decomposition.Nodes[0];

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
                GenerateInnerLevelNodes(rootRectangle, neighbor);
        }

        /// <summary>
        /// Generates the inner level nodes
        /// </summary>
        /// <param name="parentRect">Parent Node</param>
        /// <param name="maxSubNodes">Maximum sub nodes</param>
        /// <param name="LevelColor">Node's Fill color</param>
        /// <param name="connectionColor">Node's fore color</param>
        /// <param name="n">nodes level count</param>
        private void GenerateInnerLevelNodes(Syncfusion.Windows.Forms.Diagram.Node parentRect, FlowTask_Backend.Node curNode)
        {
            Syncfusion.Windows.Forms.Diagram.Rectangle childRect = new Syncfusion.Windows.Forms.Diagram.Rectangle(0, 0, 120, 80);
            childRect.FillStyle.Color = Color.FromArgb(242, 242, 242);
            childRect.FillStyle.Type = FillStyleType.LinearGradient;
            childRect.FillStyle.ForeColor = Color.White;
            diagram1.Model.AppendChild(childRect);

            Syncfusion.Windows.Forms.Diagram.Label label = new Syncfusion.Windows.Forms.Diagram.Label(childRect, GetNodeText(curNode));
            label.FontStyle.Family = "Segoe UI";
            label.FontStyle.Size = 10;
            label.FontColorStyle.Color = Color.Black;
            childRect.Labels.Add(label);

            ConnectNodes(parentRect, childRect);

            foreach (var neighbor in myTask.Decomposition.GetNeighbors(curNode.NodeIndex))
                GenerateInnerLevelNodes(childRect, neighbor);

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


    }
}
