﻿namespace FlowTask_WinForms_Frontent
{
    partial class RegistrationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRegister = new System.Windows.Forms.Panel();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.tbxConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnEscape = new System.Windows.Forms.Button();
            this.pnlRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "FlowTask Registration";
            // 
            // pnlRegister
            // 
            this.pnlRegister.BackColor = System.Drawing.SystemColors.Window;
            this.pnlRegister.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRegister.Controls.Add(this.tbxEmail);
            this.pnlRegister.Controls.Add(this.lblEmail);
            this.pnlRegister.Controls.Add(this.tbxConfirmPassword);
            this.pnlRegister.Controls.Add(this.lblConfirmPassword);
            this.pnlRegister.Controls.Add(this.tbxLastName);
            this.pnlRegister.Controls.Add(this.tbxFirstName);
            this.pnlRegister.Controls.Add(this.lblLastName);
            this.pnlRegister.Controls.Add(this.lblFirstName);
            this.pnlRegister.Controls.Add(this.tbxPassword);
            this.pnlRegister.Controls.Add(this.lblPassword);
            this.pnlRegister.Controls.Add(this.tbxUsername);
            this.pnlRegister.Controls.Add(this.lblUsername);
            this.pnlRegister.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRegister.Location = new System.Drawing.Point(36, 82);
            this.pnlRegister.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlRegister.Name = "pnlRegister";
            this.pnlRegister.Size = new System.Drawing.Size(454, 319);
            this.pnlRegister.TabIndex = 2;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxEmail.Location = new System.Drawing.Point(152, 165);
            this.tbxEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxEmail.MaxLength = 30;
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(235, 22);
            this.tbxEmail.TabIndex = 15;
            this.tbxEmail.TextChanged += new System.EventHandler(this.tbxTextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(85, 171);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(41, 16);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Email";
            // 
            // tbxConfirmPassword
            // 
            this.tbxConfirmPassword.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxConfirmPassword.Location = new System.Drawing.Point(152, 266);
            this.tbxConfirmPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxConfirmPassword.MaxLength = 30;
            this.tbxConfirmPassword.Name = "tbxConfirmPassword";
            this.tbxConfirmPassword.Size = new System.Drawing.Size(235, 22);
            this.tbxConfirmPassword.TabIndex = 13;
            this.tbxConfirmPassword.UseSystemPasswordChar = true;
            this.tbxConfirmPassword.TextChanged += new System.EventHandler(this.tbxConfirmPassword_TextChanged);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(13, 272);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(113, 16);
            this.lblConfirmPassword.TabIndex = 12;
            this.lblConfirmPassword.Text = "Confirm Password";
            // 
            // tbxLastName
            // 
            this.tbxLastName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLastName.Location = new System.Drawing.Point(152, 124);
            this.tbxLastName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxLastName.MaxLength = 30;
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(235, 22);
            this.tbxLastName.TabIndex = 11;
            this.tbxLastName.TextChanged += new System.EventHandler(this.tbxTextChanged);
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxFirstName.Location = new System.Drawing.Point(152, 77);
            this.tbxFirstName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxFirstName.MaxLength = 30;
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(235, 22);
            this.tbxFirstName.TabIndex = 10;
            this.tbxFirstName.TextChanged += new System.EventHandler(this.tbxTextChanged);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(55, 127);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(71, 16);
            this.lblLastName.TabIndex = 9;
            this.lblLastName.Text = "Last Name";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(54, 83);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(72, 16);
            this.lblFirstName.TabIndex = 8;
            this.lblFirstName.Text = "First Name";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.Location = new System.Drawing.Point(152, 220);
            this.tbxPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxPassword.MaxLength = 30;
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(235, 22);
            this.tbxPassword.TabIndex = 6;
            this.tbxPassword.UseSystemPasswordChar = true;
            this.tbxPassword.TextChanged += new System.EventHandler(this.tbxConfirmPassword_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(61, 220);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 16);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // tbxUsername
            // 
            this.tbxUsername.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUsername.Location = new System.Drawing.Point(152, 30);
            this.tbxUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbxUsername.MaxLength = 30;
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(235, 22);
            this.tbxUsername.TabIndex = 4;
            this.tbxUsername.TextChanged += new System.EventHandler(this.tbxTextChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(59, 33);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(67, 16);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(53, 434);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(140, 31);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create Account";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreateClicked);
            // 
            // btnEscape
            // 
            this.btnEscape.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEscape.Location = new System.Drawing.Point(350, 434);
            this.btnEscape.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEscape.Name = "btnEscape";
            this.btnEscape.Size = new System.Drawing.Size(140, 31);
            this.btnEscape.TabIndex = 4;
            this.btnEscape.Text = "Go Back";
            this.btnEscape.UseVisualStyleBackColor = true;
            this.btnEscape.Click += new System.EventHandler(this.btnEscape_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 478);
            this.Controls.Add(this.btnEscape);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlRegister);
            this.Controls.Add(this.btnCreate);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.pnlRegister.ResumeLayout(false);
            this.pnlRegister.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlRegister;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox tbxConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Button btnEscape;
    }
}