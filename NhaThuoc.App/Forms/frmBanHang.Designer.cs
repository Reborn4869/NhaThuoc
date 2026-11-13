namespace NhaThuoc.App.Forms
{
    partial class frmBanHang
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
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            lblTieuDe = new Label();
            lblTrangThai = new Label();
            pnlNoiDung = new Panel();
            cardGio = new CardPanel();
            dgvGio = new DataGridView();
            pnlThanhToan = new Panel();
            btnHuyHoaDon = new Button();
            btnXoaDong = new Button();
            btnThanhToan = new Button();
            lblTong = new Label();
            txtThongTinDon = new TextBox();
            numGiamGia = new NumericUpDown();
            lblGiamGia = new Label();
            pnlK = new Panel();
            cardTim = new CardPanel();
            dgvGoiY = new DataGridView();
            txtTim = new TextBox();
            timerTim = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            cardGio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGio).BeginInit();
            pnlThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numGiamGia).BeginInit();
            cardTim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGoiY).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1162, 64);
            pnlHeader.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(16, 14);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(71, 20);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Bán hàng";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Dock = DockStyle.Bottom;
            lblTrangThai.Location = new Point(0, 633);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(50, 20);
            lblTrangThai.TabIndex = 1;
            lblTrangThai.Text = "label1";
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.Controls.Add(cardGio);
            pnlNoiDung.Controls.Add(pnlK);
            pnlNoiDung.Controls.Add(cardTim);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(0, 64);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Padding = new Padding(16);
            pnlNoiDung.Size = new Size(1162, 569);
            pnlNoiDung.TabIndex = 2;
            // 
            // cardGio
            // 
            cardGio.BackColor = Color.Transparent;
            cardGio.Controls.Add(dgvGio);
            cardGio.Controls.Add(pnlThanhToan);
            cardGio.Dock = DockStyle.Fill;
            cardGio.Location = new Point(588, 16);
            cardGio.Name = "cardGio";
            cardGio.Padding = new Padding(14);
            cardGio.Size = new Size(558, 537);
            cardGio.TabIndex = 2;
            // 
            // dgvGio
            // 
            dgvGio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGio.Dock = DockStyle.Fill;
            dgvGio.Location = new Point(14, 14);
            dgvGio.Name = "dgvGio";
            dgvGio.RowHeadersWidth = 51;
            dgvGio.Size = new Size(530, 299);
            dgvGio.TabIndex = 1;
            // 
            // pnlThanhToan
            // 
            pnlThanhToan.Controls.Add(btnHuyHoaDon);
            pnlThanhToan.Controls.Add(btnXoaDong);
            pnlThanhToan.Controls.Add(btnThanhToan);
            pnlThanhToan.Controls.Add(lblTong);
            pnlThanhToan.Controls.Add(txtThongTinDon);
            pnlThanhToan.Controls.Add(numGiamGia);
            pnlThanhToan.Controls.Add(lblGiamGia);
            pnlThanhToan.Dock = DockStyle.Bottom;
            pnlThanhToan.Location = new Point(14, 313);
            pnlThanhToan.Name = "pnlThanhToan";
            pnlThanhToan.Size = new Size(530, 210);
            pnlThanhToan.TabIndex = 0;
            // 
            // btnHuyHoaDon
            // 
            btnHuyHoaDon.Location = new Point(358, 150);
            btnHuyHoaDon.Name = "btnHuyHoaDon";
            btnHuyHoaDon.Size = new Size(140, 29);
            btnHuyHoaDon.TabIndex = 6;
            btnHuyHoaDon.Text = "Hủy hóa đơn...";
            btnHuyHoaDon.UseVisualStyleBackColor = true;
            // 
            // btnXoaDong
            // 
            btnXoaDong.Location = new Point(214, 150);
            btnXoaDong.Name = "btnXoaDong";
            btnXoaDong.Size = new Size(130, 29);
            btnXoaDong.TabIndex = 5;
            btnXoaDong.Text = "Xóa dòng (Del)";
            btnXoaDong.UseVisualStyleBackColor = true;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(0, 150);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(200, 44);
            btnThanhToan.TabIndex = 4;
            btnThanhToan.Text = "Thanh toán (F9)";
            btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // lblTong
            // 
            lblTong.AutoSize = true;
            lblTong.Location = new Point(0, 108);
            lblTong.Name = "lblTong";
            lblTong.Size = new Size(106, 20);
            lblTong.TabIndex = 3;
            lblTong.Text = "Thành tiền: 0 đ";
            // 
            // txtThongTinDon
            // 
            txtThongTinDon.Location = new Point(0, 44);
            txtThongTinDon.Multiline = true;
            txtThongTinDon.Name = "txtThongTinDon";
            txtThongTinDon.Size = new Size(400, 56);
            txtThongTinDon.TabIndex = 2;
            txtThongTinDon.Visible = false;
            // 
            // numGiamGia
            // 
            numGiamGia.Location = new Point(130, 8);
            numGiamGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numGiamGia.Name = "numGiamGia";
            numGiamGia.Size = new Size(140, 27);
            numGiamGia.TabIndex = 1;
            numGiamGia.ThousandsSeparator = true;
            // 
            // lblGiamGia
            // 
            lblGiamGia.AutoSize = true;
            lblGiamGia.Location = new Point(0, 12);
            lblGiamGia.Name = "lblGiamGia";
            lblGiamGia.Size = new Size(118, 20);
            lblGiamGia.TabIndex = 0;
            lblGiamGia.Text = "Giảm giá (đồng)";
            // 
            // pnlK
            // 
            pnlK.Dock = DockStyle.Left;
            pnlK.Location = new Point(576, 16);
            pnlK.Name = "pnlK";
            pnlK.Size = new Size(12, 537);
            pnlK.TabIndex = 1;
            // 
            // cardTim
            // 
            cardTim.BackColor = Color.Transparent;
            cardTim.Controls.Add(dgvGoiY);
            cardTim.Controls.Add(txtTim);
            cardTim.Dock = DockStyle.Left;
            cardTim.Location = new Point(16, 16);
            cardTim.Name = "cardTim";
            cardTim.Padding = new Padding(14);
            cardTim.Size = new Size(560, 537);
            cardTim.TabIndex = 0;
            // 
            // dgvGoiY
            // 
            dgvGoiY.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGoiY.Dock = DockStyle.Fill;
            dgvGoiY.Location = new Point(14, 41);
            dgvGoiY.Name = "dgvGoiY";
            dgvGoiY.RowHeadersWidth = 51;
            dgvGoiY.Size = new Size(532, 482);
            dgvGoiY.TabIndex = 1;
            // 
            // txtTim
            // 
            txtTim.Dock = DockStyle.Top;
            txtTim.Location = new Point(14, 14);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(532, 27);
            txtTim.TabIndex = 0;
            // 
            // timerTim
            // 
            timerTim.Interval = 250;
            // 
            // frmBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 653);
            Controls.Add(pnlNoiDung);
            Controls.Add(lblTrangThai);
            Controls.Add(pnlHeader);
            KeyPreview = true;
            Name = "frmBanHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bán hàng";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNoiDung.ResumeLayout(false);
            cardGio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGio).EndInit();
            pnlThanhToan.ResumeLayout(false);
            pnlThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numGiamGia).EndInit();
            cardTim.ResumeLayout(false);
            cardTim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGoiY).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblTrangThai;
        private Panel pnlNoiDung;
        private CardPanel cardGio;
        private Panel pnlThanhToan;
        private Panel pnlK;
        private CardPanel cardTim;
        private DataGridView dgvGoiY;
        private TextBox txtTim;
        private System.Windows.Forms.Timer timerTim;
        private Button btnThanhToan;
        private Label lblTong;
        private TextBox txtThongTinDon;
        private NumericUpDown numGiamGia;
        private Label lblGiamGia;
        private Button btnHuyHoaDon;
        private Button btnXoaDong;
        private DataGridView dgvGio;
    }
}