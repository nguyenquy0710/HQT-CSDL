using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanTraSua.Utility
{
    public static class uNguyenQuy
    {
        //ham ma hoa MD5
        public static string ToMD5(this string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sbHash = new StringBuilder();
            foreach (byte b in bHash)
                sbHash.Append(String.Format("{0:x2}", b));
            return sbHash.ToString();
        }

        public static bool TextBoxHopLe(TextBox txt, out string kq)
        {
            kq = string.Empty;
            if (!string.IsNullOrEmpty(txt.Text) && !string.IsNullOrWhiteSpace(txt.Text))
            {
                kq = txt.Text.Trim();
                return true;
            }
            return false;
        }
        //kiem ra hinh hop le
        public static bool CheckImage(OpenFileDialog ofd)
        {
            if (ofd.CheckFileExists)
            {
                string[] ds = { "jpg", "png", "gif", "bmp" };
                string extension = ofd.FileName.Substring(ofd.FileName.LastIndexOf('.') + 1).ToLower();
                return ds.Contains(extension);
            }
            else
            {
                return false;
            }
        }
        //load danh sach nhan vien to gridview
        public static void LoadDSNV2DataGridView(DataGridView dgv, List<v_Employee_Role> lstData)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            DataGridViewLinkColumn lbtnUsername = new DataGridViewLinkColumn();
            lbtnUsername.Name = "lbtnUsername";
            lbtnUsername.HeaderText = "Tên Đăng Nhập";
            lbtnUsername.DataPropertyName = "Email";
            lbtnUsername.Width = 180;
            DataGridViewTextBoxColumn txtHoTenNV = new DataGridViewTextBoxColumn();
            txtHoTenNV.Name = "txtHoTenNV";
            txtHoTenNV.HeaderText = "Họ và Tên";
            txtHoTenNV.DataPropertyName = "EmployeeName";
            txtHoTenNV.Width = 180;
            DataGridViewTextBoxColumn txtbPhoneNV = new DataGridViewTextBoxColumn();
            txtbPhoneNV.Name = "txtbPhoneNV";
            txtbPhoneNV.HeaderText = "Số điện thoại";
            txtbPhoneNV.DataPropertyName = "Mobile";
            txtbPhoneNV.Width = 100;
            //DataGridViewTextBoxColumn txtbRoleNV = new DataGridViewTextBoxColumn();
            //txtbRoleNV.Name = "txtbRoleNV";
            //txtbRoleNV.HeaderText = "Chức vụ";
            //txtbRoleNV.DataPropertyName = "RoleName";
            //txtbRoleNV.Width = 80;

            dgv.Columns.Add(lbtnUsername);
            dgv.Columns.Add(txtHoTenNV);
            dgv.Columns.Add(txtbPhoneNV);
            //dgv.Columns.Add(txtbRoleNV);
            dgv.DataSource = lstData;
        }
        public static void LoadDSNV2DataGridView(DataGridView dgv, List<Employee> lstData)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            DataGridViewLinkColumn lbtnUsername = new DataGridViewLinkColumn();
            lbtnUsername.Name = "lbtnUsername";
            lbtnUsername.HeaderText = "Tên Đăng Nhập";
            lbtnUsername.DataPropertyName = "Email";
            lbtnUsername.Width = 180;
            DataGridViewTextBoxColumn txtHoTenNV = new DataGridViewTextBoxColumn();
            txtHoTenNV.Name = "txtHoTenNV";
            txtHoTenNV.HeaderText = "Họ và Tên";
            txtHoTenNV.DataPropertyName = "EmployeeName";
            txtHoTenNV.Width = 180;
            DataGridViewTextBoxColumn txtbPhoneNV = new DataGridViewTextBoxColumn();
            txtbPhoneNV.Name = "txtbPhoneNV";
            txtbPhoneNV.HeaderText = "Số điện thoại";
            txtbPhoneNV.DataPropertyName = "Mobile";
            txtbPhoneNV.Width = 100;
            //DataGridViewTextBoxColumn txtbRoleNV = new DataGridViewTextBoxColumn();
            //txtbRoleNV.Name = "txtbRoleNV";
            //txtbRoleNV.HeaderText = "Chức vụ";
            //txtbRoleNV.DataPropertyName = "RoleName";
            //txtbRoleNV.Width = 80;

            dgv.Columns.Add(lbtnUsername);
            dgv.Columns.Add(txtHoTenNV);
            dgv.Columns.Add(txtbPhoneNV);
            //dgv.Columns.Add(txtbRoleNV);
            dgv.DataSource = lstData;
        }
        public static void LoadDSHD2DataGridView(DataGridView dgv, List<v_OrderDetail_Product> lstData)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            DataGridViewTextBoxColumn txtTenSP = new DataGridViewTextBoxColumn();
            txtTenSP.Name = "txtTenSP";
            txtTenSP.HeaderText = "Tên Sản Phẩm";
            txtTenSP.DataPropertyName = "ProductName";
            txtTenSP.Width = 180;
            DataGridViewTextBoxColumn txtGia = new DataGridViewTextBoxColumn();
            txtGia.Name = "txtGia";
            txtGia.HeaderText = "Giá";
            txtGia.DataPropertyName = "Price";
            txtGia.Width = 100;
            DataGridViewTextBoxColumn txtSL = new DataGridViewTextBoxColumn();
            txtSL.Name = "txtSL";
            txtSL.HeaderText = "Số Lượng";
            txtSL.DataPropertyName = "Quantity";
            txtSL.Width = 180;
            dgv.Columns.Add(txtTenSP);
            dgv.Columns.Add(txtGia);
            dgv.Columns.Add(txtSL);
            dgv.DataSource = lstData;
        }
        public static DialogResult ShowNotifice(string message, string titleMessage, MessageBoxButtons button, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, titleMessage, button, icon);
        }

        public static void LoadProduct2ListView(List<Product> lstPro, ListView lstv)
        {
            lstv.Items.Clear();
            lstv.Refresh();
            lstv.View = View.Details;
            lstv.Columns.Add(new ColumnHeader() { Text = "Mã sản phẩm", Name = "chdMaSP", Width = 130, TextAlign = HorizontalAlignment.Center });
            lstv.Columns.Add(new ColumnHeader() { Text = "Tên sản phẩm", Name = "chdTenSP", Width = 340, TextAlign = HorizontalAlignment.Center });
            lstv.GridLines = true;
            lstv.FullRowSelect = true;
            int i = 0;
            foreach (Product sp in lstPro)
            {
                lstv.Items.Add(sp.ProductID.ToString());
                lstv.Items[i].SubItems.Add(sp.ProductName);
                i++;
            }
        }
        public static void LoadOrderDetail2ListView(List<v_OrderDetail_Product> lstPro, ListView lstv)
        {
            lstv.Items.Clear();
            lstv.Clear();
            lstv.Refresh();
            lstv.View = View.Details;
            lstv.Columns.Add(new ColumnHeader() { Text = "Tên sản phẩm", Name = "chdTenSP", Width = 150, TextAlign = HorizontalAlignment.Left });
            lstv.Columns.Add(new ColumnHeader() { Text = "Số lương", Name = "chdSoLuong", Width = 80, TextAlign = HorizontalAlignment.Center });
            lstv.Columns.Add(new ColumnHeader() { Text = "Đơn giá", Name = "chdDonGia", Width = 80, TextAlign = HorizontalAlignment.Center });
            lstv.Columns.Add(new ColumnHeader() { Text = "Thành tiền", Name = "chdThanhTien", Width = 80, TextAlign = HorizontalAlignment.Center });
            lstv.GridLines = true;
            lstv.FullRowSelect = true;
            int i = 0;
            foreach (v_OrderDetail_Product sp in lstPro)
            {
                lstv.Items.Add(sp.ProductName);
                lstv.Items[i].SubItems.Add(sp.Quantity.ToString());
                lstv.Items[i].SubItems.Add(sp.Price.ToString());
                lstv.Items[i].SubItems.Add((sp.Quantity * sp.Price).ToString());
                i++;
            }
        }
        //ting tong tin cho hoa don
        public static float TongTien(List<v_OrderDetail_Product> lstVOP)
        {
            float tongtien = 0;
            foreach (v_OrderDetail_Product v in lstVOP)
            {
                tongtien += (float)(v.Quantity * v.Price);
            }
            return tongtien;
        }
        //load to Combobox 
        public static void LoadToCombobox(List<Order> lst, ComboBox cbb)
        {
            cbb.DataSource = lst;
            cbb.DisplayMember = "OrderID";
            cbb.ValueMember = "OrderID";
        }
        public static void LoadToCombobox(List<Order_Detail> lst, ComboBox cbb)
        {
            cbb.DataSource = lst;
            cbb.DisplayMember = "ProductID";
            cbb.ValueMember = "ProductID";
        }
    }
}
