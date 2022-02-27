namespace QLQuanTraSua
{
    partial class frmNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhanVien));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lstvOrderDetail = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongien = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbbBanLucDau = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.NumericUpDown();
            this.btnThemGio = new System.Windows.Forms.Button();
            this.cbbProduct = new System.Windows.Forms.ComboBox();
            this.cbbCategory = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(484, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 437);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lstvOrderDetail);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 86);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(395, 291);
            this.panel5.TabIndex = 2;
            // 
            // lstvOrderDetail
            // 
            this.lstvOrderDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lstvOrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvOrderDetail.Location = new System.Drawing.Point(0, 0);
            this.lstvOrderDetail.Name = "lstvOrderDetail";
            this.lstvOrderDetail.Size = new System.Drawing.Size(395, 291);
            this.lstvOrderDetail.TabIndex = 0;
            this.lstvOrderDetail.UseCompatibleStateImageBehavior = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lblTongTien);
            this.panel4.Controls.Add(this.txtTongien);
            this.panel4.Controls.Add(this.btnThanhToan);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 377);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(395, 60);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "VNĐ";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(21, 22);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(88, 22);
            this.lblTongTien.TabIndex = 4;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // txtTongien
            // 
            this.txtTongien.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongien.Location = new System.Drawing.Point(115, 19);
            this.txtTongien.Name = "txtTongien";
            this.txtTongien.ReadOnly = true;
            this.txtTongien.Size = new System.Drawing.Size(83, 29);
            this.txtTongien.TabIndex = 3;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Location = new System.Drawing.Point(291, 5);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(100, 49);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbbBanLucDau);
            this.panel3.Controls.Add(this.txtQty);
            this.panel3.Controls.Add(this.btnThemGio);
            this.panel3.Controls.Add(this.cbbProduct);
            this.panel3.Controls.Add(this.cbbCategory);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 86);
            this.panel3.TabIndex = 0;
            // 
            // cbbBanLucDau
            // 
            this.cbbBanLucDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbBanLucDau.FormattingEnabled = true;
            this.cbbBanLucDau.Location = new System.Drawing.Point(224, 10);
            this.cbbBanLucDau.Name = "cbbBanLucDau";
            this.cbbBanLucDau.Size = new System.Drawing.Size(91, 28);
            this.cbbBanLucDau.TabIndex = 4;
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(224, 49);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(90, 29);
            this.txtQty.TabIndex = 3;
            this.txtQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThemGio
            // 
            this.btnThemGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemGio.Location = new System.Drawing.Point(321, 15);
            this.btnThemGio.Name = "btnThemGio";
            this.btnThemGio.Size = new System.Drawing.Size(70, 55);
            this.btnThemGio.TabIndex = 2;
            this.btnThemGio.Text = "Mua";
            this.btnThemGio.UseVisualStyleBackColor = true;
            this.btnThemGio.Click += new System.EventHandler(this.btnThemGio_Click);
            // 
            // cbbProduct
            // 
            this.cbbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProduct.FormattingEnabled = true;
            this.cbbProduct.Location = new System.Drawing.Point(7, 48);
            this.cbbProduct.Name = "cbbProduct";
            this.cbbProduct.Size = new System.Drawing.Size(211, 32);
            this.cbbProduct.TabIndex = 1;
            // 
            // cbbCategory
            // 
            this.cbbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCategory.FormattingEnabled = true;
            this.cbbCategory.Location = new System.Drawing.Point(6, 7);
            this.cbbCategory.Name = "cbbCategory";
            this.cbbCategory.Size = new System.Drawing.Size(212, 32);
            this.cbbCategory.TabIndex = 0;
            this.cbbCategory.SelectedIndexChanged += new System.EventHandler(this.cbbCategory_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flpTable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 437);
            this.panel2.TabIndex = 1;
            // 
            // flpTable
            // 
            this.flpTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.flpTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTable.Location = new System.Drawing.Point(0, 0);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(464, 437);
            this.flpTable.TabIndex = 0;
            // 
            // frmNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 517);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhanVien";
            this.Text = "Quán trà sữa NEWDAY";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtQty)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView lstvOrderDetail;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnThemGio;
        private System.Windows.Forms.ComboBox cbbProduct;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.NumericUpDown txtQty;
        private System.Windows.Forms.ComboBox cbbCategory;
        private System.Windows.Forms.ComboBox cbbBanLucDau;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongien;
        private System.Windows.Forms.Label label1;
    }
}