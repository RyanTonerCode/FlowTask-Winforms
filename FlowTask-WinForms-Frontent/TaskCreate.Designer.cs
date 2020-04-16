namespace FlowTask_WinForms_Frontent
{
    partial class TaskCreate
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
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblAssignmentName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.BackColor = System.Drawing.Color.LightBlue;
            this.btnCreateTask.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCreateTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTask.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTask.Location = new System.Drawing.Point(200, 283);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(173, 45);
            this.btnCreateTask.TabIndex = 0;
            this.btnCreateTask.Text = "Create Task";
            this.btnCreateTask.UseVisualStyleBackColor = false;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Azure;
            this.groupBox1.Controls.Add(this.dtDate);
            this.groupBox1.Controls.Add(this.cbxCategory);
            this.groupBox1.Controls.Add(this.lblDueDate);
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.lblAssignmentName);
            this.groupBox1.Controls.Add(this.tbxName);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 237);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter your Task information here!";
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(177, 182);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(354, 29);
            this.dtDate.TabIndex = 5;
            // 
            // cbxCategory
            // 
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Items.AddRange(new object[] {
            "Research Paper",
            "Agile Software Project"});
            this.cbxCategory.Location = new System.Drawing.Point(177, 124);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(354, 30);
            this.cbxCategory.TabIndex = 4;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(46, 187);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(90, 22);
            this.lblDueDate.TabIndex = 3;
            this.lblDueDate.Text = "Due Date";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(49, 127);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(87, 22);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Category";
            // 
            // lblAssignmentName
            // 
            this.lblAssignmentName.AutoSize = true;
            this.lblAssignmentName.Location = new System.Drawing.Point(6, 73);
            this.lblAssignmentName.Name = "lblAssignmentName";
            this.lblAssignmentName.Size = new System.Drawing.Size(165, 22);
            this.lblAssignmentName.TabIndex = 1;
            this.lblAssignmentName.Text = "Assignment Name";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(177, 70);
            this.tbxName.MaxLength = 50;
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(354, 29);
            this.tbxName.TabIndex = 0;
            this.tbxName.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            // 
            // TaskCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(604, 343);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCreateTask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TaskCreate";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Create A Task";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateTask;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblAssignmentName;
        private System.Windows.Forms.TextBox tbxName;
    }
}