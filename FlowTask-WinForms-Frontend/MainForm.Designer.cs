namespace FlowTask_WinForms_Frontend
{
    partial class MainForm
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
            this.sfTaskCalendar = new Syncfusion.WinForms.Input.SfCalendar();
            this.sfTaskDataGrid = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.flwTaskLayout = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.sfTaskDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Crimson;
            this.lblWelcome.Location = new System.Drawing.Point(26, 27);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(318, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to FlowTask, ";
            // 
            // lblTasks
            // 
            this.lblTasks.AutoSize = true;
            this.lblTasks.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasks.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTasks.Location = new System.Drawing.Point(79, 72);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(224, 22);
            this.lblTasks.TabIndex = 3;
            this.lblTasks.Text = "Let\'s make a new Task!";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.LightBlue;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(30, 645);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(124, 45);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View Task";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightBlue;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(272, 645);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 45);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete Task";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDeleteClick);
            // 
            // sfCalendarOverview
            // 
            this.sfTaskCalendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.sfTaskCalendar.Location = new System.Drawing.Point(732, -2);
            this.sfTaskCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.sfTaskCalendar.Name = "sfCalendarOverview";
            this.sfTaskCalendar.Size = new System.Drawing.Size(504, 510);
            this.sfTaskCalendar.TabIndex = 6;
            this.sfTaskCalendar.Text = "sfCalendar1";
            // 
            // sfDataGrid
            // 
            this.sfTaskDataGrid.AccessibleName = "Table";
            this.sfTaskDataGrid.AllowDraggingColumns = true;
            this.sfTaskDataGrid.AllowFiltering = true;
            this.sfTaskDataGrid.AllowResizingColumns = true;
            this.sfTaskDataGrid.AllowResizingHiddenColumns = true;
            this.sfTaskDataGrid.AutoGenerateColumns = false;
            this.sfTaskDataGrid.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            this.sfTaskDataGrid.BackColor = System.Drawing.SystemColors.Window;
            this.sfTaskDataGrid.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sfTaskDataGrid.Location = new System.Drawing.Point(1, 109);
            this.sfTaskDataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.sfTaskDataGrid.Name = "sfDataGrid";
            this.sfTaskDataGrid.RowHeight = 21;
            this.sfTaskDataGrid.Size = new System.Drawing.Size(731, 493);
            this.sfTaskDataGrid.TabIndex = 1;
            this.sfTaskDataGrid.Text = "sfDataGrid1";
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.BackColor = System.Drawing.Color.LightBlue;
            this.btnCreateTask.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCreateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTask.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTask.Location = new System.Drawing.Point(531, 645);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(124, 45);
            this.btnCreateTask.TabIndex = 7;
            this.btnCreateTask.Text = "Create Task";
            this.btnCreateTask.UseVisualStyleBackColor = false;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightBlue;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(593, 27);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(124, 45);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogoutClicked);
            // 
            // flowLayout
            // 
            this.flwTaskLayout.Location = new System.Drawing.Point(732, 508);
            this.flwTaskLayout.Margin = new System.Windows.Forms.Padding(0);
            this.flwTaskLayout.Name = "flowLayout";
            this.flwTaskLayout.Size = new System.Drawing.Size(504, 240);
            this.flwTaskLayout.TabIndex = 9;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1234, 748);
            this.Controls.Add(this.flwTaskLayout);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCreateTask);
            this.Controls.Add(this.sfTaskDataGrid);
            this.Controls.Add(this.sfTaskCalendar);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblTasks);
            this.Controls.Add(this.lblWelcome);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "FlowTask";
            this.Load += new System.EventHandler(this.mainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfTaskDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnDelete;
        private Syncfusion.WinForms.Input.SfCalendar sfTaskCalendar;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfTaskDataGrid;
        private System.Windows.Forms.Button btnCreateTask;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.FlowLayoutPanel flwTaskLayout;
    }
}