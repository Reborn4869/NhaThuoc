namespace NhaThuoc.App.Forms
{
    partial class frmDangNhap
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
            pnlHeader = new Panel();
            lblTieuDe = new Label();
            pnlNoiDung = new Panel();
            cardDangNhap = new CardPanel();
            lblTen = new Label();
            txtTenDangNhap = new TextBox();
            lblMatKhau = new Label();
            txtMatKhau = new TextBox();
            lblLoi = new Label();
            btnDangNhap = new Button();
            pnlHeader.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            cardDangNhap.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(422, 84);
            pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(24, 24);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(128, 20);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Quản lý nhà thuốc";
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.Controls.Add(cardDangNhap);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(0, 84);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Padding = new Padding(24);
            pnlNoiDung.Size = new Size(422, 309);
            pnlNoiDung.TabIndex = 1;
            // 
            // cardDangNhap
            // 
            cardDangNhap.BackColor = Color.Transparent;
            cardDangNhap.Controls.Add(btnDangNhap);
            cardDangNhap.Controls.Add(lblLoi);
            cardDangNhap.Controls.Add(txtMatKhau);
            cardDangNhap.Controls.Add(lblMatKhau);
            cardDangNhap.Controls.Add(txtTenDangNhap);
            cardDangNhap.Controls.Add(lblTen);
            cardDangNhap.Dock = DockStyle.Fill;
            cardDangNhap.Location = new Point(24, 24);
            cardDangNhap.Name = "cardDangNhap";
            cardDangNhap.Padding = new Padding(14);
            cardDangNhap.Size = new Size(374, 261);
            cardDangNhap.TabIndex = 0;
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(18, 18);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(107, 20);
            lblTen.TabIndex = 0;
            lblTen.Text = "Tên đăng nhập";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTenDangNhap.Location = new Point(18, 42);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(340, 27);
            txtTenDangNhap.TabIndex = 1;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(18, 84);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(70, 20);
            lblMatKhau.TabIndex = 2;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMatKhau.Location = new Point(18, 108);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(340, 27);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // lblLoi
            // 
            lblLoi.Location = new Point(18, 144);
            lblLoi.Name = "lblLoi";
            lblLoi.Size = new Size(340, 24);
            lblLoi.TabIndex = 4;
            lblLoi.Text = "0000";
            // 
            // btnDangNhap
            // 
            btnDangNhap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDangNhap.Location = new Point(18, 172);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(340, 29);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.Tag = "primary";
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            // 
            // frmDangNhap
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(422, 393);
            Controls.Add(pnlNoiDung);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNoiDung.ResumeLayout(false);
            cardDangNhap.ResumeLayout(false);
            cardDangNhap.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTieuDe;
        private Panel pnlNoiDung;
        private CardPanel cardDangNhap;
        private Label lblLoi;
        private TextBox txtMatKhau;
        private Label lblMatKhau;
        private TextBox txtTenDangNhap;
        private Label lblTen;
        private Button btnDangNhap;
    }
}