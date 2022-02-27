using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanTraSua
{
    public partial class frmThanhToan : MetroForm
    {
        public Order o;
        public List<v_OrderDetail_Product> lstVOP;

        public frmThanhToan()
        {
            InitializeComponent();
        }

        private void LoadPayment()
        {
            if (lstVOP == null) { this.Close(); return; }
            LoadOrderDetail2ListView(lstVOP, lstvOrder);
        }

        public void LoadOrderDetail2ListView(List<v_OrderDetail_Product> lstPro, ListView lstv)
        {
            try
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
                float tongtien = 0;
                foreach (v_OrderDetail_Product sp in lstPro)
                {
                    lstv.Items.Add(sp.ProductName);
                    lstv.Items[i].SubItems.Add(sp.Quantity.ToString());
                    lstv.Items[i].SubItems.Add(sp.Price.ToString());
                    lstv.Items[i].SubItems.Add((sp.Quantity * sp.Price).ToString());
                    tongtien += (float)(sp.Quantity * sp.Price);
                    i++;
                }
                lblTongTien.Text = tongtien + " VND";
            }
            catch (Exception e) { }
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            LoadPayment();
        }
    }
}
