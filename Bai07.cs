
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace _25521643_TangThiThanhTam_Lab2
{
    public partial class Bai07 : Form
    {
        public Bai07()
        {
            InitializeComponent();

            this.Text = "Bài 07 - Duyệt thư mục";

            tvwThuMuc.BeforeExpand += tvwThuMuc_BeforeExpand;
            tvwThuMuc.NodeMouseDoubleClick +=
                tvwThuMuc_NodeMouseDoubleClick;
            tvwThuMuc.AfterSelect += tvwThuMuc_AfterSelect;

            rtbNoiDung.ReadOnly = true;
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.Visible = false;

            KhoiTaoCayThuMuc();
        }

        // TC7.2: Hiển thị tất cả ổ đĩa
        private void KhoiTaoCayThuMuc()
        {
            tvwThuMuc.Nodes.Clear();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                TreeNode node = new TreeNode(
                    drive.Name.TrimEnd('\\'));

                node.Tag = drive.RootDirectory.FullName;

                // Node giả để hiện dấu +
                node.Nodes.Add(new TreeNode("Đang tải..."));

                tvwThuMuc.Nodes.Add(node);
            }
        }

        // Nạp thư mục con khi bấm dấu +
        private void tvwThuMuc_BeforeExpand(
            object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;

            if (node.Nodes.Count > 0 &&
                node.Nodes[0].Text == "Đang tải...")
            {
                node.Nodes.Clear();
                NapThuMuc(node);
            }
        }

        // Liệt kê thư mục và file thực tế
        private void NapThuMuc(TreeNode node)
        {
            string path = node.Tag as string;

            if (string.IsNullOrEmpty(path))
                return;

            try
            {
                // Liệt kê thư mục con
                string[] folders =
                    Directory.GetDirectories(path);

                Array.Sort(folders,
                    StringComparer.OrdinalIgnoreCase);

                foreach (string folder in folders)
                {
                    DirectoryInfo info =
                        new DirectoryInfo(folder);

                    TreeNode child = new TreeNode(info.Name);
                    child.Tag = folder;

                    // Chỉ thêm dấu + giả cho thư mục
                    child.Nodes.Add(
                        new TreeNode("Đang tải..."));

                    node.Nodes.Add(child);
                }

                // Liệt kê file
                string[] files = Directory.GetFiles(path);

                Array.Sort(files,
                    StringComparer.OrdinalIgnoreCase);

                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);

                    TreeNode child = new TreeNode(info.Name);
                    child.Tag = file;

                    node.Nodes.Add(child);
                }
            }
            catch (UnauthorizedAccessException)
            {
                node.Nodes.Add(
                    new TreeNode("(Không có quyền truy cập)"));
            }
            catch (IOException)
            {
                node.Nodes.Add(
                    new TreeNode("(Không thể đọc thư mục)"));
            }
            catch (Exception ex)
            {
                node.Nodes.Add(
                    new TreeNode("(Lỗi: " + ex.Message + ")"));
            }
        }

        // TC7.2: Nhấp đúp để mở rộng thư mục
        private void tvwThuMuc_NodeMouseDoubleClick(
            object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = e.Node.Tag as string;

            if (!string.IsNullOrEmpty(path) &&
                Directory.Exists(path))
            {
                if (e.Node.IsExpanded)
                    e.Node.Collapse();
                else
                    e.Node.Expand();
            }
        }

        // Khi chọn file
        private void tvwThuMuc_AfterSelect(
            object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag as string;

            if (string.IsNullOrEmpty(path))
            {
                AnNoiDung();
                return;
            }

            if (File.Exists(path))
            {
                HienThiFile(path);
            }
            else
            {
                AnNoiDung();
            }
        }

        private void AnNoiDung()
        {
            rtbNoiDung.Visible = false;
            picPreview.Visible = false;

            Image oldImage = picPreview.Image;
            picPreview.Image = null;

            if (oldImage != null)
                oldImage.Dispose();

            rtbNoiDung.Clear();
        }

        // TC7.3: Xem trước ảnh hoặc đọc file văn bản
        private void HienThiFile(string path)
        {
            AnNoiDung();

            string ext =
                Path.GetExtension(path).ToLowerInvariant();

            string[] imageExtensions =
            {
                ".jpg", ".jpeg", ".png", ".bmp", ".gif"
            };

            if (imageExtensions.Contains(ext))
            {
                try
                {
                    // Không khóa file ảnh sau khi mở
                    using (Image original = Image.FromFile(path))
                    {
                        picPreview.Image = new Bitmap(original);
                    }

                    picPreview.Visible = true;
                }
                catch (Exception ex)
                {
                    rtbNoiDung.Text =
                        "Không thể hiển thị ảnh.\n" + ex.Message;

                    rtbNoiDung.Visible = true;
                }

                return;
            }

            // Đọc file văn bản
            try
            {
                rtbNoiDung.Text =
                    File.ReadAllText(path);

                rtbNoiDung.Visible = true;
            }
            catch (Exception ex)
            {
                rtbNoiDung.Text =
                    "Không thể đọc nội dung file.\n" +
                    ex.Message;

                rtbNoiDung.Visible = true;
            }
        }
    }
}
