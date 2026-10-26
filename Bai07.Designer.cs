
namespace _25521643_TangThiThanhTam_Lab2
{
    partial class Bai07
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TreeView tvwThuMuc;
        private System.Windows.Forms.GroupBox grpFileContent;
        private System.Windows.Forms.RichTextBox rtbNoiDung;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.SplitContainer splitContainer1;

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
            this.components =
                new System.ComponentModel.Container();

            this.tvwThuMuc =
                new System.Windows.Forms.TreeView();

            this.grpFileContent =
                new System.Windows.Forms.GroupBox();

            this.rtbNoiDung =
                new System.Windows.Forms.RichTextBox();

            this.picPreview =
                new System.Windows.Forms.PictureBox();

            this.splitContainer1 =
                new System.Windows.Forms.SplitContainer();

            this.grpFileContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)
                (this.picPreview)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.splitContainer1)).BeginInit();

            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();

            // 
            // tvwThuMuc
            // 
            this.tvwThuMuc.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.tvwThuMuc.Location =
                new System.Drawing.Point(0, 0);

            this.tvwThuMuc.Name = "tvwThuMuc";

            this.tvwThuMuc.Size =
                new System.Drawing.Size(250, 540);

            this.tvwThuMuc.TabIndex = 0;

            // 
            // grpFileContent
            // 
            this.grpFileContent.Controls.Add(
                this.picPreview);

            this.grpFileContent.Controls.Add(
                this.rtbNoiDung);

            this.grpFileContent.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.grpFileContent.Location =
                new System.Drawing.Point(0, 0);

            this.grpFileContent.Name =
                "grpFileContent";

            this.grpFileContent.Padding =
                new System.Windows.Forms.Padding(8);

            this.grpFileContent.Size =
                new System.Drawing.Size(590, 540);

            this.grpFileContent.TabIndex = 0;

            this.grpFileContent.TabStop = false;

            this.grpFileContent.Text = "File Content";

            // 
            // rtbNoiDung
            // 
            this.rtbNoiDung.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.rtbNoiDung.Location =
                new System.Drawing.Point(11, 27);

            this.rtbNoiDung.Name = "rtbNoiDung";

            this.rtbNoiDung.ReadOnly = true;

            this.rtbNoiDung.Size =
                new System.Drawing.Size(568, 502);

            this.rtbNoiDung.TabIndex = 0;

            this.rtbNoiDung.Text = "";

            this.rtbNoiDung.WordWrap = false;

            this.rtbNoiDung.Visible = false;

            // 
            // picPreview
            // 
            this.picPreview.BackColor =
                System.Drawing.Color.White;

            this.picPreview.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.picPreview.Location =
                new System.Drawing.Point(11, 27);

            this.picPreview.Name = "picPreview";

            this.picPreview.Size =
                new System.Drawing.Size(568, 502);

            this.picPreview.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.picPreview.TabIndex = 1;

            this.picPreview.TabStop = false;

            this.picPreview.Visible = false;

            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock =
                System.Windows.Forms.DockStyle.Fill;

            this.splitContainer1.Location =
                new System.Drawing.Point(12, 12);

            this.splitContainer1.Name =
                "splitContainer1";

            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(
                this.tvwThuMuc);

            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(
                this.grpFileContent);

            this.splitContainer1.Size =
                new System.Drawing.Size(850, 540);

            this.splitContainer1.SplitterDistance = 250;

            this.splitContainer1.TabIndex = 0;

            // 
            // Bai07
            // 
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(8F, 16F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(874, 564);

            this.Controls.Add(this.splitContainer1);

            this.MinimumSize =
                new System.Drawing.Size(700, 450);

            this.Name = "Bai07";

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Text = "Bài 7";

            this.grpFileContent.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.picPreview)).EndInit();

            this.splitContainer1.Panel1.ResumeLayout(false);

            this.splitContainer1.Panel2.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.splitContainer1)).EndInit();

            this.splitContainer1.ResumeLayout(false);

            this.ResumeLayout(false);
        }
    }
}
