using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanTraSua.Utility
{
    public partial class Products
    {
        private static DBDataContext db = new DBDataContext();
        public static List<Product> GetListProduct
        {
            get
            {
                return db.Products.ToList();
            }
        }
        public static Product SearchByMaSP(int id)
        {
            foreach (Product sp in db.Products.ToList())
            {
                {
                    if (sp.ProductID.Equals(id))
                        return sp;
                }
            }
            return null;
        }
        public static Product SearchProductID(int ma)
        {
            return db.Products.FirstOrDefault(x => x.ProductID == ma);
        }
        public static Product SearchByMaSP(string ten)
        {
            foreach (Product sp in db.Products.ToList())
            {
                {
                    if (sp.ProductName.ToUpper().Contains(ten.ToUpper()))
                        return sp;
                }
            }
            return null;
        }

        public static void LoadDSSP2ListView(ListView lstv)
        {
            lstv.Items.Clear();
            lstv.Refresh();
            lstv.View = View.Details;
            lstv.Columns.Add(new ColumnHeader() { Text = "Mã sản phẩm", Name = "chdMaSP", Width = 130, TextAlign = HorizontalAlignment.Center });
            lstv.Columns.Add(new ColumnHeader() { Text = "Tên sản phẩm", Name = "chdTenSP", Width = 340, TextAlign = HorizontalAlignment.Center });
            //lstv.Columns.Add(new ColumnHeader() { Text = "Tinh trang", Name = "chdTinhTrangSP", Width = 200 });
            lstv.GridLines = true;
            lstv.FullRowSelect = true;
            int i = 0;
            foreach (Product sp in db.Products.ToList())
            {
                lstv.Items.Add(sp.ProductID.ToString());
                lstv.Items[i].SubItems.Add(sp.ProductName);
                //lstv.Items[i].SubItems.Add(sp.StatusSP ? "Con nguyen lieu" : "Tam thoi het nguyen lieu");
                i++;
            }
        }

        public static Product SearchOrderByMaHD(int MaSP)
        {
            List<Product> lstSp = db.Products.Where(x => x.ProductID.Equals(MaSP)).ToList();
            foreach (Product sp in lstSp)
            {
                return sp;
            }
            return null;
        }

        public static bool UpdateSP(int maSP, string tenSP, string motaSP, bool tinhTrang)
        {
            Product sp = SearchByMaSP(maSP);
            if (sp != null)
            {
                sp.ProductName = tenSP;
                sp.Description = motaSP;
                //sp.StatusSP = tinhTrang;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        public static bool InsertSP(string tenSP, int giaSP, int DMSP)
        {
            if (SearchByMaSP(tenSP) == null)
            {
                Product sp = new Product();
                sp.ProductName = tenSP;
                sp.Price = giaSP;
                sp.CategoryID = DMSP;
                db.Products.InsertOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public static void DeleteSP(int id)
        {
            var kq = SearchProductID(id);
            if (kq != null)
            {
                if (kq.Order_Details.Count() == 0)
                {
                    db.Products.DeleteOnSubmit(kq);
                    db.SubmitChanges();
                }
            }
        }

        public static List<Product> SearchProductByCatIdAndName(int id, string txt)
        {
            List<Product> lst = new List<Product>();
            foreach (Product p in GetListProduct)
            {
                if (p.CategoryID == id && p.ProductName.ToUpper().Contains(txt.ToUpper()))
                    lst.Add(p);
            }
            if (lst.Count() != 0)
                return lst;
            else
                return null;
        }

        public static List<Product> SearchProductByName(string txt)
        {
            List<Product> lst = new List<Product>();
            foreach (Product p in GetListProduct)
            {
                if (p.ProductName.ToUpper().Contains(txt.ToUpper()))
                    lst.Add(p);
            }
            if (lst.Count() != 0)
                return lst;
            else
                return null;
        }

        public static int ConvertIdToSTT(int idPro)
        {
            int stt = 1;
            foreach (Product pr in GetListProduct)
            {
                if (pr.ProductID == idPro)
                    return stt;
                else
                    stt += 1;
            }
            return stt;
        }
    }
}
