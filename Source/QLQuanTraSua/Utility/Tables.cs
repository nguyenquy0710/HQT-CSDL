using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static MetroFramework.Drawing.MetroPaint.BorderColor;

namespace QLQuanTraSua.Utility
{
    public partial class Tables
    {
        private static DBDataContext db = new DBDataContext();
        public static Dictionary<int, string> StatusTable()
        {
            Dictionary<int, string> dicStatusTable = new Dictionary<int, string>();
            dicStatusTable.Add(0, "Bàn Trống");
            dicStatusTable.Add(1, "Bàn có khách");
            dicStatusTable.Add(2, "Bàn được ghép");
            return dicStatusTable;
        }
        public static List<Table> GetListTable
        {
            get
            {
                return db.Tables.ToList();
            }
        }
        /// load
        public static void LoadConboBoxTable(System.Windows.Forms.ComboBox cbb, bool status = false)
        {
            List<Table> lstTable = new List<Table>();
            if (status) lstTable.Add(new Table() { TableName = "-- Bàn --", TableID = 0 });
            foreach (Table tb in GetListTable)
            {
                lstTable.Add(tb);
            }
            cbb.DataSource = lstTable;
            cbb.DisplayMember = "TableName";
            cbb.ValueMember = "TableID";
        }
        /// tim ma table
        public static Table SearchTableID(int id)
        {
            return db.Tables.FirstOrDefault(x => x.TableID == id);
        }
        public static Table SearchTableID(String ten)
        {
            return db.Tables.FirstOrDefault(x => x.TableName == ten);
        }

        public static bool UpdateStatus(int tableId, int p)
        {
            foreach (Table tb in GetListTable)
            {
                if (tb.TableID == tableId)
                {
                    tb.Status = p;
                    try { db.SubmitChanges(); return true; }
                    catch (Exception e) { return false; }
                }
            }
            return false;
        }
        public static int ConvertIdToSTT(int idTable)
        {
            int stt = 1;
            foreach (Table tb in GetListTable)
            {
                if (tb.TableID == idTable)
                    return stt;
                else
                    stt += 1;
            }
            return stt;
        }

        public static bool InsertTable(Table tb)
        {
            try
            {
                db.Tables.InsertOnSubmit(tb);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                uNguyenQuy.ShowNotifice("Error: " + ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static List<Table> SearchTable(string tableName)
        {
            return db.Tables.Where(x => x.TableName.Contains(tableName)).ToList();
        }

        public static bool UpdateTable(Table tb)
        {
            Table kq = SearchTableID(tb.TableID);
            kq.TableName = tb.TableName;
            kq.Status = tb.Status;
            kq.TableMergeId = tb.TableMergeId;
            try
            {
                db.SubmitChanges();
                return true;
            }catch(Exception ex)
            {
                uNguyenQuy.ShowNotifice("Error: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool DeleteTable(int id)
        {
            Table tb = SearchTableID(id);
            if (tb == null) return false;
            try
            {
                db.Tables.DeleteOnSubmit(tb);
                db.SubmitChanges();
                return true;
            }catch(Exception ex)
            {
                uNguyenQuy.ShowNotifice("Error: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
