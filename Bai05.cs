
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _25521643_TangThiThanhTam_Lab2
{
    public partial class Bai05 : Form
    {
        private class Phim
        {
            public string TenPhim;
            public int GiaVe;
            public List<string> PhongChieu = new List<string>();
        }

        private class Ve
        {
            public string TenPhim;
            public string Phong;
            public string Ghe;
            public string KhachHang;
            public int GiaTien;
        }

        private Dictionary<string, Phim> danhSachPhim =
            new Dictionary<string, Phim>();

        private List<Ve> danhSachVe = new List<Ve>();

        private readonly string fileInput =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input5.txt");

        private readonly string fileOutput =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output5.txt");

        private readonly string fileVe =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "veDaBan5.txt");

        private Dictionary<string, double> heSoGiaGhe =
            new Dictionary<string, double>()
        {
            { "A1", 0.25 }, { "A5", 0.25 },
            { "C1", 0.25 }, { "C5", 0.25 },
            { "A2", 1 }, { "A3", 1 }, { "A4", 1 },
            { "C2", 1 }, { "C3", 1 }, { "C4", 1 },
            { "B2", 2 }, { "B3", 2 }, { "B4", 2 }
        };

        private string[] danhSachGhe =
        {
            "A1", "A2", "A3", "A4", "A5",
            "B2", "B3", "B4",
            "C1", "C2", "C3", "C4", "C5"
        };

        public Bai05()
        {
            InitializeComponent();

            cboPhim.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhong.DropDownStyle = ComboBoxStyle.DropDownList;
   
            rtbNoiDung.ReadOnly = true;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            cboPhim.SelectedIndexChanged += cboPhim_SelectedIndexChanged;
            cboPhong.SelectedIndexChanged += cboPhong_SelectedIndexChanged;

            btnDocFile.Click += btnDocFile_Click;
            btnGhiFile.Click += btnGhiFile_Click;
            btnDatVe.Click += btnDatVe_Click;
            btnXuatFile.Click += btnXuatFile_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;

            DocVeDaBan();
            DocFilePhim();
        }

        // Đọc danh sách phim từ input5.txt
        private void DocFilePhim()
        {
            if (!File.Exists(fileInput))
            {
                lblTrangThai.Text = "Chưa có input5.txt";
                return;
            }

            try
            {
                string[] dong = File.ReadAllLines(fileInput, Encoding.UTF8)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => x.Trim())
                    .ToArray();

                danhSachPhim.Clear();

                int i = 0;

                while (i < dong.Length - 1)
                {
                    int gia;

                    // Một phim bắt đầu bằng tên phim,
                    // dòng kế tiếp là giá vé dạng số.
                    if (!int.TryParse(dong[i + 1], out gia))
                    {
                        i++;
                        continue;
                    }

                    Phim phim = new Phim();
                    phim.TenPhim = dong[i];
                    phim.GiaVe = gia;

                    i += 2;

                    // Đọc các phòng cho đến khi gặp phim tiếp theo.
                    while (i < dong.Length)
                    {
                        int giaPhimTiepTheo;

                        if (i + 1 < dong.Length &&
                            int.TryParse(dong[i + 1],
                                out giaPhimTiepTheo))
                        {
                            break;
                        }

                        phim.PhongChieu.Add(dong[i]);
                        i++;
                    }

                    danhSachPhim[phim.TenPhim] = phim;
                }

                cboPhim.Items.Clear();

                foreach (Phim phim in danhSachPhim.Values)
                {
                    cboPhim.Items.Add(phim.TenPhim);
                }

                if (cboPhim.Items.Count > 0)
                    cboPhim.SelectedIndex = 0;

                HienThiVeDaDat();
                lblTrangThai.Text = "Đọc file thành công";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message);
            }
        }

        // Ghi thông tin phim vào input5.txt
        private void btnGhiFile_Click(object? sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(
                    fileInput, false, Encoding.UTF8))
                {
                    foreach (Phim phim in danhSachPhim.Values)
                    {
                        sw.WriteLine(phim.TenPhim);
                        sw.WriteLine(phim.GiaVe);

                        foreach (string phong in phim.PhongChieu)
                        {
                            sw.WriteLine(phong);
                        }
                    }
                }

                lblTrangThai.Text = "Đã ghi input5.txt";
                MessageBox.Show("Ghi file thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }

        // Nút đọc file
        private void btnDocFile_Click(object? sender, EventArgs e)
        {
            DocFilePhim();
        }

        // Chọn phim
        private void cboPhim_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            cboPhong.Items.Clear();
            clbGhe.Items.Clear();

            if (cboPhim.SelectedIndex == -1)
                return;

            string tenPhim = cboPhim.Text;
            Phim phim = danhSachPhim[tenPhim];

            foreach (string phong in phim.PhongChieu)
            {
                cboPhong.Items.Add(phong);
            }

            if (cboPhong.Items.Count > 0)
                cboPhong.SelectedIndex = 0;
        }

        // Chọn phòng
        private void cboPhong_SelectedIndexChanged (object? sender, EventArgs e)
        {
            CapNhatGhe();
        }

        // Hiển thị những ghế chưa bán
        private void CapNhatGhe()
        {
            clbGhe.Items.Clear();

            if (cboPhim.SelectedIndex == -1 ||
                cboPhong.SelectedIndex == -1)
                return;

            string tenPhim = cboPhim.Text;
            string phong = cboPhong.Text;

            foreach (string ghe in danhSachGhe)
            {
                bool daBan = danhSachVe.Any(v =>
                    v.TenPhim == tenPhim &&
                    v.Phong == phong &&
                    v.Ghe == ghe);

                if (!daBan)
                    clbGhe.Items.Add(ghe);
            }
        }

        // Tính giá vé theo hệ số ghế
        private int TinhGiaVe(string tenPhim, string ghe)
        {
            int giaChuan = danhSachPhim[tenPhim].GiaVe;

            return (int)(giaChuan * heSoGiaGhe[ghe]);
        }

        // Đặt vé
        private void btnDatVe_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!");
                txtHoTen.Focus();
                return;
            }

            if (cboPhim.SelectedIndex == -1 ||
                cboPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phim và phòng chiếu!");
                return;
            }

            if (clbGhe.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế!");
                return;
            }

            if (clbGhe.CheckedItems.Count > 2)
            {
                MessageBox.Show("Mỗi lần chỉ được đặt tối đa 2 vé!");
                return;
            }

            string tenPhim = cboPhim.Text;
            string phong = cboPhong.Text;
            string khachHang = txtHoTen.Text.Trim();

            List<string> gheChon = new List<string>();

            foreach (object item in clbGhe.CheckedItems)
            {
                gheChon.Add(item.ToString());
            }

            int tongTien = 0;

            foreach (string ghe in gheChon)
            {
                int gia = TinhGiaVe(tenPhim, ghe);
                tongTien += gia;

                Ve ve = new Ve();
                ve.TenPhim = tenPhim;
                ve.Phong = phong;
                ve.Ghe = ghe;
                ve.KhachHang = khachHang;
                ve.GiaTien = gia;

                danhSachVe.Add(ve);
            }

            LuuVeDaBan();

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";

            HienThiVeDaDat();
            CapNhatGhe();

            MessageBox.Show("Đặt vé thành công!");
        }

        // Hiển thị vé đã đặt
        private void HienThiVeDaDat()
        {
            rtbNoiDung.Clear();

            foreach (Ve ve in danhSachVe)
            {
                rtbNoiDung.AppendText(
                    "Khách hàng: " + ve.KhachHang + Environment.NewLine +
                    "Phim: " + ve.TenPhim + Environment.NewLine +
                    "Phòng: " + ve.Phong + Environment.NewLine +
                    "Ghế: " + ve.Ghe + Environment.NewLine +
                    "Giá vé: " + ve.GiaTien.ToString("N0") +
                    " VNĐ" + Environment.NewLine +
                    "------------------------------" +
                    Environment.NewLine);
            }
        }

        // Lưu vé đã bán ra file riêng để giữ dữ liệu qua lần chạy
        private void LuuVeDaBan()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(
                    fileVe, false, Encoding.UTF8))
                {
                    foreach (Ve ve in danhSachVe)
                    {
                        sw.WriteLine(
                            ve.TenPhim + "|" +
                            ve.Phong + "|" +
                            ve.Ghe + "|" +
                            ve.KhachHang + "|" +
                            ve.GiaTien);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu vé: " + ex.Message);
            }
        }

        // Đọc vé đã bán
        private void DocVeDaBan()
        {
            if (!File.Exists(fileVe))
                return;

            try
            {
                foreach (string dong in File.ReadAllLines(
                    fileVe, Encoding.UTF8))
                {
                    string[] p = dong.Split('|');

                    if (p.Length != 5)
                        continue;

                    int gia;

                    if (!int.TryParse(p[4], out gia))
                        continue;

                    Ve ve = new Ve();
                    ve.TenPhim = p[0];
                    ve.Phong = p[1];
                    ve.Ghe = p[2];
                    ve.KhachHang = p[3];
                    ve.GiaTien = gia;

                    danhSachVe.Add(ve);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc vé đã bán: " + ex.Message);
            }
        }

        // Xuất thống kê doanh thu
        private void btnXuatFile_Click(object? sender, EventArgs e)
        {
            if (danhSachPhim.Count == 0)
            {
                MessageBox.Show("Vui lòng đọc input5.txt trước!");
                return;
            }

            try
            {
                progressBar1.Value = 0;
                lblTrangThai.Text = "Đang xuất file...";
                Application.DoEvents();

                var thongKe = danhSachPhim.Values.Select(phim =>
                {
                    int tongGhe = phim.PhongChieu.Count *
                                  danhSachGhe.Length;

                    int soVeBan = danhSachVe.Count(v =>
                        v.TenPhim == phim.TenPhim);

                    int doanhThu = danhSachVe
                        .Where(v => v.TenPhim == phim.TenPhim)
                        .Sum(v => v.GiaTien);

                    int soVeTon = tongGhe - soVeBan;

                    double tiLe = tongGhe == 0 ? 0 :
                        (double)soVeBan / tongGhe * 100;

                    return new
                    {
                        TenPhim = phim.TenPhim,
                        SoVeBan = soVeBan,
                        SoVeTon = soVeTon,
                        TiLe = tiLe,
                        DoanhThu = doanhThu
                    };
                })
                .OrderByDescending(x => x.DoanhThu)
                .ToList();

                using (StreamWriter sw = new StreamWriter(
                    fileOutput, false, Encoding.UTF8))
                {
                    sw.WriteLine("THỐNG KÊ DOANH THU PHÒNG VÉ");
                    sw.WriteLine("==============================");

                    int tongPhim = thongKe.Count;

                    for (int i = 0; i < tongPhim; i++)
                    {
                        var phim = thongKe[i];

                        sw.WriteLine("Xếp hạng: " + (i + 1));
                        sw.WriteLine("Tên phim: " + phim.TenPhim);
                        sw.WriteLine("Số lượng vé bán ra: " + phim.SoVeBan);
                        sw.WriteLine("Số lượng vé tồn: " + phim.SoVeTon);
                        sw.WriteLine("Tỉ lệ vé bán ra: " +
                            phim.TiLe.ToString("F2") + "%");
                        sw.WriteLine("Doanh thu: " +
                            phim.DoanhThu.ToString("N0") + " VNĐ");
                        sw.WriteLine("------------------------------");

                        progressBar1.Value =
                            (i + 1) * 100 / tongPhim;

                        lblTrangThai.Text =
                            "Đang xuất: " + (i + 1) +
                            "/" + tongPhim + " phim";

                        Application.DoEvents();
                    }
                }

                progressBar1.Value = 100;
                lblTrangThai.Text = "Xuất file hoàn tất";

                MessageBox.Show(
                    "Đã xuất thống kê thành công!\n" + fileOutput);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message);
                lblTrangThai.Text = "Xuất file thất bại";
            }
        }

        // Xóa thông tin đang nhập
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            txtHoTen.Clear();
            lblTongTien.Text = "0 VNĐ";

            for (int i = 0; i < clbGhe.Items.Count; i++)
            {
                clbGhe.SetItemChecked(i, false);
            }

            txtHoTen.Focus();
        }

        // Thoát chương trình
        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
