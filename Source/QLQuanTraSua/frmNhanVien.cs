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
    public partial class frmNhanVien : MetroForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadTable2FLP(flpTable, Tables.GetListTable);
            LoadComboboxCategory(cbbCategory);
            Tables.LoadConboBoxTable(cbbBanLucDau, true);
            LoadComboboxProduct(cbbProduct);
        }
        public void LoadComboboxCategory(ComboBox cbb)
        {
            using (DBDataContext db = new DBDataContext())
            {
                List<Category> lstDSDM = new List<Category>();

                lstDSDM.Add(new Category() { CategoryName = "--Danh mục--", CategoryID = 0 });
                foreach (Category dm in db.Categories.ToList())
                {
                    lstDSDM.Add(dm);

                }
                cbb.DataSource = lstDSDM;
                cbb.DisplayMember = "CategoryName";
                cbb.ValueMember = "CategoryID";
            }
        }
        public void LoadComboboxProduct(ComboBox cbb)
        {
            using (DBDataContext db = new DBDataContext())
            {
                List<Product> lstPro = new List<Product>();

                lstPro.Add(new Product() { ProductName = "-- Sản phẩm --", ProductID = 0 });
                foreach (Product pr in db.Products.ToList())
                {
                    lstPro.Add(pr);

                }
                cbb.DataSource = lstPro;
                cbb.DisplayMember = "ProductName";
                cbb.ValueMember = "ProductID";
            }
        }
        public void LoadTable2FLP(FlowLayoutPanel flp, List<Table> lstTb)
        {
            Image myimage = null;
            flp.Controls.Clear();
            try
            {
                myimage = new Bitmap(@"C:\Users\vanta\OneDrive\TOPIC\HQT-CSDL\Source\QLQuanTraSua\db_Image\1.jpg");
            }
            catch (Exception e)
            {
                myimage = new Bitmap(@"E:\OneDriver\OneDrive\TOPIC\HQT-CSDL\Source\QLQuanTraSua\db_Image\1.jpg");
            }
            //flp.BackgroundImage = myimage;
            foreach (Table lst in lstTb)
            {
                Button btn = new Button();
                btn.Text = lst.TableName + Environment.NewLine + (lst.Status == 1 ? "Có khách" : "Trống");
                switch (lst.Status)
                {
                    case 1: btn.BackColor = Color.Aqua; break;
                    default: btn.BackColor = Color.LightPink; break;
                }
                btn.Width = 100;
                btn.Height = 80;
                btn.Tag = lst.TableID;
                btn.Click += new EventHandler(btn_Click);
                flp.Controls.Add(btn);
            }

        }

        public void btn_Click(object sender, EventArgs e)
        {
            int idTable = int.Parse(((Button)sender).Tag.ToString());
            lstvOrderDetail.Tag = idTable.ToString();
            foreach (Table tb in Tables.GetListTable)
            {
                if (tb.TableID == idTable)
                {
                    cbbBanLucDau.SelectedIndex = Tables.ConvertIdToSTT(idTable);
                    if (tb.Status == 1)
                    {
                        ShowBill(idTable);
                    }
                    else
                    {
                        lstvOrderDetail.Items.Clear();
                        txtTongien.Text = String.Empty;
                    }
                }
            }
        }

        public void ShowBill(int idTable)
        {
            lstvOrderDetail.Tag = idTable.ToString();
            List<Order> lstOr = Orders.SearchOrderByTableId(idTable);
            if (lstOr != null)
            {
                foreach (Order o in lstOr)
                {
                    if (o.Status == 1)
                    {
                        List<v_OrderDetail_Product> lstVOP = Order_Details.GetOrderDetail(o.OrderID);
                        if (lstVOP == null)
                        {
                            txtTongien.Text = String.Empty;
                            lstvOrderDetail.Items.Clear();
                            return;
                        }
                        if (lstVOP.Count() != 0)
                        {
                            uNguyenQuy.LoadOrderDetail2ListView(lstVOP, lstvOrderDetail);
                            float tongtien = uNguyenQuy.TongTien(lstVOP);
                            txtTongien.Text = tongtien.ToString();
                            return;
                        }

                    }

                }
            }
            else
            {
                lstvOrderDetail.Items.Clear();
                txtTongien.Text = String.Empty;
            }
        }

        

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            try { id = int.Parse(cbbCategory.SelectedValue.ToString()); }
            catch (Exception ex) { id = 0; }
            if (id != 0)
            {
                List<Product> lstPro = new List<Product>();
                foreach (Product p in Products.GetListProduct)
                {
                    if (p.CategoryID == id)
                        lstPro.Add(p);
                }
                if (lstPro.Count() != 0)
                {
                    cbbProduct.DataSource = lstPro;
                    cbbProduct.DisplayMember = "ProductName";
                    cbbProduct.ValueMember = "ProductID";
                }
            }
            else
                LoadComboboxProduct(cbbProduct);
        }

        private void btnThemGio_Click(object sender, EventArgs e)
        {
            //co chon san pham chua
            //if (int.Parse(cbbProduct.SelectedValue.ToString())==0)
            //{
            //    if (uNguyenQuy.ShowNotifice("Bạn phải chọn sản phẩm mua", /"Thông /báo", MessageBoxButtons.OK, MessageBoxIcon.Hand) == //DialogResult.OK)
            //    return;
            //}
            //lay thong tin ban
            int tableId = int.Parse(cbbBanLucDau.SelectedValue.ToString());

            List<Order> lstOr = Orders.SearchOrderByTableId(tableId);
            if (lstOr != null)
            {
                foreach (Order o in lstOr)
                {
                    if (o.Status == 1)
                    {
                        //bang dang co ng nguoi \n them san pham ma ho mua
                        ThemOrderDetal(tableId, o);
                        return;
                    }
                }
            }
            //them hoa don vao CSDL
            int empId = int.Parse(this.Tag.ToString());
            Order addOr = new Order();
            addOr.EmployeeID = empId;
            addOr.TableID = tableId;
            addOr.DateCheckIn = DateTime.Today;
            addOr.Status = 1;
            if (Orders.Insert(addOr))
            {
                List<Order> lst = Orders.SearchOrderByTableId(tableId);
                foreach (Order o in lst)
                {
                    if (o.EmployeeID == empId && o.Status == 1)
                    {
                        ThemOrderDetal(tableId, o);
                    }
                }
            }
            else
                uNguyenQuy.ShowNotifice("Mua hàng không thành công\n Phải chọn sản phẩm và số lượng phải khác 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ThemOrderDetal(int tableId, Order o)
        {
            //mua san pham
            Order_Detail od = new Order_Detail();
            od.OrderID = o.OrderID;
            od.ProductID = int.Parse(cbbProduct.SelectedValue.ToString());
            od.Quantity = int.Parse(txtQty.Value.ToString());
            Order_Detail odt = Order_Details.SearchByOrderAndProduct(o.OrderID, od.ProductID);
            //cung loai san pham cho cung hoa don thi cap nhat so luong
            if (odt != null) { Order_Details.UpdateByOrderProduct(odt.OrderID, odt.ProductID, od.Quantity); ShowBill(tableId); return; }
            if (Order_Details.Insert(od))
            {
                if (!Tables.UpdateStatus(tableId, 1))
                {
                    uNguyenQuy.ShowNotifice("Bàn này không có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //xoa order va order detail
                    Order_Details.DeleteById(o.OrderID);
                    Orders.DeleteById(o.OrderID);
                    return;
                }
                LoadTable2FLP(flpTable, Tables.GetListTable);
                ShowBill(tableId);
                return;
            }
            
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int empId = int.Parse(this.Tag.ToString());
            int tableId = int.Parse(lstvOrderDetail.Tag.ToString());
            List<Order> lstO = Orders.SearchOrderByTableId(tableId, empId);
            if (lstO != null)
            {
                foreach (Order o in lstO)
                {
                    if (o.Status == 1)
                    {
                        Tables.UpdateStatus(tableId, 0);
                        List<v_OrderDetail_Product> lstVOP = Order_Details.GetOrderDetail(o.OrderID);
                        ShowPay(o, lstVOP);
                        return;
                    }
                }
                uNguyenQuy.ShowNotifice("Bàn này hiện đang trông", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                uNguyenQuy.ShowNotifice("Bàn này hiện đang trông", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        public void ShowPay(Order o, List<v_OrderDetail_Product> lstVOP)
        {
            Orders.UpdateStatus(o.OrderID, 0);
            frmThanhToan frm = new frmThanhToan();
            frm.o = o;
            frm.lstVOP = lstVOP;
            frm.Show();
            LoadTable2FLP(flpTable, Tables.GetListTable);
            Show();
        }
    }
}
