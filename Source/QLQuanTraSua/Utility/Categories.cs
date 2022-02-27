using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanTraSua.Utility
{
    public partial class Categories
    {
        private static DBDataContext db = new DBDataContext();
        public static List<Category> GetList { get { return db.Categories.ToList(); } }
        public static int ConvertIdToSTT(int idCat)
        {
            int stt = 1;
            foreach (Category tb in GetList)
            {
                if (tb.CategoryID == idCat)
                    return stt;
                else
                    stt += 1;
            }
            return stt;
        }

        public static Category Search(int id)
        {
            foreach(Category cat in GetList)
            {
                if (cat.CategoryID == id)
                    return cat;
            }
            return null;
        }

        public static bool Insert(Category cat)
        {
            try
            {
                db.Categories.InsertOnSubmit(cat);
                db.SubmitChanges();
                return true;
            }catch(Exception ex)
            {
                uNguyenQuy.ShowNotifice("Error: " + ex.Message, "Thông báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool Update(Category cat)
        {
            Category kq = Search((int)cat.CategoryID);
            kq.CategoryName = cat.CategoryName;
            kq.Description = cat.Description;
            try
            {
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                uNguyenQuy.ShowNotifice("Error: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool Delete(int id)
        {
            Category tb = Search(id);
            if (tb == null) return false;
            try
            {
                db.Categories.DeleteOnSubmit(tb);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                uNguyenQuy.ShowNotifice("Error: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
