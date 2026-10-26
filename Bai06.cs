
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace _25521643_TangThiThanhTam_Lab2
{
    public partial class Bai06 : Form
    {
        private readonly string duongDanDB =
            Path.Combine(Application.StartupPath, "HomNayAnGi.db");

        private readonly Random random = new Random();

        public Bai06()
        {
            InitializeComponent();

            // Gắn sự kiện cho các nút
            btnThem.Click += btnThem_Click;
            btnChonAnh.Click += btnChonAnh_Click;
            btnTimMonAn.Click += btnTimMonAn_Click;
            btnXoa.Click += btnXoa_Click;
            btnTaiLai.Click += btnTaiLai_Click;
            btnThoat.Click += btnThoat_Click;
            btnCapNhatAnh.Click += btnCapNhatAnh_Click;

            try
            {
                KhoiTaoDatabase();
                TaiDanhSachNguoiDung();
                TaiDanhSachMonAn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể khởi tạo dữ liệu SQLite!\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Kết nối đến database SQLite
        private SqliteConnection TaoKetNoi()
        {
            SqliteConnection conn =
                new SqliteConnection("Data Source=" + duongDanDB);

            conn.Open();

            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "PRAGMA foreign_keys = ON;";
                cmd.ExecuteNonQuery();
            }

            return conn;
        }

        // Tạo database và hai bảng
        private void KhoiTaoDatabase()
        {
            using (SqliteConnection conn = TaoKetNoi())
            {
                string sql = @"
                    CREATE TABLE IF NOT EXISTS NguoiDung (
                        IDNCC INTEGER PRIMARY KEY AUTOINCREMENT,
                        HoVaTen TEXT NOT NULL,
                        QuyenHan TEXT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS MonAn (
                        IDMA INTEGER PRIMARY KEY AUTOINCREMENT,
                        TenMonAn TEXT NOT NULL,
                        HinhAnh TEXT,
                        IDNCC INTEGER NOT NULL,
                        FOREIGN KEY (IDNCC)
                            REFERENCES NguoiDung(IDNCC)
                    );
                ";

                using (SqliteCommand cmd =
                    new SqliteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Thêm người dùng mẫu nếu bảng đang trống
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        "SELECT COUNT(*) FROM NguoiDung;";

                    long soNguoiDung =
                        Convert.ToInt64(cmd.ExecuteScalar());

                    if (soNguoiDung == 0)
                    {
                        cmd.CommandText = @"
                            INSERT INTO NguoiDung
                                (HoVaTen, QuyenHan)
                            VALUES
                                ('Tăng Thị Thanh Tâm', 'NguoiDung'),
                                ('Đoàn Hưng', 'NguoiDung'),
                                ('Trương Thị Hoài Hương', 'NguoiDung');
                        ";

                        cmd.ExecuteNonQuery();
                    }
                }

                // Thêm món ăn mẫu nếu bảng đang trống
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        "SELECT COUNT(*) FROM MonAn;";

                    long soMonAn =
                        Convert.ToInt64(cmd.ExecuteScalar());

                    if (soMonAn == 0)
                    {
                        cmd.CommandText = @"
                            INSERT INTO MonAn
                                (TenMonAn, HinhAnh, IDNCC)
                            SELECT 'Bún đậu mắm tôm', '', IDNCC
                            FROM NguoiDung
                            WHERE HoVaTen = 'Tăng Thị Thanh Tâm'
                            LIMIT 1;

                            INSERT INTO MonAn
                                (TenMonAn, HinhAnh, IDNCC)
                            SELECT 'Gà rán Jollibee', '', IDNCC
                            FROM NguoiDung
                            WHERE HoVaTen = 'Đoàn Hưng'
                            LIMIT 1;

                            INSERT INTO MonAn
                                (TenMonAn, HinhAnh, IDNCC)
                            SELECT 'Cơm tấm sườn trứng chả', '', IDNCC
                            FROM NguoiDung
                            WHERE HoVaTen = 'Trương Thị Hoài Hương'
                            LIMIT 1;

                            INSERT INTO MonAn
                                (TenMonAn, HinhAnh, IDNCC)
                            SELECT 'Chân gà sốt thái', '', IDNCC
                            FROM NguoiDung
                            WHERE HoVaTen = 'Tăng Thị Thanh Tâm'
                            LIMIT 1;

                            INSERT INTO MonAn
                                (TenMonAn, HinhAnh, IDNCC)
                            SELECT 'Bánh tráng trộn', '', IDNCC
                            FROM NguoiDung
                            WHERE HoVaTen = 'Trương Thị Hoài Hương'
                            LIMIT 1;
                        ";

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Đọc người đóng góp từ database
        private void TaiDanhSachNguoiDung()
        {
            List<KeyValuePair<int, string>> danhSach =
                new List<KeyValuePair<int, string>>();

            using (SqliteConnection conn = TaoKetNoi())
            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT IDNCC, HoVaTen
                    FROM NguoiDung
                    ORDER BY HoVaTen;
                ";

                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSach.Add(
                            new KeyValuePair<int, string>(
                                reader.GetInt32(0),
                                reader.GetString(1)));
                    }
                }
            }

            cboNguoiDung.DataSource = null;
            cboNguoiDung.DisplayMember = "Value";
            cboNguoiDung.ValueMember = "Key";
            cboNguoiDung.DataSource = danhSach;
        }

        // Đọc danh sách món ăn và người đóng góp
        private void TaiDanhSachMonAn()
        {
            lvMonAn.Items.Clear();

            using (SqliteConnection conn = TaoKetNoi())
            using (SqliteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT M.IDMA, M.TenMonAn, N.HoVaTen
                    FROM MonAn M
                    INNER JOIN NguoiDung N
                        ON M.IDNCC = N.IDNCC
                    ORDER BY M.IDMA;
                ";

                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item =
                            new ListViewItem(reader.GetInt32(0).ToString());

                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));

                        lvMonAn.Items.Add(item);
                    }
                }
            }
        }

        // Chọn ảnh từ máy tính
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn hình ảnh món ăn";
                dialog.Filter =
                    "File hình ảnh|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtHinhAnh.Text = dialog.FileName;
                }
            }
        }

        // Thêm món ăn vào SQLite
        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenMon = txtTenMonAn.Text.Trim();
            string hinhAnh = txtHinhAnh.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenMon))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!");
                txtTenMonAn.Focus();
                return;
            }

            if (cboNguoiDung.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn người đóng góp!");
                return;
            }

            int idNCC = Convert.ToInt32(cboNguoiDung.SelectedValue);

            try
            {
                using (SqliteConnection conn = TaoKetNoi())
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC)
                        VALUES (@ten, @anh, @idNCC);
                    ";

                    cmd.Parameters.AddWithValue("@ten", tenMon);
                    cmd.Parameters.AddWithValue("@anh", hinhAnh);
                    cmd.Parameters.AddWithValue("@idNCC", idNCC);

                    cmd.ExecuteNonQuery();
                }

                TaiDanhSachMonAn();

                txtTenMonAn.Clear();
                txtHinhAnh.Clear();
                txtTenMonAn.Focus();

                MessageBox.Show("Thêm món ăn thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm món ăn!\n" + ex.Message);
            }
        }

        // Chọn ngẫu nhiên món ăn từ database
        private void btnTimMonAn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqliteConnection conn = TaoKetNoi())
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT M.TenMonAn, M.HinhAnh, N.HoVaTen
                        FROM MonAn M
                        INNER JOIN NguoiDung N
                            ON M.IDNCC = N.IDNCC
                        ORDER BY RANDOM()
                        LIMIT 1;
                    ";

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Danh sách món ăn đang trống!");
                            return;
                        }

                        string tenMon = reader.GetString(0);
                        string hinhAnh = reader.IsDBNull(1)
                            ? ""
                            : reader.GetString(1);
                        string nguoiGop = reader.GetString(2);

                        lblTenMonKetQua.Text = tenMon;
                        lblNguoiDongGop.Text =
                            "Người đóng góp: " + nguoiGop;

                        HienThiAnh(hinhAnh);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tìm món ăn!\n" + ex.Message);
            }
        }

        // Hiển thị ảnh và giải phóng ảnh cũ
        private void HienThiAnh(string duongDan)
        {
            Image anhCu = picMonAn.Image;
            picMonAn.Image = null;

            if (anhCu != null)
                anhCu.Dispose();

            if (string.IsNullOrWhiteSpace(duongDan)
                || !File.Exists(duongDan))
            {
                return;
            }

            using (FileStream fs = new FileStream(
                duongDan, FileMode.Open, FileAccess.Read))
            using (Image anhGoc = Image.FromStream(fs))
            {
                picMonAn.Image = new Bitmap(anhGoc);
            }
        }

        // Xóa món ăn đang chọn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvMonAn.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!");
                return;
            }

            ListViewItem item = lvMonAn.SelectedItems[0];
            int idMon = int.Parse(item.Text);
            string tenMon = item.SubItems[1].Text;

            DialogResult xacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa món " + tenMon + "?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (xacNhan != DialogResult.Yes)
                return;

            try
            {
                using (SqliteConnection conn = TaoKetNoi())
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        "DELETE FROM MonAn WHERE IDMA = @id;";

                    cmd.Parameters.AddWithValue("@id", idMon);
                    cmd.ExecuteNonQuery();
                }

                TaiDanhSachMonAn();

                lblTenMonKetQua.Text = "";
                lblNguoiDongGop.Text = "Người đóng góp: ";
                HienThiAnh("");

                MessageBox.Show("Đã xóa món ăn thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa món ăn!\n" + ex.Message);
            }
        }

        // Tải lại danh sách từ database
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            TaiDanhSachNguoiDung();
            TaiDanhSachMonAn();
        }

        // Thoát Form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (picMonAn.Image != null)
            {
                picMonAn.Image.Dispose();
                picMonAn.Image = null;
            }

            base.OnFormClosed(e);
        }
        // Cap nhat anh mon an 
        private void btnCapNhatAnh_Click(object sender, EventArgs e)
        {
            if (lvMonAn.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần cập nhật ảnh!");
                return;
            }

            int idMon = int.Parse(lvMonAn.SelectedItems[0].Text);

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn ảnh món ăn";
                dialog.Filter = "File hình ảnh|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (SqliteConnection conn = TaoKetNoi())
                    using (SqliteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText =
                            "UPDATE MonAn SET HinhAnh = @anh WHERE IDMA = @id;";

                        cmd.Parameters.AddWithValue("@anh", dialog.FileName);
                        cmd.Parameters.AddWithValue("@id", idMon);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cập nhật ảnh thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật ảnh: " + ex.Message);
                }
            }
        }
    }
}
