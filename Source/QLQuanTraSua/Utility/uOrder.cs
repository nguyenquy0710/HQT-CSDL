using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanTraSua.Utility
{
    public partial class Orders
    {
        private static DBDataContext db = new DBDataContext();
        public static List<Order> GetList
        {
            get
            {
                return db.Orders.ToList();
            }
        }

        public static void LoadDSHD2ListView(ListView lstv)
        {           
            lstv.Items.Clear();
            lstv.Clear();
            lstv.Refresh();
            lstv.View = View.Details;
            lstv.Columns.Add(new ColumnHeader() { Text = "MaHD", Name = "chMaHD", Width = 60 });
            lstv.Columns.Add(new ColumnHeader() { Text = "Nhân viên", Name = "chNhanVien", Width = 150 });
            lstv.Columns.Add(new ColumnHeader() { Text = "Bàn", Name = "chBan", Width = 60 });
            lstv.Columns.Add(new ColumnHeader() { Text = "Ngày tạo", Name = "chNgayTao", Width = 80 });
            lstv.Columns.Add(new ColumnHeader() { Text = "Trạng Thái", Name = "chTrangThai", Width = 115 });
            lstv.GridLines = true;
            lstv.FullRowSelect = true;

            int i = 0;          
            foreach (Order o in db.Orders.ToList())
            {
                int idTable = (int)o.TableID;
                lstv.Items.Add(o.OrderID.ToString());
                lstv.Items[i].SubItems.Add(o.Employee.EmployeeName);
                lstv.Items[i].SubItems.Add("Bàn " + Tables.ConvertIdToSTT(idTable));
                lstv.Items[i].SubItems.Add(((DateTime)o.DateCheckIn).ToShortDateString());
                lstv.Items[i].SubItems.Add(o.Status == 1 ? "Chưa thanh toán" : "Đã thanh toán");
                i++;
            }
        }

        //public static void SearchOrderByNhanVien(string p, ListView lstv)
        //{
        //    NhanVien nv = uNhanVien.TimNhanVien(p);
        //    if (nv != null)
        //    {
        //        lstv.Items.Clear();
        //        lstv.Refresh();
        //        int i = 0;
        //        foreach (Order o in db.Orders.Where(x => x.IdUser.Equals(nv.IdUser)).ToList())
        //        {
        //            lstv.Items.Add(o.IdOrder.ToString());
        //            lstv.Items[i].SubItems.Add(o.NhanVien.HoTenNV);
        //            lstv.Items[i].SubItems.Add(o.NgayTao.ToString());
        //            i++;
        //        }
        //    }
        //    else lstv.Items.Clear();
        //}
        public static Order TimHD(int ma)
        {
            return db.Orders.FirstOrDefault(x => x.OrderID == ma);
        }

        public static Order SearchOrderById(int p)
        {
            foreach (Order o in GetList)
            {
                if (o.OrderID == p)
                {
                    return o;
                }
            }
            return null;
        }
        public static List<Order> SearchOrderByTableId(int tb)
        {
            List<Order> lst = new List<Order>();
            foreach (Order o in GetList)
            {
                if (o.TableID == tb)
                {
                    lst.Add(o);
                }
            }
            if (lst.Count() != 0)
                return lst;
            else
                return null;
        }
        public static List<Order> SearchOrderByTableId(int tb, int emp)
        {
            List<Order> lst = new List<Order>();
            foreach (Order o in GetList)
            {
                if (o.TableID == tb)
                {
                    lst.Add(o);
                }
            }
            if (lst.Count() != 0)
                return lst;
            else
                return null;
        }
        public static void SearchOrder(string txt, ListView lstvDSHD)
        {

        }
        public static bool Insert(Order addOr)
        {
            try
            {
                db.Orders.InsertOnSubmit(addOr);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public static bool DeleteById(int p)
        {
            foreach (Order_Detail od in Order_Details.GetList)
            {
                if (od.OrderID == p)
                    return false;
            }
            db.Orders.DeleteOnSubmit(SearchOrderById(p));
            db.SubmitChanges();
            return true;
        }

        public static bool UpdateStatus(int orderid, int status)
        {
            foreach (Order o in GetList)
            {
                if (o.OrderID == orderid)
                    o.Status = status;
            }
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool UpdateTable(int orderID, int tableId)
        {
            foreach (Order o in GetList)
            {
                if (o.OrderID == orderID)
                    o.TableID = tableId;
            }
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                uNguyenQuy.ShowNotifice("Error: " + e.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
