using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanTraSua.Utility
{
    public partial class Roles
    {
        private static DBDataContext dbcon = new DBDataContext();
        public static List<Role> GetListRole
        {
            get
            {
                return dbcon.Roles.ToList();
            }
        }
        public static List<Authorization> GetListAuthorization
        {
            get
            {
                return dbcon.Authorizations.ToList();
            }
        }
        public static void LoadRole2ComboBox(ComboBox cbb, Boolean all)
        {
            List<Role> lstRole = new List<Role>();
            if (all)
            {
                Role nvAll = new Role();
                nvAll.RoleID = 0;
                nvAll.RoleName = "--- Chưa phân quyền ---";
                lstRole.Add(nvAll);
            }
            foreach (Role r in dbcon.Roles.ToList())
            {
                lstRole.Add(r);

            }
            cbb.DataSource = lstRole;
            cbb.DisplayMember = "RoleName";
            cbb.ValueMember = "RoleID";
        }
        public static Authorization GetNameForm(int roleId)
        {
            foreach (Authorization au in GetListAuthorization)
            {
                if (au.RoleID == roleId)
                    return au;
            }
            return null;
        }
    }
}
