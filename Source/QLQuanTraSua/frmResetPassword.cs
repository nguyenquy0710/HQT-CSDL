using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLQuanTraSua.Utility;
using MetroFramework.Forms;

namespace QLQuanTraSua
{
    public partial class frmResetPassword : MetroForm
    {
        public frmResetPassword()
        {
            InitializeComponent();
        }

        private void frmResetPassword_Load(object sender, EventArgs e)
        {
            
        }

        private void Validate(object sender, EventArgs e)
        {
            String temp = lblNotify.Text;
            if(Employees.TimNhanVien(txtUsername.Text) == null)
            {
                lblNotify.Text = temp + " không phải là Username hoặc chưa được tạo tài khoản";
            }
            else
            {
                if (uNguyenQuy.ShowNotifice("Bạn muốn khôi phục mật khẩu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //xac nhan email thanh cong
                    txtPasNew.ReadOnly = false;
                    txtPassConnform.ReadOnly = false;
                }
                else
                {
                    //xac nhan email ko thanh cong
                    txtPasNew.Text = "10";
                    txtPassConnform.Text = "10";
                }
                lblNotify.Text = String.Empty;
            }
        }
        private void ValidatePassword(object sender, EventArgs e)
        {
            String temp = lblNotify.Text;
            if(!txtPassConnform.Text.Equals(txtPasNew.Text))
            {
                lblNotify.Text = temp + "\nMật khẩu nhập không hớp.";
            }
            else
            {
                lblNotify.Text = temp;
            }
        }
        private void btnRsetPass_Click(object sender, EventArgs e)
        {
            if (Employees.CapNhatMatKhau(txtUsername.Text, txtPasNew.Text))
            {
                MessageBox.Show("Reset mật khẩu thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Username bạn nhập vào không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
