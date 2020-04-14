namespace FlowTask_WinForms_Frontent
{
    partial class MainPage
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTasks = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.sfCalendarOverview = new Syncfusion.WinForms.Input.SfCalendar();
            this.sfDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Crimson;
            this.lblWelcome.Location = new System.Drawing.Point(26, 27);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(221, 22);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to FlowTask, ";
            // 
            // lblTasks
            // 
            this.lblTasks.AutoSize = true;
            this.lblTasks.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasks.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTasks.Location = new System.Drawing.Point(59, 71);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(224, 22);
            this.lblTasks.TabIndex = 3;
            this.lblTasks.Text = "Let\'s make a new Task!";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(30, 632);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(124, 45);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View Task";
            this.btnView.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(233, 632);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 45);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete Task";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDeleteClick);
            // 
            // sfCalendarOverview
            // 
            this.sfCalendarOverview.Culture = new System.Globalization.CultureInfo("en-US");
            this.sfCalendarOverview.Location = new System.Drawing.Point(732, -2);
            this.sfCalendarOverview.Name = "sfCalendarOverview";
            this.sfCalendarOverview.Size = new System.Drawing.Size(504, 510);
            this.sfCalendarOverview.TabIndex = 6;
            this.sfCalendarOverview.Text = "sfCalendar1";
            // 
            // sfDataGrid
            // 
            this.sfDataGrid.AccessibleName = "Table";
            this.sfDataGrid.AllowDraggingColumns = true;
            this.sfDataGrid.AllowFiltering = true;
            this.sfDataGrid.AllowResizingColumns = true;
            this.sfDataGrid.AllowResizingHiddenColumns = true;
            this.sfDataGrid.AutoGenerateColumns = false;
            this.sfDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            this.sfDataGrid.BackColor = System.Drawing.SystemColors.Window;
            this.sfDataGrid.Location = new System.Drawing.Point(21, 120);
            this.sfDataGrid.Name = "sfDataGrid";
            this.sfDataGrid.RowHeight = 21;
            this.sfDataGrid.Size = new System.Drawing.Size(677, 445);
            this.sfDataGrid.TabIndex = 1;
            this.sfDataGrid.Text = "sfDataGrid1";
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCreateTask.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCreateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTask.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTask.Location = new System.Drawing.Point(422, 632);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(124, 45);
            this.btnCreateTask.TabIndex = 7;
            this.btnCreateTask.Text = "Create Task";
            this.btnCreateTask.UseVisualStyleBackColor = false;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(462, 16);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(124, 45);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogoutClicked);
            // 
            // flowLayout
            // 
            this.flowLayout.Location = new System.Drawing.Point(732, 524);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(504, 192);
            this.flowLayout.TabIndex = 9;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 748);
            this.Controls.Add(this.flowLayout);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCreateTask);
            this.Controls.Add(this.sfDataGrid);
            this.Controls.Add(this.sfCalendarOverview);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblTasks);
            this.Controls.Add(this.lblWelcome);
            this.Name = "MainPage";
            this.Text = "FlowTask";
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnDelete;
        private Syncfusion.WinForms.Input.SfCalendar sfCalendarOverview;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid;
        private System.Windows.Forms.Button btnCreateTask;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
    }
}