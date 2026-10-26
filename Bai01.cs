
using System;
using System.IO;
using System.Windows.Forms;

namespace _25521643_TangThiThanhTam_Lab2
{
    public partial class Bai01 : Form
    {
        public Bai01()
        {
            InitializeComponent();
        }

        // Doc noi dung file input1.txt
        private void btnDocFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("input1.txt"))
                {
                    rtbNoiDung.Text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi doc file: " + ex.Message);
            }
        }

        // Ghi noi dung in hoa vao output1.txt
        private void btnGhiFile_Click(object sender, EventArgs e)
        {
            try
            {
                string noiDung = rtbNoiDung.Text.ToUpper();

                using (StreamWriter sw = new StreamWriter("output1.txt"))
                {
                    sw.Write(noiDung);
                }

                MessageBox.Show("Ghi file thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi ghi file: " + ex.Message);
            }
        }

        private void btnDocFile_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader("input1.txt"))
                {
                    rtbNoiDung.Text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file: " + ex.Message);
            }
        }

        private void btnGhiFile_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("output1.txt"))
                {
                    sw.Write(rtbNoiDung.Text.ToUpper());
                }

                MessageBox.Show("Ghi file thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }
    }
}
