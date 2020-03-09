namespace inventory_project
{
    partial class Form1
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
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_exit = new System.Windows.Forms.Button();
			this.btn_login = new System.Windows.Forms.Button();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(33, 126);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 24);
			this.label2.TabIndex = 5;
			this.label2.Text = "Password:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(33, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(102, 24);
			this.label1.TabIndex = 4;
			this.label1.Text = "Username:";
			// 
			// btn_exit
			// 
			this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_exit.Location = new System.Drawing.Point(37, 206);
			this.btn_exit.Name = "btn_exit";
			this.btn_exit.Size = new System.Drawing.Size(131, 42);
			this.btn_exit.TabIndex = 3;
			this.btn_exit.Text = "Exit";
			this.btn_exit.UseVisualStyleBackColor = true;
			this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
			// 
			// btn_login
			// 
			this.btn_login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_login.Location = new System.Drawing.Point(183, 206);
			this.btn_login.Name = "btn_login";
			this.btn_login.Size = new System.Drawing.Size(135, 42);
			this.btn_login.TabIndex = 2;
			this.btn_login.Text = "Log In";
			this.btn_login.UseVisualStyleBackColor = true;
			this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
			// 
			// txtPassword
			// 
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(37, 153);
			this.txtPassword.MaxLength = 20;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(281, 38);
			this.txtPassword.TabIndex = 1;
			// 
			// txtUsername
			// 
			this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsername.Location = new System.Drawing.Point(37, 80);
			this.txtUsername.MaxLength = 20;
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(281, 38);
			this.txtUsername.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(376, 364);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_login);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.btn_exit);
			this.Controls.Add(this.txtUsername);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
    }
}

