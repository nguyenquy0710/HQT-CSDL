using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanTraSua.Utility
{
    public class uHinhAnh
    {
        //private static DBDataContext db = new DBDataContext();
        //public static bool SaveHinhAnh(PictureBox ptb, String id, String mode)
        //{
        //    if (mode.ToUpper().Equals("NV") || mode.ToUpper().Equals("NHANVIEN") || mode.ToUpper().Equals("NHAN VIEN") || mode.ToUpper().Equals("NHÂN VIÊN") || mode.ToUpper().Equals("SP") || mode.ToUpper().Equals("SANPHAM") || mode.ToUpper().Equals("SAN PHAM") || mode.ToUpper().Equals("SẢN PHẨM"))
        //    {
        //        //luu hinh vao tbHinhAnh
        //        HinhAnh hinh = new HinhAnh();
        //        hinh.NameImg = ptb.Tag.ToString();
        //        hinh.PathUrl = @"\upload\img\" + ptb.Tag.ToString();
        //        SaveHinhAnhToFolder(ptb, mode);
        //        db.HinhAnhs.InsertOnSubmit(hinh);
        //        db.SubmitChanges();
        //        //relation with mode
        //        HinhAnh ha = db.HinhAnhs.ToList().LastOrDefault();
        //        if (mode.ToUpper().Equals("NV") || mode.ToUpper().Equals("NHANVIEN") || mode.ToUpper().Equals("NHAN VIEN") || mode.ToUpper().Equals("NHÂN VIÊN"))
        //        {
        //            NhanVien nv = uNhanVien.TimNhanVien(id);
        //            return Relation_NhanVien_Img(nv, ha);
        //        }
        //        if (mode.ToUpper().Equals("SP") || mode.ToUpper().Equals("SANPHAM") || mode.ToUpper().Equals("SAN PHAM") || mode.ToUpper().Equals("SẢN PHẨM"))
        //        {
        //            SanPham sp = uSanPham.SearchByMaSP(id);
        //            return Relation_SP_Img(sp, ha);

        //        }
        //        return false;
        //    }
        //    else
        //        return false;
        //}

        //private static void SaveHinhAnhToFolder(PictureBox ptb, String mode)
        //{
        //    if (mode.ToUpper().Equals("NV") || mode.ToUpper().Equals("NHANVIEN") || mode.ToUpper().Equals("NHAN VIEN") || mode.ToUpper().Equals("NHÂN VIÊN") || mode.ToUpper().Equals("SP") || mode.ToUpper().Equals("SANPHAM") || mode.ToUpper().Equals("SAN PHAM") || mode.ToUpper().Equals("SẢN PHẨM"))
        //    {
        //        if (mode.ToUpper().Equals("NV") || mode.ToUpper().Equals("NHANVIEN") || mode.ToUpper().Equals("NHAN VIEN") || mode.ToUpper().Equals("NHÂN VIÊN"))
        //        {
        //            String path = Application.StartupPath + @"\Upload\Avatar";
        //            DirectoryInfo di = new DirectoryInfo(path);
        //            if (!di.Exists)
        //                Directory.CreateDirectory(path);
        //            FileInfo fi = new FileInfo(ptb.Tag.ToString());
        //            string des = path + @"\" + ptb.Tag.ToString();
        //            File.Delete(des);
        //            fi.CopyTo(des);
        //        }
        //        if (mode.ToUpper().Equals("SP") || mode.ToUpper().Equals("SANPHAM") || mode.ToUpper().Equals("SAN PHAM") || mode.ToUpper().Equals("SẢN PHẨM"))
        //        {
        //            String path = Application.StartupPath + @"\Upload\Product";
        //            DirectoryInfo di = new DirectoryInfo(path);
        //            if (!di.Exists)
        //                Directory.CreateDirectory(path);
        //            FileInfo fi = new FileInfo(ptb.Tag.ToString());
        //            string des = path + @"\" + ptb.Tag.ToString();
        //            File.Delete(des);
        //            fi.CopyTo(des);
        //        }
        //    }
        //}

        //public static bool Relation_NhanVien_Img(NhanVien nv, HinhAnh ha)
        //{
        //    if (nv != null)
        //    {
        //        db.Relation_NhanVien_Imgs.InsertOnSubmit(new Relation_NhanVien_Img()
        //        {
        //            IdImg = ha.IdImg,
        //            IdUser = nv.IdUser
        //        });
        //        db.SubmitChanges();
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public static bool Relation_SP_Img(SanPham sp, HinhAnh ha)
        //{
        //    if (sp != null)
        //    {
        //        db.Relation_SP_Imgs.InsertOnSubmit(new Relation_SP_Img()
        //        {
        //            IdImg = ha.IdImg,
        //            MaSP = sp.MaSP,
        //        });
        //        db.SubmitChanges();
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public static void LoadHinhAnh(PictureBox ptb, String txt, String mode)
        //{
        //    ptb.Image = null;
        //    if (mode.ToUpper().Equals("NV") || mode.ToUpper().Equals("NHANVIEN") || mode.ToUpper().Equals("NHAN VIEN") || mode.ToUpper().Equals("NHÂN VIÊN") || mode.ToUpper().Equals("SP") || mode.ToUpper().Equals("SANPHAM") || mode.ToUpper().Equals("SAN PHAM") || mode.ToUpper().Equals("SẢN PHẨM"))
        //    {
        //        if (mode.ToUpper().Equals("NV") || mode.ToUpper().Equals("NHANVIEN") || mode.ToUpper().Equals("NHAN VIEN") || mode.ToUpper().Equals("NHÂN VIÊN"))
        //        {
        //            //load hinh cua nhan vien
        //            //tim nhan vien
        //            NhanVien nv = uNhanVien.TimNhanVien(txt);
        //            if (nv == null)
        //                return;
        //            //tim quan he giua nhan vien vs hinh anh
        //            List<Relation_NhanVien_Img> lstRNI = db.Relation_NhanVien_Imgs.Where(x => x.IdUser.Equals(nv.IdUser)).ToList();
        //            if (lstRNI.Count() == 0)
        //                return;
        //            Relation_NhanVien_Img rni = lstRNI.LastOrDefault();
        //            //tim hinh anh co quan he vs nhan vien do
        //            List<HinhAnh> lstHinh = db.HinhAnhs.Where(y => y.IdImg.Equals(rni.IdImg)).ToList();
        //            if (lstHinh.Count() == 0)
        //                return;
        //            HinhAnh hinh = lstHinh.LastOrDefault();
        //            //convert pucture from BINARY to IMAGE
        //            //MemoryStream memImg = new MemoryStream(hinh.Picture.ToArray());
        //            //Image imgStream = Image.FromStream(memImg);
        //            //if (imgStream == null)
        //            //    return;
        //            ////load PictureBox
        //            //ptb.Image = imgStream;
        //            ptb.SizeMode = PictureBoxSizeMode.StretchImage;
        //        }
        //        if (mode.ToUpper().Equals("SP") || mode.ToUpper().Equals("SANPHAM") || mode.ToUpper().Equals("SAN PHAM") || mode.ToUpper().Equals("SẢN PHẨM"))
        //        {
        //            //load hinh cua san pham
        //        }
        //    }
        //}
    }
}
