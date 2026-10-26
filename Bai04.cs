
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;

namespace _25521643_TangThiThanhTam_Lab2
{
    public partial class Bai04 : Form
    {
        private List<SinhVien> danhSach = new List<SinhVien>();
        private int viTriHienTai = 0;

        public Bai04()
        {
            InitializeComponent();

            btnThem.Click += btnThem_Click;
            btnGhiFile.Click += btnGhiFile_Click;
            btnDocFile.Click += btnDocFile_Click;
            btnBack.Click += btnBack_Click;
            btnNext.Click += btnNext_Click;
        }

        // THEM SINH VIEN
        private void btnThem_Click(object? sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string maSV = txtMSSV.Text.Trim();
            string dienThoai = txtDienThoai.Text.Trim();

            if (hoTen == "")
            {
                MessageBox.Show("Vui lòng nhập họ và tên!");
                return;
            }

            if (maSV.Length != 8 || !LaChuoiSo(maSV))
            {
                MessageBox.Show("MSSV phải có đúng 8 chữ số!");
                return;
            }

            if (dienThoai.Length != 10 ||
                dienThoai[0] != '0' ||
                !LaChuoiSo(dienThoai))
            {
                MessageBox.Show(
                    "Số điện thoại phải có 10 chữ số và bắt đầu bằng 0!");
                return;
            }

            float diem1, diem2, diem3;

            if (!float.TryParse(txtDiem1.Text, out diem1) ||
                !float.TryParse(txtDiem2.Text, out diem2) ||
                !float.TryParse(txtDiem3.Text, out diem3))
            {
                MessageBox.Show("Vui lòng nhập điểm hợp lệ!");
                return;
            }

            if (diem1 < 0 || diem1 > 10 ||
                diem2 < 0 || diem2 > 10 ||
                diem3 < 0 || diem3 > 10)
            {
                MessageBox.Show("Điểm mỗi môn phải từ 0 đến 10!");
                return;
            }

            int mssv = int.Parse(maSV);

            foreach (SinhVien sv in danhSach)
            {
                if (sv.MSSV == mssv)
                {
                    MessageBox.Show("MSSV đã tồn tại!");
                    return;
                }
            }

            SinhVien svMoi = new SinhVien();
            svMoi.HoTen = hoTen;
            svMoi.MSSV = mssv;
            svMoi.DienThoai = dienThoai;
            svMoi.Diem1 = diem1;
            svMoi.Diem2 = diem2;
            svMoi.Diem3 = diem3;
            svMoi.DiemTB = (diem1 + diem2 + diem3) / 3.0f;

            danhSach.Add(svMoi);

            rtbDanhSach.AppendText(
                "Họ tên: " + svMoi.HoTen + Environment.NewLine +
                "MSSV: " + svMoi.MSSV + Environment.NewLine +
                "Điện thoại: " + svMoi.DienThoai + Environment.NewLine +
                "Điểm môn 1: " + svMoi.Diem1 + Environment.NewLine +
                "Điểm môn 2: " + svMoi.Diem2 + Environment.NewLine +
                "Điểm môn 3: " + svMoi.Diem3 + Environment.NewLine +
                "Điểm trung bình: " + svMoi.DiemTB.ToString("0.00") +
                Environment.NewLine +
                "------------------------" + Environment.NewLine
            );

            viTriHienTai = danhSach.Count - 1;
            HienThiSinhVien();

            txtHoTen.Clear();
            txtMSSV.Clear();
            txtDienThoai.Clear();
            txtDiem1.Clear();
            txtDiem2.Clear();
            txtDiem3.Clear();

            txtHoTen.Focus();

            MessageBox.Show("Thêm sinh viên thành công!");
        }

        // KIEM TRA CHUOI CHI CO SO
        private bool LaChuoiSo(string chuoi)
        {
            if (string.IsNullOrEmpty(chuoi))
                return false;

            foreach (char c in chuoi)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        // GHI FILE
        private void btnGhiFile_Click(object? sender, EventArgs e)
        {
            if (danhSach.Count == 0)
            {
                MessageBox.Show("Chưa có sinh viên nào để ghi!");
                return;
            }

            try
            {
                string duongDan = Path.Combine(
                    Application.StartupPath, "input4.txt");

                string json = JsonSerializer.Serialize(
                    danhSach,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                File.WriteAllText(duongDan, json);

                MessageBox.Show(
                    "Ghi file thành công!\n" + duongDan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }

        // DOC FILE
        private void btnDocFile_Click(object? sender, EventArgs e)
        {
            string duongDan = Path.Combine(
                Application.StartupPath, "input4.txt");

            if (!File.Exists(duongDan))
            {
                MessageBox.Show("Không tìm thấy file:\n" + duongDan);
                return;
            }

            try
            {
                string json = File.ReadAllText(duongDan);

                List<SinhVien>? danhSachDoc =
                    JsonSerializer.Deserialize<List<SinhVien>>(json);

                if (danhSachDoc == null || danhSachDoc.Count == 0)
                {
                    MessageBox.Show("File không có dữ liệu sinh viên!");
                    return;
                }

                danhSach = danhSachDoc;
                viTriHienTai = 0;

                // Hien thi danh sach trong khung noi dung
                rtbDanhSach.Clear();

                foreach (SinhVien sv in danhSach)
                {
                    rtbDanhSach.AppendText(
                        "Họ tên: " + sv.HoTen + Environment.NewLine +
                        "MSSV: " + sv.MSSV + Environment.NewLine +
                        "Điện thoại: " + sv.DienThoai + Environment.NewLine +
                        "Điểm môn 1: " + sv.Diem1 + Environment.NewLine +
                        "Điểm môn 2: " + sv.Diem2 + Environment.NewLine +
                        "Điểm môn 3: " + sv.Diem3 + Environment.NewLine +
                        "Điểm trung bình: " + sv.DiemTB.ToString("0.00") +
                        Environment.NewLine +
                        "------------------------" + Environment.NewLine
                    );
                }

                // Hien thi sinh vien dau tien o ben phai
                HienThiSinhVien();

                MessageBox.Show("Đọc file thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message);
            }
        }

        // HIEN THI SINH VIEN THEO VI TRI
        private void HienThiSinhVien()
        {
            if (danhSach.Count == 0)
            {
                txtXemHoTen.Clear();
                txtXemMSSV.Clear();
                txtXemDienThoai.Clear();
                txtXemDiem1.Clear();
                txtXemDiem2.Clear();
                txtXemDiem3.Clear();
                txtDiemTB.Clear();

                lblTrang.Text = "0/0";
                return;
            }

            SinhVien sv = danhSach[viTriHienTai];

            txtXemHoTen.Text = sv.HoTen;
            txtXemMSSV.Text = sv.MSSV.ToString();
            txtXemDienThoai.Text = sv.DienThoai;
            txtXemDiem1.Text = sv.Diem1.ToString();
            txtXemDiem2.Text = sv.Diem2.ToString();
            txtXemDiem3.Text = sv.Diem3.ToString();
            txtDiemTB.Text = sv.DiemTB.ToString("0.00");

            lblTrang.Text =
                (viTriHienTai + 1) + "/" + danhSach.Count;
        }

        // BACK
        private void btnBack_Click(object? sender, EventArgs e)
        {
            if (danhSach.Count == 0)
            {
                MessageBox.Show("Chưa có danh sách sinh viên!");
                return;
            }

            if (viTriHienTai > 0)
            {
                viTriHienTai--;
                HienThiSinhVien();
            }
            else
            {
                MessageBox.Show("Đây là sinh viên đầu tiên!");
            }
        }

        // NEXT
        private void btnNext_Click(object? sender, EventArgs e)
        {
            if (danhSach.Count == 0)
            {
                MessageBox.Show("Chưa có danh sách sinh viên!");
                return;
            }

            if (viTriHienTai < danhSach.Count - 1)
            {
                viTriHienTai++;
                HienThiSinhVien();
            }
            else
            {
                MessageBox.Show("Đây là sinh viên cuối cùng!");
            }
        }
    }
}
