namespace NhaThuoc.App.Forms
{
    partial class frmMain
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
            menu = new MenuStrip();
            mnuTimThuoc = new ToolStripMenuItem();
            mnuDanhMuc = new ToolStripMenuItem();
            mnuNhapKho = new ToolStripMenuItem();
            mnuBanHang = new ToolStripMenuItem();
            mnuBaoCao = new ToolStripMenuItem();
            mnuDangXuat = new ToolStripMenuItem();
            statusBar = new StatusStrip();
            lblNguoiDung = new ToolStripStatusLabel();
            menu.SuspendLayout();
            statusBar.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { mnuTimThuoc, mnuDanhMuc, mnuNhapKho, mnuBanHang, mnuBaoCao, mnuDangXuat });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(800, 28);
            menu.TabIndex = 1;
            menu.Text = "menuStrip1";
            // 
            // mnuTimThuoc
            // 
            mnuTimThuoc.Name = "mnuTimThuoc";
            mnuTimThuoc.Size = new Size(89, 24);
            mnuTimThuoc.Text = "Tìm thuốc";
            // 
            // mnuDanhMuc
            // 
            mnuDanhMuc.Name = "mnuDanhMuc";
            mnuDanhMuc.Size = new Size(131, 24);
            mnuDanhMuc.Text = "Danh mục thuốc";
            // 
            // mnuNhapKho
            // 
            mnuNhapKho.Name = "mnuNhapKho";
            mnuNhapKho.Size = new Size(87, 24);
            mnuNhapKho.Text = "Nhập kho";
            // 
            // mnuBanHang
            // 
            mnuBanHang.Name = "mnuBanHang";
            mnuBanHang.Size = new Size(85, 24);
            mnuBanHang.Text = "Bán hàng";
            // 
            // mnuBaoCao
            // 
            mnuBaoCao.Name = "mnuBaoCao";
            mnuBaoCao.Size = new Size(77, 24);
            mnuBaoCao.Text = "Báo cáo";
            // 
            // mnuDangXuat
            // 
            mnuDangXuat.Name = "mnuDangXuat";
            mnuDangXuat.Size = new Size(91, 24);
            mnuDangXuat.Text = "Đăng xuất";
            // 
            // statusBar
            // 
            statusBar.ImageScalingSize = new Size(20, 20);
            statusBar.Items.AddRange(new ToolStripItem[] { lblNguoiDung });
            statusBar.Location = new Point(0, 424);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(800, 26);
            statusBar.TabIndex = 2;
            statusBar.Text = "statusStrip1";
            // 
            // lblNguoiDung
            // 
            lblNguoiDung.Name = "lblNguoiDung";
            lblNguoiDung.Size = new Size(69, 20);
            lblNguoiDung.Text = "updating";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusBar);
            Controls.Add(menu);
            IsMdiContainer = true;
            MainMenuStrip = menu;
            Name = "frmMain";
            Text = "Quản lý nhà thuốc";
            WindowState = FormWindowState.Maximized;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            statusBar.ResumeLayout(false);
            statusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem mnuTimThuoc;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuNhapKho;
        private ToolStripMenuItem mnuBanHang;
        private ToolStripMenuItem mnuBaoCao;
        private ToolStripMenuItem mnuDangXuat;
        private StatusStrip statusBar;
        private ToolStripStatusLabel lblNguoiDung;
    }
}