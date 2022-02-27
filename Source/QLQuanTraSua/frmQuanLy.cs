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
using System.IO;

namespace QLQuanTraSua
{
    public partial class frmQuanLy : MetroForm
    {
        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            loadbtnInsUpSP();
            uNguyenQuy.LoadDSNV2DataGridView(dgvDSNV, Employees.GetList);
            Orders.LoadDSHD2ListView(lstvDSHD);
            Roles.LoadRole2ComboBox(cbbRole, true);
            //LoadConboBoxSearchHD(cbbSearchHD);
            LoadConboBoxSearchSP(cbbSearchDMSP);
            LoadConboBoxSearchSP(cbbDanhMuc);
            Products.LoadDSSP2ListView(lstvSP);
            //---Tab Control QL Table---//
            LoadStatusTable(cbbTableStatus);
            LoadTableToListBox(lstbTable);
            Tables.LoadConboBoxTable(cbbTableMerge);
            //---Tab Control QL Category---//
            LoadCategoryToListBox(lstbCategory);
        }

        private void loadbtnInsUpSP()
        {
            int productId;
            try
            {
                productId = int.Parse(txtMaSP.Text);
            }
            catch (Exception e)
            {
                productId = 0;
            }
            if (Products.SearchByMaSP(productId) == null)
            {
                btnInsertSP.Visible = true;
                btnUpdateSP.Visible = false;
            }
            else
            {
                btnInsertSP.Visible = false;
                btnUpdateSP.Visible = true;
            }
        }

        private void tbcQuanLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadbtnInsUpSP();
            uNguyenQuy.LoadDSNV2DataGridView(dgvDSNV, Employees.GetList);
            Orders.LoadDSHD2ListView(lstvDSHD);
            Roles.LoadRole2ComboBox(cbbRole, true);
            //LoadConboBoxSearchHD(cbbSearchHD);
            LoadConboBoxSearchSP(cbbSearchDMSP);
            LoadConboBoxSearchSP(cbbDanhMuc);
            Products.LoadDSSP2ListView(lstvSP);
            //---Tab Control QL Table---//
            LoadStatusTable(cbbTableStatus);
            LoadTableToListBox(lstbTable);
            Tables.LoadConboBoxTable(cbbTableMerge);
            //---Tab Control QL Category---//
            LoadCategoryToListBox(lstbCategory);
        }

        private void LoadConboBoxSearchSP(ComboBox cbb)
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
        private void LoadConboBoxSearchHD(ComboBox cbb)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("all", "Tất cả");
            items.Add("nv", "Nhân Viên");
            cbb.DataSource = new BindingSource(items, null);
            cbb.DisplayMember = "Value";
            cbb.ValueMember = "Key";
        }
        private void LoadProcudctByCatIdToListView(int id, ListView lstv)
        {
            List<Product> lstPro = new List<Product>();
            foreach (Product p in Products.GetListProduct)
            {
                if (p.CategoryID == id)
                    lstPro.Add(p);
            }
            if (lstPro.Count != 0)
            {
                uNguyenQuy.LoadProduct2ListView(lstPro, lstv);
            }
        }
        private void frmQuanLy_ClientSizeChanged(object sender, EventArgs e)
        {
            //kich thuoc cua so ClientRectangle thay doi
        }
        private void llblUploadAvatarNV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //khai bao bien duong dan file
            string path;
            if (ofdChonAvatarNV.ShowDialog() == DialogResult.OK)//showdialog chon file
            {
                if (uNguyenQuy.CheckImage(ofdChonAvatarNV))
                {
                    //lay duong dan dua vao bien duong dan
                    path = ofdChonAvatarNV.FileName;
                    if (String.IsNullOrEmpty(path) || String.IsNullOrWhiteSpace(path))
                        return;
                    ////dat anh len khu vuc hien anh
                    //ptbAvatar.Image = Image.FromFile(path);
                    //ptbAvatar.Tag = Path.GetFileName(path);
                    //ptbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;//StretchImage tự động co ảnh lại cho vừa khung
                    //Oke
                }
            }
            else
            {
                MessageBox.Show("Hình ảnh không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            String temp;
            if (uNguyenQuy.TextBoxHopLe(txtSearchNV, out temp))
            {
                uNguyenQuy.LoadDSNV2DataGridView(dgvDSNV, Employees.TimNhanVienTheoTen(temp));
            }
            else
            {
                if (uNguyenQuy.ShowNotifice("Thông tin bạn tìm không tồn tại. \n Load toàn bộ nhân viên?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    uNguyenQuy.LoadDSNV2DataGridView(dgvDSNV, Employees.GetListEmployeeRole);
            }
        }
        //private void btnSearchHD_Click(object sender, EventArgs e)
        //{
        //    String txt;
        //    if (uNguyenQuy.TextBoxHopLe(txtSearchHD, out txt))
        //    {
        //        if (cbbSearchHD.SelectedValue.Equals("nv"))
        //        {
        //            //uOrder.SearchOrderByNhanVien(txt, lstvDSHD);
        //        }
        //        if (cbbSearchHD.SelectedValue.Equals("all"))
        //        {
        //            Orders.SearchOrder(txt, lstvDSHD);
        //        }
        //    }
        //    else
        //        lstvDSHD.Items.Clear();

        //}

        private void lstvDSHD_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem lvi in lstvDSHD.SelectedItems)
            {
                Order o = Orders.SearchOrderById(int.Parse(lvi.Text));
                int idTable = (int)o.TableID;
                txtMaHoaDon.Text = o.OrderID.ToString();
                txtNV.Text = o.Employee.EmployeeName;
                txtNgayTao.Text = o.DateCheckIn.ToString();
                txtBan.Text = Tables.ConvertIdToSTT(idTable).ToString();
                txtTongTien.Text = uNguyenQuy.TongTien(Order_Details.GetOrderDetail(o.OrderID)) + " VND";

                btnXoaHD.Tag = o.OrderID;
                uNguyenQuy.LoadDSHD2DataGridView(dgvOrderDetail, Order_Details.GetOrderDetail(o.OrderID));
                //dgvOrderDetail.DataSource = Order_Details.Order_Detail_Records(o.OrderID);
                //dgvOrderDetail.Columns.Add(new DataGridViewColumn() { HeaderText = "Sản phẩm", Width = 150, Name = "dgvcSanPham" DataPropertyName='TenSP'});
                //dgvOrderDetail.Columns.Add(new DataGridViewColumn() { HeaderText = "Số lượng", Width = 100, Name = "dgvcSoLuong" });
                //dgvOrderDetail.Columns.Add(new DataGridViewColumn() { HeaderText = "Đơn giá", Width = 100, Name = "dgvcDonGia" });
                //dgvOrderDetail.Columns.Add(new DataGridViewColumn() { HeaderText = "Edit/Remove", Width = 100, Name = "dgvcEditRemove" });

            }
        }

        private void cbbSearchHD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvDSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDSNV.CurrentCell.ColumnIndex == 0)
            { //CurrentCell.ColumnIndex la 1 con so
                Employee nv = Employees.TimNhanVien(dgvDSNV.CurrentCell.Value.ToString());
                //load thong tin nhan vien vao form view ben canh
                txtEmail.Text = nv.Email;
                txtEmail.ReadOnly = true;
                txtHoTenNV.Text = nv.EmployeeName;
                if (nv.DOB.ToString() == String.Empty)
                {
                    dtpNgaySinhNV.Value = DateTime.Now;
                }
                else
                {
                    dtpNgaySinhNV.Value = (DateTime)nv.DOB;
                }
                txtPhoneNV.Text = nv.Mobile;
                txtDiaChi.Text = nv.Address;
                cbbRole.SelectedIndex = ((int)nv.RoleID);
                btnXoaNV.Tag = nv.EmployeeID;
            }

        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            string email;
            if (uNguyenQuy.TextBoxHopLe(txtEmail, out email))
            {
                Employee emp = Employees.TimNhanVien(email);
                if (emp != null)
                {
                    MessageBox.Show("Bạn không được phép sửa ô này", "Quán trà sữa NEWDAY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHoTenNV.Focus();
                }
            }
        }
        private void btnInsertNV_Click(object sender, EventArgs e)
        {
            Employee nv = Employees.TimNhanVien(txtEmail.Text);
            if (nv != null)
            {
                DialogResult DR = uNguyenQuy.ShowNotifice("Nhân viên đã có trong danh sách", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (DR == DialogResult.OK)
                {
                    txtEmail.Text = nv.EmployeeID.ToString();
                    txtHoTenNV.Text = nv.EmployeeName;
                    txtEmail.ReadOnly = true;
                    dtpNgaySinhNV.Text = nv.DOB.ToString();
                    txtPhoneNV.Text = nv.Mobile.ToString();
                    txtDiaChi.Text = nv.Address.ToString();
                    cbbRole.SelectedValue = (int)nv.RoleID;
                    //btnInsertNV.Visible = false;
                    //btnUpdateNV.Visible = true;
                }
                if (DR == DialogResult.Cancel)
                {
                    btnResetNV_Click(null, null);
                }
            }
            else
            {
                if (Employees.InsertNV(txtEmail.Text, txtHoTenNV.Text, dtpNgaySinhNV.Text, txtPhoneNV.Text, txtDiaChi.Text, int.Parse(cbbRole.SelectedValue.ToString())))
                {
                    uNguyenQuy.ShowNotifice("Thêm nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    uNguyenQuy.LoadDSNV2DataGridView(dgvDSNV, Employees.GetList);
                    btnResetNV_Click(null, null);
                }
            }
        }

        private void btnResetNV_Click(object sender, EventArgs e)
        {
            txtEmail.Text = String.Empty;
            txtEmail.ReadOnly = false;
            txtHoTenNV.Text = String.Empty;
            dtpNgaySinhNV.Text = String.Empty;
            cbbRole.SelectedIndex = 0;
            txtPhoneNV.Text = String.Empty;
            txtDiaChi.Text = String.Empty;
        }

        private void btnUpdateNV_Click(object sender, EventArgs e)
        {
            Employee nv = new Employee();
            string username, hoten, phone, diachi;
            if (uNguyenQuy.TextBoxHopLe(txtEmail, out username)) nv.Email = username;
            if (uNguyenQuy.TextBoxHopLe(txtHoTenNV, out hoten)) nv.EmployeeName = hoten;
            if (uNguyenQuy.TextBoxHopLe(txtPhoneNV, out phone)) nv.Mobile = phone;
            if (uNguyenQuy.TextBoxHopLe(txtDiaChi, out diachi)) nv.Address = diachi;
            nv.RoleID = int.Parse(cbbRole.SelectedValue.ToString()) + 1;
            if (Employees.CapNhatThongTin(nv))
            {
                MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                uNguyenQuy.LoadDSNV2DataGridView(dgvDSNV, Employees.GetList);
            }
            else
                MessageBox.Show("Username bạn cung cấp không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearchSP_Click(object sender, EventArgs e)
        {
            //tiem kiem SP trong tab SanPham
            int id;
            string txt;
            try
            {
                id = int.Parse(cbbSearchDMSP.SelectedValue.ToString());

            }
            catch (Exception ex)
            {
                id = 0;
            }
            if (uNguyenQuy.TextBoxHopLe(txtSearchSP, out txt))
            {
                if (id == 0)
                {
                    List<Product> lst = new List<Product>();
                    lst = Products.SearchProductByName(txt);
                    if (lst != null)
                        uNguyenQuy.LoadProduct2ListView(lst, lstvSP);
                    else
                        if (uNguyenQuy.ShowNotifice("Không có sản phẩm nào bạn cần tìm. \n Bạn có muốn xem các sản phẩm trong danh muc hien tai ko?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        lstvSP.Items.Clear();
                }
                else
                {
                    List<Product> lst = new List<Product>();
                    lst = Products.SearchProductByCatIdAndName(id, txt);
                    if (lst != null)
                        uNguyenQuy.LoadProduct2ListView(lst, lstvSP);
                    else
                        if (uNguyenQuy.ShowNotifice("Không có sản phẩm nào bạn cần tìm. \n Bạn có muốn xem các sản phẩm trong danh muc hien tai ko?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        lstvSP.Items.Clear();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = "Mã sinh tự động";
            txtMaSP.ReadOnly = true;
            txtTenSP.Text = "";
            txtGia.Text = "";
            cbbDanhMuc.SelectedIndex = 0;
            loadbtnInsUpSP();
        }

        private void lstvSP_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem lvi in lstvSP.SelectedItems)
            {
                Product sp = Products.SearchOrderByMaHD(int.Parse(lvi.Text));
                if (sp != null)
                {
                    txtMaSP.Text = sp.ProductID.ToString();
                    txtMaSP.ReadOnly = true;
                    txtTenSP.Text = sp.ProductName;
                    txtGia.Text = sp.Price.ToString();
                    cbbDanhMuc.SelectedIndex = Categories.ConvertIdToSTT(sp.CategoryID);
                    loadbtnInsUpSP();
                }
                else
                {
                    loadbtnInsUpSP();
                    MessageBox.Show("Mã sản phẩm không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtMaSP_Leave(object sender, EventArgs e)
        {
            LoadDetailSP(int.Parse(txtMaSP.Text));
        }

        private void LoadDetailSP(int maSP)
        {
            Product sp = Products.SearchOrderByMaHD(maSP);
            if (sp != null)
            {
                txtMaSP.Text = sp.ProductID.ToString();
                txtTenSP.Text = sp.ProductName;
                txtMaSP.ReadOnly = true;
                txtGia.Text = sp.Price.ToString();
                btnInsertSP.Visible = false;
                btnUpdateSP.Visible = true;
            }
            else
            {
                txtMaSP.ReadOnly = false;
                btnInsertSP.Visible = true;
                btnUpdateSP.Visible = false;
            }
        }

        private void btnUpdateSP_Click(object sender, EventArgs e)
        {
            Product sp = Products.SearchByMaSP(int.Parse(txtMaSP.Text));
            if (sp != null)
            {
                if (Products.UpdateSP(int.Parse(txtMaSP.Text), txtTenSP.Text, txtGia.Text, true))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnReset_Click(null, null);
                    Products.LoadDSSP2ListView(lstvSP);
                }
            }
        }

        private void btnInsertSP_Click(object sender, EventArgs e)
        {
            Product sp = Products.SearchByMaSP(txtTenSP.Text);
            if (sp != null)
            {
                DialogResult DR = uNguyenQuy.ShowNotifice("Sản phẩm này đã tồn tại", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (DR == DialogResult.OK)
                {
                    txtMaSP.Text = sp.ProductID.ToString();
                    txtTenSP.Text = sp.ProductName;
                    txtMaSP.ReadOnly = true;
                    txtGia.Text = sp.Price.ToString();
                    btnInsertSP.Visible = false;
                    btnUpdateSP.Visible = true;
                }
                if (DR == DialogResult.Cancel)
                {
                    btnReset_Click(null, null);
                }
            }
            if (Products.InsertSP(txtTenSP.Text, int.Parse(txtGia.Text), int.Parse(cbbDanhMuc.SelectedValue.ToString())))
            {
                uNguyenQuy.ShowNotifice("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReset_Click(null, null);
                Products.LoadDSSP2ListView(lstvSP);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            var kq = Products.SearchByMaSP(int.Parse(txtMaSP.Text));
            if (kq != null)
            {
                if (kq.Order_Details.Count() == 0)
                {
                    Products.DeleteSP(kq.ProductID);
                    MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Products.LoadDSSP2ListView(lstvSP);
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm không thành công\n Bạn phải xóa hóa đơn trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Products.LoadDSSP2ListView(lstvSP);
            }
        }

        private void cbbSearchDMSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            try
            {
                id = int.Parse(cbbSearchDMSP.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                id = 0;
            }
            if (id == 0)
            {
                Products.LoadDSSP2ListView(lstvSP);
            }
            else
            {
                LoadProcudctByCatIdToListView(id, lstvSP);
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            var kq = Employees.TimNV(int.Parse(btnXoaNV.Tag.ToString()));
            if (kq != null)
            {
                if (kq.Orders.Count() == 0)
                {
                    Employees.DeleteNV(kq.EmployeeID);
                    uNguyenQuy.LoadDSNV2DataGridView(dgvDSNV, Employees.GetList);
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                uNguyenQuy.LoadDSNV2DataGridView(dgvDSNV, Employees.GetList);
            }
        }

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            var kq = Order_Details.TimHD(int.Parse(btnXoaHD.Tag.ToString()));
            var kq1 = Orders.TimHD(int.Parse(btnXoaHD.Tag.ToString()));
            if (kq != null)
            {
                Order_Details.DeleteById(kq.OrderID);
                Orders.DeleteById(kq1.OrderID);
                Tables.UpdateStatus((int)kq1.TableID, 0);
                txtTongTien.Text = String.Empty;
                uNguyenQuy.LoadDSHD2DataGridView(dgvOrderDetail, Order_Details.GetOrderDetail(kq.OrderID));
                Orders.LoadDSHD2ListView(lstvDSHD);
            }
        }

        //---Tab Control QL Table---//
        private void LoadStatusTable(ComboBox cbb)
        {
            Dictionary<int, string> dic = Tables.StatusTable();
            cbb.DataSource = new BindingSource(dic, null);
            cbb.ValueMember = "Key";
            cbb.DisplayMember = "Value";
            cbb.SelectedIndex = 0;
        }
        private void LoadTableToListBox(ListBox lstb)
        {
            lstb.DataSource = Tables.GetListTable;
            lstb.DisplayMember = "TableName";
            lstb.ValueMember = "TableID";
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string tableName;
            if (!uNguyenQuy.TextBoxHopLe(txtTableName, out tableName))
            {
                uNguyenQuy.ShowNotifice("Tên bàn không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Table tb = new Table() { TableName = tableName, Status = int.Parse(cbbTableStatus.SelectedValue.ToString()) };
            if (Tables.InsertTable(tb))
            {
                uNguyenQuy.ShowNotifice("Thêm bàn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTableToListBox(lstbTable);
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            LoadTableToListBox(lstbTable);
            txtTableId.Text = String.Empty;
            txtTableName.Text = String.Empty;
            cbbTableStatus.SelectedIndex = 0;
        }

        private void txtSearchTable_TextChanged(object sender, EventArgs e)
        {
            List<Table> lstOut = new List<Table>();
            lstOut = Tables.SearchTable(txtSearchTable.Text);
            if (lstOut == null) LoadTableToListBox(lstbTable);
            lstbTable.DataSource = lstOut;
            lstbTable.DisplayMember = "TableName";
            lstbTable.ValueMember = "TableID";
        }

        private void lstbTable_Click(object sender, EventArgs e)
        {
            int tableId = int.Parse(lstbTable.SelectedValue.ToString());
            Table tb = Tables.SearchTableID(tableId);
            txtTableId.Text = tb.TableID + "";
            txtTableName.Text = tb.TableName;
            cbbTableStatus.SelectedIndex = (int)tb.Status;
            if (cbbTableStatus.SelectedIndex == 2)
            {
                lblTableMerge.Visible = true;
                cbbTableMerge.Visible = true;
                Tables.LoadConboBoxTable(cbbTableMerge, true);
                cbbTableMerge.SelectedValue = (tb.TableMergeId == null ? 0 : tb.TableMergeId);
            }
            else
            {
                lblTableMerge.Visible = false;
                cbbTableMerge.Visible = false;
            }
        }

        private void cbbTableStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTableStatus.SelectedIndex == 2)
            {
                lblTableMerge.Visible = true;
                cbbTableMerge.Visible = true;
                Tables.LoadConboBoxTable(cbbTableMerge, true);
            }
            else
            {
                lblTableMerge.Visible = false;
                cbbTableMerge.Visible = false;
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtTableId.Text.ToString());
            Table tb = Tables.SearchTableID(id);
            if (tb != null)
            {
                String nameTable;
                if (uNguyenQuy.TextBoxHopLe(txtTableName, out nameTable)) tb.TableName = nameTable;
                if (int.Parse(cbbTableStatus.SelectedValue.ToString()) == 2)
                {
                    if (int.Parse(cbbTableMerge.SelectedValue.ToString()) != 0)
                    {
                        tb.Status = int.Parse(cbbTableStatus.SelectedValue.ToString());
                        tb.TableMergeId = int.Parse(cbbTableMerge.SelectedValue.ToString());
                    }
                }
                else
                {
                    tb.Status = int.Parse(cbbTableStatus.SelectedValue.ToString());
                }
                if (Tables.UpdateTable(tb))
                {
                    uNguyenQuy.ShowNotifice("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadTableToListBox(lstbTable);
            }
        }

        private void btnDelTable_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtTableId.Text.ToString());
                List<Order> lstOrder = new List<Order>();
                lstOrder = Orders.SearchOrderByTableId(id);
                if (lstOrder != null)
                {
                    if (uNguyenQuy.ShowNotifice("Hành động xóa có thể làm ảnh hưởng đến dữ liệu hệ thống.\n Có chắc là muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach(Order o in lstOrder)
                        {
                            Orders.UpdateTable((int)o.OrderID, 0);
                        }
                        Tables.DeleteTable(id);
                        uNguyenQuy.ShowNotifice("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTableToListBox(lstbTable);
                    }
                    else
                        return;
                }
                else
                {
                    Tables.DeleteTable(id);
                    uNguyenQuy.ShowNotifice("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTableToListBox(lstbTable);
                }
            }
            catch (Exception ex)
            {
                uNguyenQuy.ShowNotifice("Error: Chọn bàn cần xóa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadTableToListBox(lstbTable);
            }
        }
        //---------------category----------------//
        private void LoadCategoryToListBox(ListBox lstb)
        {
            lstb.DataSource = Categories.GetList;
            lstb.DisplayMember = "CategoryName";
            lstb.ValueMember = "CategoryID";
        }

        private void lstbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(lstbCategory.SelectedValue.ToString());
                Category cat = new Category();
                cat = Categories.Search(id);
                if (cat != null)
                {
                    txtCategoryId.Text = cat.CategoryID.ToString();
                    txtCategoryName.Text = cat.CategoryName;
                    txtCategoryDesc.Text = cat.Description;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void btnCatAdd_Click(object sender, EventArgs e)
        {
            string catName;
            if(uNguyenQuy.TextBoxHopLe(txtCategoryName, out catName))
            {
                Category cat = new Category();
                cat.CategoryName = catName;
                cat.Description = txtCategoryDesc.Text;
                Categories.Insert(cat);
                LoadCategoryToListBox(lstbCategory);
            }
            else
            {
                if(uNguyenQuy.ShowNotifice("Tên danh mục không được để trống. \nBạn có muốn nhập lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    txtCategoryName.Text = String.Empty;
                    txtCategoryName.Focus();
                }
                else
                {
                    btnCatHuyBo_Click(null, null);
                }
            }
        }

        private void btnCatHuyBo_Click(object sender, EventArgs e)
        {
            LoadCategoryToListBox(lstbCategory);
            txtCategoryId.Text = String.Empty;
            txtCategoryName.Text = String.Empty;
            txtCategoryDesc.Text = String.Empty;
        }

        private void btnCatUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            Category cat = new Category();
            cat = Categories.Search(id);
            if (cat != null)
            {
                string catName;
                if (uNguyenQuy.TextBoxHopLe(txtCategoryName, out catName))
                {
                    cat.CategoryName = catName;
                }
                else
                {
                    if (uNguyenQuy.ShowNotifice("Tên danh mục không được để trống. \nBạn có muốn nhập lại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        txtCategoryName.Text = String.Empty;
                        txtCategoryName.Focus();
                    }
                    else
                    {
                        txtCategoryName.Text = cat.CategoryName;
                    }
                }
                cat.Description = txtCategoryDesc.Text;
                Categories.Update(cat);
                LoadCategoryToListBox(lstbCategory);
            }
            else
            {
                btnCatHuyBo_Click(null, null);
                uNguyenQuy.ShowNotifice("Vui lòng chọn danh mục cần Update", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCatDel_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtCategoryId.Text.ToString());
                //List<Order> lstOrder = new List<Order>();
                //lstOrder = Orders.SearchOrderByTableId(id);
                //if (lstOrder != null)
                //{
                //    if (uNguyenQuy.ShowNotifice("Hành động xóa có thể làm ảnh hưởng đến dữ liệu /hệ /thống.\n Có chắc là muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, //MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        foreach (Order o in lstOrder)
                //        {
                //            Orders.UpdateTable((int)o.OrderID, 0);
                //        }
                //        Tables.DeleteTable(id);
                //        uNguyenQuy.ShowNotifice("Xóa thành công", "Thông báo", //MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        LoadTableToListBox(lstbTable);
                //    }
                //    else
                //        return;
                //}
                //else
                //{
                    Categories.Delete(id);
                    uNguyenQuy.ShowNotifice("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategoryToListBox(lstbCategory);
                //}
            }
            catch (Exception ex)
            {
                uNguyenQuy.ShowNotifice("Error: Chọn danh mục cần xóa trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadCategoryToListBox(lstbCategory);
            }
        }

    }
}
