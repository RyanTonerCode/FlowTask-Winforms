namespace FlowTask_WinForms_Frontent
{
    partial class ViewTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Syncfusion.Windows.Forms.Diagram.Binding binding1 = new Syncfusion.Windows.Forms.Diagram.Binding();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTask));
            this.sfTreeDiagram = new Syncfusion.Windows.Forms.Diagram.Controls.Diagram(this.components);
            this.model1 = new Syncfusion.Windows.Forms.Diagram.Model(this.components);
            this.sfNodeCalendar = new Syncfusion.WinForms.Input.SfCalendar();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.sfTreeDiagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).BeginInit();
            this.SuspendLayout();
            // 
            // sfTreeDiagram
            // 
            this.sfTreeDiagram.BackColor = System.Drawing.Color.White;
            binding1.DefaultConnector = null;
            binding1.DefaultNode = null;
            binding1.Diagram = this.sfTreeDiagram;
            binding1.Id = null;
            binding1.Label = ((System.Collections.Generic.List<string>)(resources.GetObject("binding1.Label")));
            binding1.ParentId = null;
            this.sfTreeDiagram.Binding = binding1;
            this.sfTreeDiagram.Controller.Constraint = Syncfusion.Windows.Forms.Diagram.Constraints.PageEditable;
            this.sfTreeDiagram.Controller.DefaultConnectorTool = Syncfusion.Windows.Forms.Diagram.ConnectorTool.OrgLineConnectorTool;
            this.sfTreeDiagram.Controller.PasteOffset = new System.Drawing.SizeF(10F, 10F);
            this.sfTreeDiagram.EnableTouchMode = false;
            this.sfTreeDiagram.HScroll = true;
            this.sfTreeDiagram.LayoutManager = null;
            this.sfTreeDiagram.Location = new System.Drawing.Point(0, 0);
            this.sfTreeDiagram.Margin = new System.Windows.Forms.Padding(0);
            this.sfTreeDiagram.MetroScrollBars = true;
            this.sfTreeDiagram.Model = this.model1;
            this.sfTreeDiagram.Name = "sfTreeDiagram";
            this.sfTreeDiagram.ScrollVirtualBounds = ((System.Drawing.RectangleF)(resources.GetObject("sfTreeDiagram.ScrollVirtualBounds")));
            this.sfTreeDiagram.Size = new System.Drawing.Size(1358, 383);
            this.sfTreeDiagram.SmartSizeBox = false;
            this.sfTreeDiagram.TabIndex = 9;
            this.sfTreeDiagram.Text = "diagram1";
            // 
            // 
            // 
            this.sfTreeDiagram.View.BackgroundColor = System.Drawing.Color.White;
            this.sfTreeDiagram.View.ClientRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.sfTreeDiagram.View.Controller = this.sfTreeDiagram.Controller;
            this.sfTreeDiagram.View.Grid.MinPixelSpacing = 4F;
            this.sfTreeDiagram.View.Grid.Visible = false;
            this.sfTreeDiagram.View.ScrollVirtualBounds = ((System.Drawing.RectangleF)(resources.GetObject("resource.ScrollVirtualBounds")));
            this.sfTreeDiagram.View.ZoomType = Syncfusion.Windows.Forms.Diagram.ZoomType.Center;
            this.sfTreeDiagram.VScroll = true;
            // 
            // model1
            // 
            this.model1.AlignmentType = AlignmentType.SelectedNode;
            this.model1.BackgroundStyle.PathBrushStyle = Syncfusion.Windows.Forms.Diagram.PathGradientBrushStyle.RectangleCenter;
            this.model1.DocumentScale.DisplayName = "No Scale";
            this.model1.DocumentScale.Height = 1F;
            this.model1.DocumentScale.Width = 1F;
            this.model1.DocumentSize.Height = 1169F;
            this.model1.DocumentSize.Width = 1227F;
            this.model1.LineStyle.DashPattern = null;
            this.model1.LineStyle.LineColor = System.Drawing.Color.Black;
            this.model1.LineStyle.LineWidth = 0F;
            this.model1.LogicalSize = new System.Drawing.SizeF(1227F, 1169F);
            this.model1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.model1.ShadowStyle.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.model1.ShadowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            // 
            // sfNodeCalendar
            // 
            this.sfNodeCalendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.sfNodeCalendar.Location = new System.Drawing.Point(0, 383);
            this.sfNodeCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.sfNodeCalendar.Name = "sfNodeCalendar";
            this.sfNodeCalendar.NumberOfWeeksInView = 5;
            this.sfNodeCalendar.Size = new System.Drawing.Size(770, 365);
            this.sfNodeCalendar.TabIndex = 7;
            this.sfNodeCalendar.Text = "sfCalendar1";
            // 
            // flowLayout
            // 
            this.flowLayout.Location = new System.Drawing.Point(770, 383);
            this.flowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(588, 365);
            this.flowLayout.TabIndex = 10;
            // 
            // ViewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 747);
            this.Controls.Add(this.flowLayout);
            this.Controls.Add(this.sfTreeDiagram);
            this.Controls.Add(this.sfNodeCalendar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewTask";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ViewTask";
            ((System.ComponentModel.ISupportInitialize)(this.sfTreeDiagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.model1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.Input.SfCalendar sfNodeCalendar;
        private Syncfusion.Windows.Forms.Diagram.Controls.Diagram sfTreeDiagram;
        private Syncfusion.Windows.Forms.Diagram.Model model1;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
    }
}