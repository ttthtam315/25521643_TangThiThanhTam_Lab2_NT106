using System.Drawing;
using System.Windows.Forms;

namespace _25521643_TangThiThanhTam_Lab2
{
    partial class Bai02
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDocFile = new Button();
            lblTenFile = new Label();
            txtTenFile = new TextBox();
            lblSize = new Label();
            txtSize = new TextBox();
            lblURL = new Label();
            txtURL = new TextBox();
            lblSoDong = new Label();
            txtSoDong = new TextBox();
            lblSoTu = new Label();
            txtSoTu = new TextBox();
            lblSoKyTu = new Label();
            txtSoKyTu = new TextBox();
            rtbNoiDung = new RichTextBox();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // btnDocFile
            // 
            btnDocFile.Location = new Point(29, 12);
            btnDocFile.Name = "btnDocFile";
            btnDocFile.Size = new Size(363, 34);
            btnDocFile.TabIndex = 0;
            btnDocFile.Text = "Read from File";
            btnDocFile.UseVisualStyleBackColor = true;
            btnDocFile.Click += btnDocFile_Click;
            // 
            // lblTenFile
            // 
            lblTenFile.AutoSize = true;
            lblTenFile.Location = new Point(29, 84);
            lblTenFile.Name = "lblTenFile";
            lblTenFile.Size = new Size(87, 25);
            lblTenFile.TabIndex = 1;
            lblTenFile.Text = "File name";
            // 
            // txtTenFile
            // 
            txtTenFile.Location = new Point(192, 78);
            txtTenFile.Name = "txtTenFile";
            txtTenFile.Size = new Size(200, 31);
            txtTenFile.TabIndex = 2;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(29, 136);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(43, 25);
            lblSize.TabIndex = 3;
            lblSize.Text = "Size";
            // 
            // txtSize
            // 
            txtSize.Location = new Point(192, 130);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(200, 31);
            txtSize.TabIndex = 4;
            // 
            // lblURL
            // 
            lblURL.AutoSize = true;
            lblURL.Location = new Point(29, 188);
            lblURL.Name = "lblURL";
            lblURL.Size = new Size(43, 25);
            lblURL.TabIndex = 5;
            lblURL.Text = "URL";
            // 
            // txtURL
            // 
            txtURL.Location = new Point(192, 182);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(200, 31);
            txtURL.TabIndex = 6;
            // 
            // lblSoDong
            // 
            lblSoDong.AutoSize = true;
            lblSoDong.Location = new Point(29, 241);
            lblSoDong.Name = "lblSoDong";
            lblSoDong.Size = new Size(93, 25);
            lblSoDong.TabIndex = 7;
            lblSoDong.Text = "Line count";
            // 
            // txtSoDong
            // 
            txtSoDong.Location = new Point(192, 235);
            txtSoDong.Name = "txtSoDong";
            txtSoDong.Size = new Size(200, 31);
            txtSoDong.TabIndex = 8;
            // 
            // lblSoTu
            // 
            lblSoTu.AutoSize = true;
            lblSoTu.Location = new Point(29, 293);
            lblSoTu.Name = "lblSoTu";
            lblSoTu.Size = new Size(114, 25);
            lblSoTu.TabIndex = 9;
            lblSoTu.Text = "Words count";
            // 
            // txtSoTu
            // 
            txtSoTu.AcceptsReturn = true;
            txtSoTu.Location = new Point(192, 287);
            txtSoTu.Name = "txtSoTu";
            txtSoTu.Size = new Size(200, 31);
            txtSoTu.TabIndex = 10;
            // 
            // lblSoKyTu
            // 
            lblSoKyTu.AutoSize = true;
            lblSoKyTu.Location = new Point(29, 347);
            lblSoKyTu.Name = "lblSoKyTu";
            lblSoKyTu.Size = new Size(136, 25);
            lblSoKyTu.TabIndex = 11;
            lblSoKyTu.Text = "Character count";
            // 
            // txtSoKyTu
            // 
            txtSoKyTu.Location = new Point(192, 341);
            txtSoKyTu.Name = "txtSoKyTu";
            txtSoKyTu.Size = new Size(200, 31);
            txtSoKyTu.TabIndex = 12;
            // 
            // rtbNoiDung
            // 
            rtbNoiDung.Location = new Point(425, 12);
            rtbNoiDung.Name = "rtbNoiDung";
            rtbNoiDung.Size = new Size(264, 423);
            rtbNoiDung.TabIndex = 13;
            rtbNoiDung.Text = "";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(31, 401);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(361, 34);
            btnThoat.TabIndex = 14;
            btnThoat.Text = "Exit";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // Bai02
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 537);
            Controls.Add(btnThoat);
            Controls.Add(rtbNoiDung);
            Controls.Add(txtSoKyTu);
            Controls.Add(lblSoKyTu);
            Controls.Add(txtSoTu);
            Controls.Add(lblSoTu);
            Controls.Add(txtSoDong);
            Controls.Add(lblSoDong);
            Controls.Add(txtURL);
            Controls.Add(lblURL);
            Controls.Add(txtSize);
            Controls.Add(lblSize);
            Controls.Add(txtTenFile);
            Controls.Add(lblTenFile);
            Controls.Add(btnDocFile);
            Name = "Bai02";
            Text = "Bai02";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDocFile;
        private Label lblTenFile;
        private TextBox txtTenFile;
        private Label lblSize;
        private TextBox txtSize;
        private Label lblURL;
        private TextBox txtURL;
        private Label lblSoDong;
        private TextBox txtSoDong;
        private Label lblSoTu;
        private TextBox txtSoTu;
        private Label lblSoKyTu;
        private TextBox txtSoKyTu;
        private RichTextBox rtbNoiDung;
        private Button btnThoat;
    }
}