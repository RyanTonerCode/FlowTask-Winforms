using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FlowTask_WinForms_Frontent
{
    public partial class ViewTask : Form
    {
        public ViewTask()
        {
            InitializeComponent();
            DiagramAppearance();
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

        private void ViewTask_Load(object sender, EventArgs e)
        {

        }
    }
}
