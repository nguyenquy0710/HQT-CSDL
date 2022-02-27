using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanTraSua.Utility
{
    public partial class Employees
    {
        //khai bao bien ket noi csdl
        private static DBDataContext db = new DBDataContext();
        //danh sach nhan vien
        public static List<Employee> GetList
        {
            get
            {
                return db.Employees.ToList();
            }
        }
        public static List<v_Employee_Role> GetListEmployeeRole = db.v_Employee_Roles.ToList();
        public static Employee TimNV(int ma)
        {
            return db.Employees.FirstOrDefault(x => x.EmployeeID == ma);
        }
        public static Employee TimNhanVien(int idNV)
        {
            foreach (Employee nv in GetList)
            {
                if (nv.EmployeeID.Equals(idNV))
                    return nv;
            }
            return null;
        }
        public static Employee TimNhanVien(string email)
        {
            foreach (Employee nv in GetList)
            {
                if (nv.Email.Equals(email))
                    return nv;
            }
            return null;
        }
        public static List<v_Employee_Role> TimNhanVienTheoTen(String hoTenNV)
        {
            List<v_Employee_Role> sOutput = new List<v_Employee_Role>();
            foreach (v_Employee_Role nv in GetListEmployeeRole)
            {
                if (nv.EmployeeName.ToUpper().Contains(hoTenNV.ToUpper()))
                    sOutput.Add(nv);
            }
            return sOutput;
        }
        public static bool CapNhatMatKhau(String txtUser, String txtPass)
        {
            Employee nv = TimNhanVien(txtUser);
            if (nv != null)
            {
                nv.Password = uNguyenQuy.ToMD5(txtPass);
                db.SubmitChanges();
                return true;
            }
            return false;
        }
        public static void LoadDSNV2ListBox(ListBox lstb)
        {
            lstb.DataSource = db.Employees.ToList();
            lstb.DisplayMember = "Tên đăng nhập";
            lstb.ValueMember = "TenNV";
        }
        public static void LoadDSNV2ListBox(ListBox lstb, String txt)
        {
            //Contains == like trong SQLSERVER
            lstb.DataSource = db.Employees.Where(x => x.Email.ToUpper().Contains(txt.ToUpper()) || x.Email.ToUpper().Contains(txt.ToUpper()));
            lstb.DisplayMember = "Ten Nhan Vien";
            lstb.ValueMember = "Email";
        }

        public static bool InsertNV(string email, string ten, string ngaysinh, string sdt, string diachi, int role)
        {
            if (TimNhanVien(email) == null)
            //if(true)
            {
                Employee nv = new Employee();
                nv.Email = email;
                nv.Password = uNguyenQuy.ToMD5("10");
                nv.EmployeeName = ten;
                nv.DOB = DateTime.ParseExact(ngaysinh, "d/M/yyyy", CultureInfo.InvariantCulture);
                nv.Mobile = sdt;
                nv.Address = diachi;
                nv.RoleID = role;
                try
                {
                    db.Employees.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    uNguyenQuy.ShowNotifice("Error: " + ex.Message, "Thong Bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //return true;
            }
            return false;
        }



        public static bool CapNhatThongTin(Employee nv)
        {
            Employee kq = TimNhanVien(nv.Email);
            if (kq != null)
            {
                kq.EmployeeName = nv.EmployeeName;
                kq.DOB = nv.DOB;
                kq.Mobile = nv.Mobile;
                kq.Address = nv.Address;
                kq.RoleID = nv.RoleID;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void SaveHinhAnhNhanVien(PictureBox ptbAvatar, string txtUsername, string mode)
        {
            
        }

        public static void DeleteNV(int ma)
        {
            var kq = TimNV(ma);
            if (kq != null)
            {
                if (kq.Orders.Count() == 0)
                {
                    db.Employees.DeleteOnSubmit(kq);
                    db.SubmitChanges();
                }
            }
        }
    }
}
