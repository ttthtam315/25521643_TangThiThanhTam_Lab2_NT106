
using System;
using System.IO;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _25521643_TangThiThanhTam_Lab2
{
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
        }

        private void btnDocFile_Click_1(object sender, EventArgs e)
        {
            try
            {
                string duongDan = Path.Combine(
                    Application.StartupPath, "input3.txt");

                MessageBox.Show("Đang tìm file tại:\n" + duongDan);

                if (!File.Exists(duongDan))
                {
                    MessageBox.Show("Không tìm thấy input3.txt!");
                    return;
                }

                string[] cacDong = File.ReadAllLines(duongDan);

                string duongDanKetQua = Path.Combine(
                    Application.StartupPath, "output3.txt");

                using (StreamWriter sw = new StreamWriter(duongDanKetQua))
                {
                    foreach (string dong in cacDong)
                    {
                        if (string.IsNullOrWhiteSpace(dong))
                            continue;

                        double ketQua = TinhBieuThuc(dong);

                        string dongKetQua = dong + " = " +
                            ketQua.ToString(
                                "0.################",
                                CultureInfo.InvariantCulture);

                        sw.WriteLine(dongKetQua);
                        rtbKetQua.AppendText(dongKetQua + Environment.NewLine);
                    }
                }

                MessageBox.Show("Đã tính toán và ghi vào output3.txt!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private double TinhBieuThuc(string bieuThuc)
        {
            // Tách số, toán tử và ngoặc
            MatchCollection matches = Regex.Matches(
                bieuThuc, @"\d+(?:\.\d+)?|[()+\-*/]");

            string bieuThucMoi = "";

            foreach (Match match in matches)
                bieuThucMoi += match.Value;

            // Kiểm tra biểu thức có ký tự lạ hay không
            string boKhoangTrang = Regex.Replace(bieuThuc, @"\s+", "");
            if (bieuThucMoi != boKhoangTrang)
                throw new Exception("Biểu thức không hợp lệ: " + bieuThuc);

            int viTri = 0;
            return TinhTong(bieuThucMoi, ref viTri);
        }

        private double TinhTong(string s, ref int i)
        {
            double kq = TinhTich(s, ref i);

            while (i < s.Length && (s[i] == '+' || s[i] == '-'))
            {
                char phepToan = s[i++];
                double so = TinhTich(s, ref i);

                if (phepToan == '+')
                    kq += so;
                else
                    kq -= so;
            }

            return kq;
        }

        private double TinhTich(string s, ref int i)
        {
            double kq = TinhSoHang(s, ref i);

            while (i < s.Length && (s[i] == '*' || s[i] == '/'))
            {
                char phepToan = s[i++];
                double so = TinhSoHang(s, ref i);

                if (phepToan == '*')
                    kq *= so;
                else
                {
                    if (so == 0)
                        throw new DivideByZeroException("Không thể chia cho 0.");

                    kq /= so;
                }
            }

            return kq;
        }

        private double TinhSoHang(string s, ref int i)
        {
            if (i >= s.Length)
                throw new Exception("Biểu thức không hợp lệ.");

            if (s[i] == '(')
            {
                i++;
                double kq = TinhTong(s, ref i);

                if (i >= s.Length || s[i] != ')')
                    throw new Exception("Thiếu dấu đóng ngoặc.");

                i++;
                return kq;
            }

            if (s[i] == '+' || s[i] == '-')
            {
                char dau = s[i++];
                double so = TinhSoHang(s, ref i);
                return dau == '-' ? -so : so;
            }

            int batDau = i;

            while (i < s.Length &&
                  (char.IsDigit(s[i]) || s[i] == '.'))
                i++;

            if (batDau == i)
                throw new Exception("Không đọc được số trong biểu thức.");

            return double.Parse(
                s.Substring(batDau, i - batDau),
                CultureInfo.InvariantCulture);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
