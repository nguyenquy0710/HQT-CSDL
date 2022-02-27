using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanTraSua.Utility
{
    public partial class Order_Details
    {
        private static DBDataContext db = new DBDataContext();
        
        public static List<Order_Detail> GetList
        {
            get
            {
                return db.Order_Details.ToList();
            }
        }
        public static Order_Detail TimHD(int ma)
        {
            return db.Order_Details.FirstOrDefault(x => x.OrderID == ma);
        }
        public static List<v_OrderDetail_Product> GetOrderDetail(int orderId)
        {
            List<v_OrderDetail_Product> lst = new List<v_OrderDetail_Product>();
            foreach (v_OrderDetail_Product v in db.v_OrderDetail_Products.ToList())
            {
                if (v.OrderID == orderId)
                    lst.Add(v);
            }
            if (lst.Count() != 0)
                return lst;
            else
                return null;
        }

        public static List<Order_Detail> SearchOrderDetailByOrderID(int v1)
        {
            return db.Order_Details.Where(x => x.OrderID == v1).ToList();
        }

        public static List<U_SearchBillListResult> SearchOrderDetailByOrderIDErr(int v1)
        {
            return db.U_SearchBillList(v1).ToList();
        }

        public static bool Insert(Order_Detail od)
        {
            try
            {
                db.Order_Details.InsertOnSubmit(od);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                uNguyenQuy.ShowNotifice("Error: " + e.Message, "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeleteById(int p)
        {
            try
            {
                foreach (Order_Detail od in GetList)
                {
                    if (od.OrderID == p)
                    {
                        db.Order_Details.DeleteOnSubmit(od);
                    }
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static Order_Detail SearchByOrderAndProduct(int orderId, int productId)
        {
            foreach (Order_Detail odt in GetList)
            {
                if (odt.OrderID == orderId && odt.ProductID == productId)
                    return odt;
            }
            return null;
        }

        public static bool UpdateByOrderProduct(int orderId, int productId, int qty)
        {
            Order_Detail od = SearchByOrderAndProduct(orderId, productId);
            if (od != null)
            {
                od.Quantity = od.Quantity+qty;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    uNguyenQuy.ShowNotifice("Error: " + ex.Message, "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
            }
            else
                return false;
        }
    }
}
