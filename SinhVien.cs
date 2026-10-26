
using System;

namespace _25521643_TangThiThanhTam_Lab2
{
    [Serializable]
    public class SinhVien
    {
        public string HoTen { get; set; }
        public int MSSV { get; set; }
        public string DienThoai { get; set; }

        public float Diem1 { get; set; }
        public float Diem2 { get; set; }
        public float Diem3 { get; set; }
        public float DiemTB { get; set; }

        public SinhVien()
        {
            HoTen = "";
            DienThoai = "";
        }

        public float TinhDiemTB()
        {
            return (Diem1 + Diem2 + Diem3) / 3.0f;
        }
    }
}
 