using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLQuanTraSua.Utility;
using MetroFramework.Forms;

namespace QLQuanTraSua
{
    public partial class frmLogin : MetroForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Employee nv = Employees.TimNhanVien(txtUsername.Text);
            if (nv != null && nv.Password.Equals(uNguyenQuy.ToMD5(txtPassword.Text)))
            {
                switch (nv.RoleID)
                {
                    case 1: Hide(); frmQuanLy frmQL = new QLQuanTraSua.frmQuanLy(); frmQL.Tag = nv.EmployeeID; frmQL.ShowDialog(); Show(); break;
                    case 2: Hide(); frmNhanVien frmNV = new QLQuanTraSua.frmNhanVien(); frmNV.Tag = nv.EmployeeID; frmNV.ShowDialog(); Show(); break;
                    default: (new frmLogin()).ShowDialog(); break;
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập, hoặc mật khẩu");
            }
        }

        private void llblResetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmResetPassword frmResetPassword = new frmResetPassword();
            frmResetPassword.ShowDialog();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            frmCacTruongHopDuLieu frm1 = new frmCacTruongHopDuLieu();
            frm1.ShowDialog();
            Show();
        }
    }
}
