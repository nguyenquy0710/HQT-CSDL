using MetroFramework.Forms;
using QLQuanTraSua.Utility;
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
    public partial class frmCacTruongHopDuLieu : MetroForm
    {
        public frmCacTruongHopDuLieu()
        {
            InitializeComponent();
        }

        private void frmCacTruongHopDuLieu_Load(object sender, EventArgs e)
        {
            LoadDefault();
        }

        void LoadDefault()
        {
            uNguyenQuy.LoadToCombobox(Orders.GetList, cbbDROrder);
            uNguyenQuy.LoadToCombobox(Orders.GetList, cbbDROrderView);
        }

        private void cbbDROrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            int orderID;
            if (int.TryParse(cbbDROrder.SelectedValue.ToString(), out orderID))
            {
                List<Order_Detail> lstOD = new List<Order_Detail>();
                lstOD = Order_Details.SearchOrderDetailByOrderID(orderID);
                if(lstOD != null)
                {
                    uNguyenQuy.LoadToCombobox(lstOD, cbbDRProductOfOrderDetail);
                }
            }
        }

        private void cbbDRProductOfOrderDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productID,orderID;
            if (int.TryParse(cbbDRProductOfOrderDetail.SelectedValue.ToString(), out productID) && int.TryParse(cbbDROrder.SelectedValue.ToString(), out orderID))
            {
                Order_Detail od = new Order_Detail();
                od = Order_Details.SearchByOrderAndProduct(orderID, productID);
                if (od!=null)
                {
                    txtQty.Text = od.Quantity.ToString();
                }
            }
        }

        private void btnDRUpdate_Click(object sender, EventArgs e)
        {
            int productID, orderID;
            if (int.TryParse(cbbDRProductOfOrderDetail.SelectedValue.ToString(), out productID) && int.TryParse(cbbDROrder.SelectedValue.ToString(), out orderID))
            {
                Order_Detail od = new Order_Detail();
                od = Order_Details.SearchByOrderAndProduct(orderID, productID);
                if (od != null)
                {
                    try
                    {
                        od.Quantity = int.Parse(txtQty.Text);
                    }catch(Exception ex)
                    {
                        uNguyenQuy.ShowNotifice("Số lượng phải là số tự nhiên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtQty.Text = od.Quantity.ToString();
                        txtQty.Focus();
                    }
                    if (Order_Details.UpdateByOrderProduct(orderID, productID, od.Quantity))
                        uNguyenQuy.ShowNotifice("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cbbDROrderView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int orderID;
            if (int.TryParse(cbbDROrderView.SelectedValue.ToString(), out orderID))
            {
                List<U_SearchBillListResult> lstOD = new List<U_SearchBillListResult>();
                lstOD = Order_Details.SearchOrderDetailByOrderIDErr(orderID);
                if (lstOD != null)
                {
                    dgvDRDetail.AutoGenerateColumns = false;
                    dgvDRDetail.Columns.Clear();
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
                    dgvDRDetail.Columns.Add(txtTenSP);
                    dgvDRDetail.Columns.Add(txtGia);
                    dgvDRDetail.Columns.Add(txtSL);
                    dgvDRDetail.DataSource = lstOD;
                }
            }
        }
    }
}
