using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SachOnlineLab01.Models
{
    public class GioHang
    {
        private SachOnlineEntities db = new SachOnlineEntities();
        public int iMaSach { get; set; }

        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien
        {
            get
            {
                return iSoLuong * dDonGia;
            }
        }

        

        //Khởi tạo giỏ hàng theo MaSach được truyền vào với SoLuong mặc public GioHang (int ms)


        public GioHang(int ms) {

            iMaSach = ms;

            SACH s = db.SACHes.Single(n => n.MaSach == iMaSach);

            sTenSach = s.TenSach;

            sAnhBia = s.AnhBia;

            dDonGia = double.Parse(s.GiaBan.ToString()); 
            
            iSoLuong = 1;

            
        }
    }
}