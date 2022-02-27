using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanTraSua.Utility
{
    public class SanPham_OrderDetail_Order
    {
        private int idUser;
        private String hoTenNV;
        private int idBan;
        private int idOrder;
        private int maSP;
        private String tenSP;
        private int soLuong;
        private int gia;
        private DateTime ngayTao;
        private bool status;

        public int IdUser { set; get; }
        public String HoTenNV { set; get; }
        public int IdBan { set; get; }
        public int IdOrder { set; get; }
        public int MaSP { set; get; }
        public String TenSP { set; get; }
        public int SoLuong { set; get; }
        public DateTime NgayTao { set; get; }
        public bool Status { set; get; }
        public int Gia { set; get; }
    }
}
