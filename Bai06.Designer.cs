
namespace _25521643_TangThiThanhTam_Lab2
{
    partial class Bai06
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpNhapMonAn = new GroupBox();
            lblNhapTenMon = new Label();
            txtTenMonAn = new TextBox();
            lblNguoiDung = new Label();
            cboNguoiDung = new ComboBox();
            lblHinhAnh = new Label();
            txtHinhAnh = new TextBox();
            btnChonAnh = new Button();
            btnThem = new Button();
            grpDanhSach = new GroupBox();
            lvMonAn = new ListView();
            colID = new ColumnHeader();
            colTenMon = new ColumnHeader();
            colNguoiDongGop = new ColumnHeader();
            btnTimMonAn = new Button();
            btnTaiLai = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            grpKetQua = new GroupBox();
            picMonAn = new PictureBox();
            lblKetQua = new Label();
            lblTenMon = new Label();
            lblTenMonKetQua = new Label();
            lblNguoiDongGop = new Label();
            btnCapNhatAnh = new Button();
            grpNhapMonAn.SuspendLayout();
            grpDanhSach.SuspendLayout();
            grpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMonAn).BeginInit();
            SuspendLayout();
            // 
            // grpNhapMonAn
            // 
            grpNhapMonAn.Controls.Add(lblNhapTenMon);
            grpNhapMonAn.Controls.Add(txtTenMonAn);
            grpNhapMonAn.Controls.Add(lblNguoiDung);
            grpNhapMonAn.Controls.Add(cboNguoiDung);
            grpNhapMonAn.Controls.Add(lblHinhAnh);
            grpNhapMonAn.Controls.Add(txtHinhAnh);
            grpNhapMonAn.Controls.Add(btnChonAnh);
            grpNhapMonAn.Controls.Add(btnThem);
            grpNhapMonAn.Location = new Point(25, 60);
            grpNhapMonAn.Name = "grpNhapMonAn";
            grpNhapMonAn.Size = new Size(455, 245);
            grpNhapMonAn.TabIndex = 1;
            grpNhapMonAn.TabStop = false;
            grpNhapMonAn.Text = "Nhập thông tin món ăn";
            // 
            // lblNhapTenMon
            // 
            lblNhapTenMon.AutoSize = true;
            lblNhapTenMon.Location = new Point(15, 35);
            lblNhapTenMon.Name = "lblNhapTenMon";
            lblNhapTenMon.Size = new Size(116, 28);
            lblNhapTenMon.TabIndex = 0;
            lblNhapTenMon.Text = "Tên món ăn:";
            // 
            // txtTenMonAn
            // 
            txtTenMonAn.Location = new Point(174, 32);
            txtTenMonAn.Name = "txtTenMonAn";
            txtTenMonAn.Size = new Size(275, 34);
            txtTenMonAn.TabIndex = 1;
            // 
            // lblNguoiDung
            // 
            lblNguoiDung.AutoSize = true;
            lblNguoiDung.Location = new Point(15, 78);
            lblNguoiDung.Name = "lblNguoiDung";
            lblNguoiDung.Size = new Size(165, 28);
            lblNguoiDung.TabIndex = 2;
            lblNguoiDung.Text = "Người đóng góp:";
            // 
            // cboNguoiDung
            // 
            cboNguoiDung.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNguoiDung.Location = new Point(174, 73);
            cboNguoiDung.Name = "cboNguoiDung";
            cboNguoiDung.Size = new Size(275, 36);
            cboNguoiDung.TabIndex = 3;
            // 
            // lblHinhAnh
            // 
            lblHinhAnh.AutoSize = true;
            lblHinhAnh.Location = new Point(15, 122);
            lblHinhAnh.Name = "lblHinhAnh";
            lblHinhAnh.Size = new Size(94, 28);
            lblHinhAnh.TabIndex = 4;
            lblHinhAnh.Text = "Hình ảnh:";
            // 
            // txtHinhAnh
            // 
            txtHinhAnh.Location = new Point(155, 118);
            txtHinhAnh.Name = "txtHinhAnh";
            txtHinhAnh.ReadOnly = true;
            txtHinhAnh.Size = new Size(165, 34);
            txtHinhAnh.TabIndex = 5;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(325, 115);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(105, 37);
            btnChonAnh.TabIndex = 6;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(210, 228, 250);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnThem.Location = new Point(90, 170);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(275, 45);
            btnThem.TabIndex = 7;
            btnThem.Text = "+  Thêm món ăn";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(lvMonAn);
            grpDanhSach.Location = new Point(500, 60);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(475, 245);
            grpDanhSach.TabIndex = 2;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách món ăn hiện có";
            // 
            // lvMonAn
            // 
            lvMonAn.Columns.AddRange(new ColumnHeader[] { colID, colTenMon, colNguoiDongGop });
            lvMonAn.FullRowSelect = true;
            lvMonAn.GridLines = true;
            lvMonAn.Location = new Point(15, 28);
            lvMonAn.MultiSelect = false;
            lvMonAn.Name = "lvMonAn";
            lvMonAn.Size = new Size(445, 200);
            lvMonAn.TabIndex = 0;
            lvMonAn.UseCompatibleStateImageBehavior = false;
            lvMonAn.View = View.Details;
            // 
            // colID
            // 
            colID.Text = "ID";
            colID.Width = 55;
            // 
            // colTenMon
            // 
            colTenMon.Text = "Tên món ăn";
            colTenMon.Width = 175;
            // 
            // colNguoiDongGop
            // 
            colNguoiDongGop.Text = "Người đóng góp";
            colNguoiDongGop.Width = 190;
            // 
            // btnTimMonAn
            // 
            btnTimMonAn.Location = new Point(25, 325);
            btnTimMonAn.Name = "btnTimMonAn";
            btnTimMonAn.Size = new Size(131, 48);
            btnTimMonAn.TabIndex = 3;
            btnTimMonAn.Text = "Tìm món ăn";
            btnTimMonAn.UseVisualStyleBackColor = true;
            // 
            // btnTaiLai
            // 
            btnTaiLai.Location = new Point(180, 325);
            btnTaiLai.Name = "btnTaiLai";
            btnTaiLai.Size = new Size(165, 48);
            btnTaiLai.TabIndex = 4;
            btnTaiLai.Text = "Tải lại danh sách";
            btnTaiLai.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(375, 325);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(171, 48);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "Xóa món ăn";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(838, 325);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(137, 48);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // grpKetQua
            // 
            grpKetQua.Controls.Add(picMonAn);
            grpKetQua.Controls.Add(lblKetQua);
            grpKetQua.Controls.Add(lblTenMon);
            grpKetQua.Controls.Add(lblTenMonKetQua);
            grpKetQua.Controls.Add(lblNguoiDongGop);
            grpKetQua.Location = new Point(25, 395);
            grpKetQua.Name = "grpKetQua";
            grpKetQua.Size = new Size(950, 225);
            grpKetQua.TabIndex = 7;
            grpKetQua.TabStop = false;
            grpKetQua.Text = "Món ăn hôm nay là";
            // 
            // picMonAn
            // 
            picMonAn.BackColor = Color.Gainsboro;
            picMonAn.BorderStyle = BorderStyle.FixedSingle;
            picMonAn.Location = new Point(20, 35);
            picMonAn.Name = "picMonAn";
            picMonAn.Size = new Size(300, 170);
            picMonAn.SizeMode = PictureBoxSizeMode.Zoom;
            picMonAn.TabIndex = 0;
            picMonAn.TabStop = false;
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblKetQua.ForeColor = Color.FromArgb(30, 70, 110);
            lblKetQua.Location = new Point(345, 30);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(254, 36);
            lblKetQua.TabIndex = 1;
            lblKetQua.Text = "Kết quả ngẫu nhiên";
            // 
            // lblTenMon
            // 
            lblTenMon.AutoSize = true;
            lblTenMon.Location = new Point(350, 75);
            lblTenMon.Name = "lblTenMon";
            lblTenMon.Size = new Size(116, 28);
            lblTenMon.TabIndex = 2;
            lblTenMon.Text = "Tên món ăn:";
            // 
            // lblTenMonKetQua
            // 
            lblTenMonKetQua.BorderStyle = BorderStyle.FixedSingle;
            lblTenMonKetQua.Location = new Point(490, 70);
            lblTenMonKetQua.Name = "lblTenMonKetQua";
            lblTenMonKetQua.Size = new Size(420, 32);
            lblTenMonKetQua.TabIndex = 3;
            lblTenMonKetQua.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNguoiDongGop
            // 
            lblNguoiDongGop.BorderStyle = BorderStyle.FixedSingle;
            lblNguoiDongGop.Location = new Point(350, 125);
            lblNguoiDongGop.Name = "lblNguoiDongGop";
            lblNguoiDongGop.Size = new Size(560, 32);
            lblNguoiDongGop.TabIndex = 4;
            lblNguoiDongGop.Text = "Người đóng góp: ";
            lblNguoiDongGop.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCapNhatAnh
            // 
            btnCapNhatAnh.Location = new Point(571, 325);
            btnCapNhatAnh.Name = "btnCapNhatAnh";
            btnCapNhatAnh.Size = new Size(228, 48);
            btnCapNhatAnh.TabIndex = 8;
            btnCapNhatAnh.Text = "Cập nhật ảnh món ăn";
            btnCapNhatAnh.UseVisualStyleBackColor = true;
            // 
            // Bai06
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1163, 650);
            Controls.Add(btnCapNhatAnh);
            Controls.Add(grpNhapMonAn);
            Controls.Add(grpDanhSach);
            Controls.Add(btnTimMonAn);
            Controls.Add(btnTaiLai);
            Controls.Add(btnXoa);
            Controls.Add(btnThoat);
            Controls.Add(grpKetQua);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(900, 600);
            Name = "Bai06";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 06 ";
            grpNhapMonAn.ResumeLayout(false);
            grpNhapMonAn.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            grpKetQua.ResumeLayout(false);
            grpKetQua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picMonAn).EndInit();
            ResumeLayout(false);
        }
        private System.Windows.Forms.GroupBox grpNhapMonAn;
        private System.Windows.Forms.Label lblNhapTenMon;
        private System.Windows.Forms.TextBox txtTenMonAn;
        private System.Windows.Forms.Label lblNguoiDung;
        private System.Windows.Forms.ComboBox cboNguoiDung;
        private System.Windows.Forms.Label lblHinhAnh;
        private System.Windows.Forms.TextBox txtHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.ListView lvMonAn;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colTenMon;
        private System.Windows.Forms.ColumnHeader colNguoiDongGop;
        private System.Windows.Forms.Button btnTimMonAn;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.GroupBox grpKetQua;
        private System.Windows.Forms.PictureBox picMonAn;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lblTenMonKetQua;
        private System.Windows.Forms.Label lblNguoiDongGop;
        private Button btnCapNhatAnh;
    }
}
