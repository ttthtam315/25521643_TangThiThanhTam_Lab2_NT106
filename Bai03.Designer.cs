namespace _25521643_TangThiThanhTam_Lab2
{
    partial class Bai03
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
            btnThoat = new Button();
            rtbKetQua = new RichTextBox();
            SuspendLayout();
            // 
            // btnDocFile
            // 
            btnDocFile.Location = new Point(41, 41);
            btnDocFile.Name = "btnDocFile";
            btnDocFile.Size = new Size(190, 34);
            btnDocFile.TabIndex = 0;
            btnDocFile.Text = "Đọc file và Tính toán";
            btnDocFile.UseVisualStyleBackColor = true;
            btnDocFile.Click += btnDocFile_Click_1;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(41, 127);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(190, 34);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // rtbKetQua
            // 
            rtbKetQua.Location = new Point(259, 41);
            rtbKetQua.Name = "rtbKetQua";
            rtbKetQua.Size = new Size(237, 120);
            rtbKetQua.TabIndex = 2;
            rtbKetQua.Text = "";
            // 
            // Bai03
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbKetQua);
            Controls.Add(btnThoat);
            Controls.Add(btnDocFile);
            Name = "Bai03";
            Text = "Bai03";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDocFile;
        private Button btnThoat;
        private RichTextBox rtbKetQua;
    }
}