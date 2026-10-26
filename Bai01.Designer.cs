namespace _25521643_TangThiThanhTam_Lab2
{
    partial class Bai01
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
            btnGhiFile = new Button();
            rtbNoiDung = new RichTextBox();
            SuspendLayout();
            // 
            // btnDocFile
            // 
            btnDocFile.Location = new Point(54, 51);
            btnDocFile.Name = "btnDocFile";
            btnDocFile.Size = new Size(112, 48);
            btnDocFile.TabIndex = 0;
            btnDocFile.Text = "ĐỌC FILE";
            btnDocFile.UseVisualStyleBackColor = true;
            btnDocFile.Click += btnDocFile_Click_1;
            // 
            // btnGhiFile
            // 
            btnGhiFile.Location = new Point(54, 150);
            btnGhiFile.Name = "btnGhiFile";
            btnGhiFile.Size = new Size(112, 45);
            btnGhiFile.TabIndex = 1;
            btnGhiFile.Text = "GHI FILE";
            btnGhiFile.UseVisualStyleBackColor = true;
            btnGhiFile.Click += btnGhiFile_Click_1;
            // 
            // rtbNoiDung
            // 
            rtbNoiDung.Location = new Point(210, 51);
            rtbNoiDung.Name = "rtbNoiDung";
            rtbNoiDung.Size = new Size(230, 144);
            rtbNoiDung.TabIndex = 2;
            rtbNoiDung.Text = "";
            // 
            // Bai01
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtbNoiDung);
            Controls.Add(btnGhiFile);
            Controls.Add(btnDocFile);
            Name = "Bai01";
            Text = "Bai01";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDocFile;
        private Button btnGhiFile;
        private RichTextBox rtbNoiDung;
    }
}