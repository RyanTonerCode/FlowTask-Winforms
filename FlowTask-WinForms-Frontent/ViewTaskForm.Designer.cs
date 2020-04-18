namespace FlowTask_WinForms_Frontent
{
    partial class ViewTaskForm
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
            Syncfusion.Windows.Forms.Diagram.Binding binding2 = new Syncfusion.Windows.Forms.Diagram.Binding();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTaskForm));
            this.sfDecompositionDiagram = new Syncfusion.Windows.Forms.Diagram.Controls.Diagram(this.components);
            this.treeModel = new Syncfusion.Windows.Forms.Diagram.Model(this.components);
            this.sfNodeCalendar = new Syncfusion.WinForms.Input.SfCalendar();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.sfDecompositionDiagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeModel)).BeginInit();
            this.SuspendLayout();
            // 
            // sfTreeDiagram
            // 
            this.sfDecompositionDiagram.BackColor = System.Drawing.Color.DarkGray;
            binding2.DefaultConnector = null;
            binding2.DefaultNode = null;
            binding2.Diagram = this.sfDecompositionDiagram;
            binding2.Id = null;
            binding2.Label = ((System.Collections.Generic.List<string>)(resources.GetObject("binding2.Label")));
            binding2.ParentId = null;
            this.sfDecompositionDiagram.Binding = binding2;
            this.sfDecompositionDiagram.Controller.Constraint = Syncfusion.Windows.Forms.Diagram.Constraints.PageEditable;
            this.sfDecompositionDiagram.Controller.DefaultConnectorTool = Syncfusion.Windows.Forms.Diagram.ConnectorTool.OrgLineConnectorTool;
            this.sfDecompositionDiagram.Controller.PasteOffset = new System.Drawing.SizeF(10F, 10F);
            this.sfDecompositionDiagram.EnableTouchMode = false;
            this.sfDecompositionDiagram.LayoutManager = null;
            this.sfDecompositionDiagram.Location = new System.Drawing.Point(0, 0);
            this.sfDecompositionDiagram.Margin = new System.Windows.Forms.Padding(0);
            this.sfDecompositionDiagram.MetroScrollBars = true;
            this.sfDecompositionDiagram.Model = this.treeModel;
            this.sfDecompositionDiagram.Name = "sfTreeDiagram";
            this.sfDecompositionDiagram.ScrollVirtualBounds = ((System.Drawing.RectangleF)(resources.GetObject("sfTreeDiagram.ScrollVirtualBounds")));
            this.sfDecompositionDiagram.Size = new System.Drawing.Size(1358, 368);
            this.sfDecompositionDiagram.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.sfDecompositionDiagram.SmartSizeBox = false;
            this.sfDecompositionDiagram.TabIndex = 9;
            this.sfDecompositionDiagram.Text = "diagram1";
            // 
            // 
            // 
            this.sfDecompositionDiagram.View.ClientRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.sfDecompositionDiagram.View.Controller = this.sfDecompositionDiagram.Controller;
            this.sfDecompositionDiagram.View.Grid.MinPixelSpacing = 4F;
            this.sfDecompositionDiagram.View.Grid.Visible = false;
            this.sfDecompositionDiagram.View.ScrollVirtualBounds = ((System.Drawing.RectangleF)(resources.GetObject("resource.ScrollVirtualBounds")));
            this.sfDecompositionDiagram.View.ZoomType = Syncfusion.Windows.Forms.Diagram.ZoomType.Center;
            // 
            // treeModel
            // 
            this.treeModel.AlignmentType = AlignmentType.SelectedNode;
            this.treeModel.BackgroundStyle.PathBrushStyle = Syncfusion.Windows.Forms.Diagram.PathGradientBrushStyle.RectangleCenter;
            this.treeModel.DocumentScale.DisplayName = "No Scale";
            this.treeModel.DocumentScale.Height = 1F;
            this.treeModel.DocumentScale.Width = 1F;
            this.treeModel.DocumentSize.Height = 600F;
            this.treeModel.DocumentSize.Width = 1370F;
            this.treeModel.LineStyle.DashPattern = null;
            this.treeModel.LineStyle.LineColor = System.Drawing.Color.Black;
            this.treeModel.LineStyle.LineWidth = 0F;
            this.treeModel.LogicalSize = new System.Drawing.SizeF(1370F, 600F);
            this.treeModel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.treeModel.ShadowStyle.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.treeModel.ShadowStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            // 
            // sfNodeCalendar
            // 
            this.sfNodeCalendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.sfNodeCalendar.Location = new System.Drawing.Point(0, 368);
            this.sfNodeCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.sfNodeCalendar.Name = "sfNodeCalendar";
            this.sfNodeCalendar.NumberOfWeeksInView = 5;
            this.sfNodeCalendar.SelectedDate = new System.DateTime(2020, 4, 15, 0, 0, 0, 0);
            this.sfNodeCalendar.Size = new System.Drawing.Size(742, 394);
            this.sfNodeCalendar.TabIndex = 7;
            this.sfNodeCalendar.Text = "sfCalendar1";
            // 
            // flowLayout
            // 
            this.flowLayout.Location = new System.Drawing.Point(742, 368);
            this.flowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(616, 394);
            this.flowLayout.TabIndex = 10;
            // 
            // ViewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 761);
            this.Controls.Add(this.flowLayout);
            this.Controls.Add(this.sfDecompositionDiagram);
            this.Controls.Add(this.sfNodeCalendar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ViewTask";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ViewTask";
            ((System.ComponentModel.ISupportInitialize)(this.sfDecompositionDiagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.Input.SfCalendar sfNodeCalendar;
        private Syncfusion.Windows.Forms.Diagram.Controls.Diagram sfDecompositionDiagram;
        private Syncfusion.Windows.Forms.Diagram.Model treeModel;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
    }
}