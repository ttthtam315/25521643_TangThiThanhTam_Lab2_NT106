using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _25521643_TangThiThanhTam_Lab2
{
    public partial class Bai02 : Form
    {
        public Bai02()
        {
            InitializeComponent();
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Title = "Chọn file văn bản";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Đọc nội dung file
                    string noiDung = File.ReadAllText(ofd.FileName);

                    // Lấy thông tin file
                    FileInfo fi = new FileInfo(ofd.FileName);

                    txtTenFile.Text = ofd.SafeFileName;
                    txtSize.Text = fi.Length + " bytes";
                    txtURL.Text = fi.FullName;

                    // Hiển thị nội dung
                    rtbNoiDung.Text = noiDung;

                    // Đếm số dòng
                    int soDong = noiDung.Length == 0
                        ? 0
                        : noiDung.Split('\n').Length;

                    txtSoDong.Text = soDong.ToString();

                    // Đếm số từ
                    string noiDungTrim = noiDung.Trim();

                    int soTu = string.IsNullOrWhiteSpace(noiDungTrim)
                        ? 0
                        : noiDungTrim.Split(
                            (char[])null,
                            StringSplitOptions.RemoveEmptyEntries
                          ).Length;

                    txtSoTu.Text = soTu.ToString();

                    // Đếm số ký tự, bao gồm khoảng trắng và xuống dòng
                    txtSoKyTu.Text = noiDung.Length.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đọc file: " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
