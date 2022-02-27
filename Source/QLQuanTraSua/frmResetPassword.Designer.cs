namespace QLQuanTraSua
{
    partial class frmResetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResetPassword));
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassNew = new System.Windows.Forms.Label();
            this.lblPassComform = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPasNew = new System.Windows.Forms.TextBox();
            this.txtPassConnform = new System.Windows.Forms.TextBox();
            this.btnRsetPass = new System.Windows.Forms.Button();
            this.lblNotify = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(12, 60);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(114, 25);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassNew
            // 
            this.lblPassNew.AutoSize = true;
            this.lblPassNew.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassNew.Location = new System.Drawing.Point(12, 104);
            this.lblPassNew.Name = "lblPassNew";
            this.lblPassNew.Size = new System.Drawing.Size(152, 25);
            this.lblPassNew.TabIndex = 3;
            this.lblPassNew.Text = "Mật khẩu mới:";
            // 
            // lblPassComform
            // 
            this.lblPassComform.AutoSize = true;
            this.lblPassComform.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassComform.Location = new System.Drawing.Point(12, 147);
            this.lblPassComform.Name = "lblPassComform";
            this.lblPassComform.Size = new System.Drawing.Size(194, 25);
            this.lblPassComform.TabIndex = 4;
            this.lblPassComform.Text = "Nhập lại mật khẩu:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(203, 57);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(216, 32);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.Leave += new System.EventHandler(this.Validate);
            // 
            // txtPasNew
            // 
            this.txtPasNew.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasNew.Location = new System.Drawing.Point(203, 101);
            this.txtPasNew.Name = "txtPasNew";
            this.txtPasNew.ReadOnly = true;
            this.txtPasNew.Size = new System.Drawing.Size(216, 32);
            this.txtPasNew.TabIndex = 7;
            this.txtPasNew.UseSystemPasswordChar = true;
            // 
            // txtPassConnform
            // 
            this.txtPassConnform.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassConnform.Location = new System.Drawing.Point(203, 140);
            this.txtPassConnform.Name = "txtPassConnform";
            this.txtPassConnform.ReadOnly = true;
            this.txtPassConnform.Size = new System.Drawing.Size(216, 32);
            this.txtPassConnform.TabIndex = 8;
            this.txtPassConnform.UseSystemPasswordChar = true;
            this.txtPassConnform.Leave += new System.EventHandler(this.ValidatePassword);
            // 
            // btnRsetPass
            // 
            this.btnRsetPass.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRsetPass.Location = new System.Drawing.Point(171, 192);
            this.btnRsetPass.Name = "btnRsetPass";
            this.btnRsetPass.Size = new System.Drawing.Size(116, 39);
            this.btnRsetPass.TabIndex = 9;
            this.btnRsetPass.Text = "Đồng ý";
            this.btnRsetPass.UseVisualStyleBackColor = true;
            this.btnRsetPass.Click += new System.EventHandler(this.btnRsetPass_Click);
            // 
            // lblNotify
            // 
            this.lblNotify.AutoSize = true;
            this.lblNotify.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotify.ForeColor = System.Drawing.Color.Red;
            this.lblNotify.Location = new System.Drawing.Point(62, 192);
            this.lblNotify.Name = "lblNotify";
            this.lblNotify.Size = new System.Drawing.Size(0, 15);
            this.lblNotify.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(122, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Khôi phục mật khẩu";
            // 
            // frmResetPassword
            // 
            this.AcceptButton = this.btnRsetPass;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 240);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNotify);
            this.Controls.Add(this.btnRsetPass);
            this.Controls.Add(this.txtPassConnform);
            this.Controls.Add(this.txtPasNew);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassComform);
            this.Controls.Add(this.lblPassNew);
            this.Controls.Add(this.lblUsername);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResetPassword";
            this.Padding = new System.Windows.Forms.Padding(23, 60, 23, 21);
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.frmResetPassword_Load);
            this.Leave += new System.EventHandler(this.Validate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassNew;
        private System.Windows.Forms.Label lblPassComform;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPasNew;
        private System.Windows.Forms.TextBox txtPassConnform;
        private System.Windows.Forms.Button btnRsetPass;
        private System.Windows.Forms.Label lblNotify;
        private System.Windows.Forms.Label label1;
    }
}