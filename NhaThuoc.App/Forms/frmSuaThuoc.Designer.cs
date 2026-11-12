namespace NhaThuoc.App.Forms
{
    partial class frmSuaThuoc
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
            pnlNoiDung = new Panel();
            cardChiTiet = new CardPanel();
            lblBaoQuan = new Label();
            lblChongChiDinh = new Label();
            lblCongDung = new Label();
            lblKe = new Label();
            lblDvt = new Label();
            lblGia = new Label();
            lblDang = new Label();
            lblNhom = new Label();
            lblMaVach = new Label();
            lblTen = new Label();
            btnHuy = new Button();
            btnLuu = new Button();
            btnHoatChatMoi = new Button();
            dgvHoatChat = new DataGridView();
            txtBaoQuan = new TextBox();
            txtChongChiDinh = new TextBox();
            txtCongDung = new TextBox();
            txtKe = new TextBox();
            txtDvt = new TextBox();
            numGia = new NumericUpDown();
            chkKeDon = new CheckBox();
            cboDang = new ComboBox();
            cboNhom = new ComboBox();
            txtMaVach = new TextBox();
            txtTen = new TextBox();
            pnlNoiDung.SuspendLayout();
            cardChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoatChat).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGia).BeginInit();
            SuspendLayout();
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.Controls.Add(cardChiTiet);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(0, 0);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Padding = new Padding(16);
            pnlNoiDung.Size = new Size(882, 593);
            pnlNoiDung.TabIndex = 0;
            // 
            // cardChiTiet
            // 
            cardChiTiet.BackColor = Color.Transparent;
            cardChiTiet.Controls.Add(lblBaoQuan);
            cardChiTiet.Controls.Add(lblChongChiDinh);
            cardChiTiet.Controls.Add(lblCongDung);
            cardChiTiet.Controls.Add(lblKe);
            cardChiTiet.Controls.Add(lblDvt);
            cardChiTiet.Controls.Add(lblGia);
            cardChiTiet.Controls.Add(lblDang);
            cardChiTiet.Controls.Add(lblNhom);
            cardChiTiet.Controls.Add(lblMaVach);
            cardChiTiet.Controls.Add(lblTen);
            cardChiTiet.Controls.Add(btnHuy);
            cardChiTiet.Controls.Add(btnLuu);
            cardChiTiet.Controls.Add(btnHoatChatMoi);
            cardChiTiet.Controls.Add(dgvHoatChat);
            cardChiTiet.Controls.Add(txtBaoQuan);
            cardChiTiet.Controls.Add(txtChongChiDinh);
            cardChiTiet.Controls.Add(txtCongDung);
            cardChiTiet.Controls.Add(txtKe);
            cardChiTiet.Controls.Add(txtDvt);
            cardChiTiet.Controls.Add(numGia);
            cardChiTiet.Controls.Add(chkKeDon);
            cardChiTiet.Controls.Add(cboDang);
            cardChiTiet.Controls.Add(cboNhom);
            cardChiTiet.Controls.Add(txtMaVach);
            cardChiTiet.Controls.Add(txtTen);
            cardChiTiet.Dock = DockStyle.Fill;
            cardChiTiet.Location = new Point(16, 16);
            cardChiTiet.Name = "cardChiTiet";
            cardChiTiet.Padding = new Padding(14);
            cardChiTiet.Size = new Size(850, 561);
            cardChiTiet.TabIndex = 0;
            // 
            // lblBaoQuan
            // 
            lblBaoQuan.AutoSize = true;
            lblBaoQuan.Location = new Point(544, 76);
            lblBaoQuan.Name = "lblBaoQuan";
            lblBaoQuan.Size = new Size(72, 20);
            lblBaoQuan.TabIndex = 24;
            lblBaoQuan.Text = "Bảo quản";
            // 
            // lblChongChiDinh
            // 
            lblChongChiDinh.AutoSize = true;
            lblChongChiDinh.Location = new Point(416, 76);
            lblChongChiDinh.Name = "lblChongChiDinh";
            lblChongChiDinh.Size = new Size(108, 20);
            lblChongChiDinh.TabIndex = 23;
            lblChongChiDinh.Text = "Chống chỉ định";
            // 
            // lblCongDung
            // 
            lblCongDung.AutoSize = true;
            lblCongDung.Location = new Point(279, 79);
            lblCongDung.Name = "lblCongDung";
            lblCongDung.Size = new Size(82, 20);
            lblCongDung.TabIndex = 22;
            lblCongDung.Text = "Công dụng";
            // 
            // lblKe
            // 
            lblKe.AutoSize = true;
            lblKe.Location = new Point(148, 79);
            lblKe.Name = "lblKe";
            lblKe.Size = new Size(59, 20);
            lblKe.TabIndex = 21;
            lblKe.Text = "Vị trí kệ";
            // 
            // lblDvt
            // 
            lblDvt.AutoSize = true;
            lblDvt.Location = new Point(17, 79);
            lblDvt.Name = "lblDvt";
            lblDvt.Size = new Size(37, 20);
            lblDvt.TabIndex = 20;
            lblDvt.Text = "ĐVT";
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Location = new Point(593, 13);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(60, 20);
            lblGia.TabIndex = 19;
            lblGia.Text = "Giá bán";
            // 
            // lblDang
            // 
            lblDang.AutoSize = true;
            lblDang.Location = new Point(436, 14);
            lblDang.Name = "lblDang";
            lblDang.Size = new Size(102, 20);
            lblDang.TabIndex = 18;
            lblDang.Text = "Dạng bào chế";
            // 
            // lblNhom
            // 
            lblNhom.AutoSize = true;
            lblNhom.Location = new Point(279, 14);
            lblNhom.Name = "lblNhom";
            lblNhom.Size = new Size(91, 20);
            lblNhom.TabIndex = 17;
            lblNhom.Text = "Nhóm thuốc";
            // 
            // lblMaVach
            // 
            lblMaVach.AutoSize = true;
            lblMaVach.Location = new Point(148, 14);
            lblMaVach.Name = "lblMaVach";
            lblMaVach.Size = new Size(64, 20);
            lblMaVach.TabIndex = 16;
            lblMaVach.Text = "Mã vạch";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(17, 14);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(73, 20);
            lblTen.TabIndex = 15;
            lblTen.Text = "Tên thuốc";
            // 
            // btnHuy
            // 
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.Location = new Point(267, 409);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(94, 29);
            btnHuy.TabIndex = 14;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(167, 408);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(94, 29);
            btnLuu.TabIndex = 13;
            btnLuu.Tag = "primary";
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnHoatChatMoi
            // 
            btnHoatChatMoi.AutoSize = true;
            btnHoatChatMoi.Location = new Point(17, 408);
            btnHoatChatMoi.Name = "btnHoatChatMoi";
            btnHoatChatMoi.Size = new Size(120, 30);
            btnHoatChatMoi.TabIndex = 12;
            btnHoatChatMoi.Text = "Hoạt chất mới..";
            btnHoatChatMoi.UseVisualStyleBackColor = true;
            // 
            // dgvHoatChat
            // 
            dgvHoatChat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoatChat.Location = new Point(17, 152);
            dgvHoatChat.Name = "dgvHoatChat";
            dgvHoatChat.RowHeadersWidth = 51;
            dgvHoatChat.Size = new Size(400, 240);
            dgvHoatChat.TabIndex = 11;
            // 
            // txtBaoQuan
            // 
            txtBaoQuan.Location = new Point(544, 102);
            txtBaoQuan.Multiline = true;
            txtBaoQuan.Name = "txtBaoQuan";
            txtBaoQuan.Size = new Size(125, 34);
            txtBaoQuan.TabIndex = 10;
            // 
            // txtChongChiDinh
            // 
            txtChongChiDinh.Location = new Point(413, 102);
            txtChongChiDinh.Multiline = true;
            txtChongChiDinh.Name = "txtChongChiDinh";
            txtChongChiDinh.Size = new Size(125, 34);
            txtChongChiDinh.TabIndex = 9;
            // 
            // txtCongDung
            // 
            txtCongDung.Location = new Point(279, 102);
            txtCongDung.Multiline = true;
            txtCongDung.Name = "txtCongDung";
            txtCongDung.Size = new Size(125, 34);
            txtCongDung.TabIndex = 8;
            // 
            // txtKe
            // 
            txtKe.Location = new Point(148, 102);
            txtKe.Name = "txtKe";
            txtKe.Size = new Size(125, 27);
            txtKe.TabIndex = 7;
            // 
            // txtDvt
            // 
            txtDvt.Location = new Point(17, 102);
            txtDvt.Name = "txtDvt";
            txtDvt.Size = new Size(125, 27);
            txtDvt.TabIndex = 6;
            // 
            // numGia
            // 
            numGia.Location = new Point(593, 36);
            numGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numGia.Name = "numGia";
            numGia.Size = new Size(150, 27);
            numGia.TabIndex = 5;
            numGia.ThousandsSeparator = true;
            // 
            // chkKeDon
            // 
            chkKeDon.AutoSize = true;
            chkKeDon.Location = new Point(675, 102);
            chkKeDon.Name = "chkKeDon";
            chkKeDon.Size = new Size(120, 24);
            chkKeDon.TabIndex = 4;
            chkKeDon.Text = "Thuốc kê đơn";
            chkKeDon.UseVisualStyleBackColor = true;
            // 
            // cboDang
            // 
            cboDang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDang.FormattingEnabled = true;
            cboDang.Location = new Point(436, 36);
            cboDang.Name = "cboDang";
            cboDang.Size = new Size(151, 28);
            cboDang.TabIndex = 3;
            // 
            // cboNhom
            // 
            cboNhom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhom.FormattingEnabled = true;
            cboNhom.Location = new Point(279, 37);
            cboNhom.Name = "cboNhom";
            cboNhom.Size = new Size(151, 28);
            cboNhom.TabIndex = 2;
            // 
            // txtMaVach
            // 
            txtMaVach.Location = new Point(148, 37);
            txtMaVach.Name = "txtMaVach";
            txtMaVach.Size = new Size(125, 27);
            txtMaVach.TabIndex = 1;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(17, 37);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(125, 27);
            txtTen.TabIndex = 0;
            // 
            // frmSuaThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 593);
            Controls.Add(pnlNoiDung);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            Name = "frmSuaThuoc";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông tin thuốc";
            pnlNoiDung.ResumeLayout(false);
            cardChiTiet.ResumeLayout(false);
            cardChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoatChat).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGia).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlNoiDung;
        private CardPanel cardChiTiet;
        private TextBox txtTen;
        private TextBox txtMaVach;
        private TextBox txtDvt;
        private NumericUpDown numGia;
        private CheckBox chkKeDon;
        private ComboBox cboDang;
        private ComboBox cboNhom;
        private TextBox txtKe;
        private TextBox txtChongChiDinh;
        private TextBox txtCongDung;
        private Button btnHuy;
        private Button btnLuu;
        private Button btnHoatChatMoi;
        private DataGridView dgvHoatChat;
        private TextBox txtBaoQuan;
        private Label lblKe;
        private Label lblDvt;
        private Label lblGia;
        private Label lblDang;
        private Label lblNhom;
        private Label lblMaVach;
        private Label lblTen;
        private Label lblBaoQuan;
        private Label lblChongChiDinh;
        private Label lblCongDung;
    }
}