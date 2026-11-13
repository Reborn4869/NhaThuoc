namespace NhaThuoc.App.Forms
{
    partial class frmBaoCao
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
            lblTrangThai = new Label();
            pnlNoiDung = new Panel();
            cardLuoi = new CardPanel();
            dgvBaoCao = new DataGridView();
            pnlKhoang = new Panel();
            cardLoc = new CardPanel();
            btnXuat = new Button();
            btnXem = new Button();
            numThamSo = new NumericUpDown();
            dtpDen = new DateTimePicker();
            dtpTu = new DateTimePicker();
            cboLoai = new ComboBox();
            lblThamSo = new Label();
            lblDen = new Label();
            lblTu = new Label();
            lblLoai = new Label();
            pnlHeader.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            cardLuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            cardLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numThamSo).BeginInit();
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
            lblTieuDe.Size = new Size(63, 20);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Báo cáo";
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
            pnlNoiDung.Controls.Add(cardLuoi);
            pnlNoiDung.Controls.Add(pnlKhoang);
            pnlNoiDung.Controls.Add(cardLoc);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(0, 64);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Padding = new Padding(16);
            pnlNoiDung.Size = new Size(1162, 569);
            pnlNoiDung.TabIndex = 2;
            // 
            // cardLuoi
            // 
            cardLuoi.BackColor = Color.Transparent;
            cardLuoi.Controls.Add(dgvBaoCao);
            cardLuoi.Dock = DockStyle.Fill;
            cardLuoi.Location = new Point(16, 112);
            cardLuoi.Name = "cardLuoi";
            cardLuoi.Padding = new Padding(1);
            cardLuoi.Size = new Size(1130, 441);
            cardLuoi.TabIndex = 2;
            // 
            // dgvBaoCao
            // 
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Dock = DockStyle.Fill;
            dgvBaoCao.Location = new Point(1, 1);
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.RowHeadersWidth = 51;
            dgvBaoCao.Size = new Size(1128, 439);
            dgvBaoCao.TabIndex = 0;
            // 
            // pnlKhoang
            // 
            pnlKhoang.Dock = DockStyle.Top;
            pnlKhoang.Location = new Point(16, 100);
            pnlKhoang.Name = "pnlKhoang";
            pnlKhoang.Size = new Size(1130, 12);
            pnlKhoang.TabIndex = 1;
            // 
            // cardLoc
            // 
            cardLoc.BackColor = Color.Transparent;
            cardLoc.Controls.Add(btnXuat);
            cardLoc.Controls.Add(btnXem);
            cardLoc.Controls.Add(numThamSo);
            cardLoc.Controls.Add(dtpDen);
            cardLoc.Controls.Add(dtpTu);
            cardLoc.Controls.Add(cboLoai);
            cardLoc.Controls.Add(lblThamSo);
            cardLoc.Controls.Add(lblDen);
            cardLoc.Controls.Add(lblTu);
            cardLoc.Controls.Add(lblLoai);
            cardLoc.Dock = DockStyle.Top;
            cardLoc.Location = new Point(16, 16);
            cardLoc.Name = "cardLoc";
            cardLoc.Padding = new Padding(14);
            cardLoc.Size = new Size(1130, 84);
            cardLoc.TabIndex = 0;
            // 
            // btnXuat
            // 
            btnXuat.AutoSize = true;
            btnXuat.Location = new Point(810, 28);
            btnXuat.Name = "btnXuat";
            btnXuat.Size = new Size(94, 30);
            btnXuat.TabIndex = 9;
            btnXuat.Text = "Xuất Excel";
            btnXuat.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            btnXem.AutoSize = true;
            btnXem.Location = new Point(690, 28);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(107, 30);
            btnXem.TabIndex = 8;
            btnXem.Tag = "primary";
            btnXem.Text = "Xem báo cáo";
            btnXem.UseVisualStyleBackColor = true;
            // 
            // numThamSo
            // 
            numThamSo.Location = new Point(526, 32);
            numThamSo.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numThamSo.Name = "numThamSo";
            numThamSo.Size = new Size(140, 27);
            numThamSo.TabIndex = 7;
            // 
            // dtpDen
            // 
            dtpDen.Format = DateTimePickerFormat.Short;
            dtpDen.Location = new Point(390, 32);
            dtpDen.Name = "dtpDen";
            dtpDen.Size = new Size(120, 27);
            dtpDen.TabIndex = 6;
            // 
            // dtpTu
            // 
            dtpTu.Format = DateTimePickerFormat.Short;
            dtpTu.Location = new Point(254, 32);
            dtpTu.Name = "dtpTu";
            dtpTu.Size = new Size(120, 27);
            dtpTu.TabIndex = 5;
            // 
            // cboLoai
            // 
            cboLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoai.FormattingEnabled = true;
            cboLoai.Location = new Point(14, 32);
            cboLoai.Name = "cboLoai";
            cboLoai.Size = new Size(220, 28);
            cboLoai.TabIndex = 4;
            // 
            // lblThamSo
            // 
            lblThamSo.AutoSize = true;
            lblThamSo.Location = new Point(526, 8);
            lblThamSo.Name = "lblThamSo";
            lblThamSo.Size = new Size(94, 20);
            lblThamSo.TabIndex = 3;
            lblThamSo.Text = "Tham số phụ";
            // 
            // lblDen
            // 
            lblDen.AutoSize = true;
            lblDen.Location = new Point(390, 8);
            lblDen.Name = "lblDen";
            lblDen.Size = new Size(72, 20);
            lblDen.TabIndex = 2;
            lblDen.Text = "Đến ngày";
            // 
            // lblTu
            // 
            lblTu.AutoSize = true;
            lblTu.Location = new Point(254, 8);
            lblTu.Name = "lblTu";
            lblTu.Size = new Size(62, 20);
            lblTu.TabIndex = 1;
            lblTu.Text = "Từ ngày";
            // 
            // lblLoai
            // 
            lblLoai.AutoSize = true;
            lblLoai.Location = new Point(14, 8);
            lblLoai.Name = "lblLoai";
            lblLoai.Size = new Size(95, 20);
            lblLoai.TabIndex = 0;
            lblLoai.Text = "Loại báo cáo";
            // 
            // frmBaoCao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 653);
            Controls.Add(pnlNoiDung);
            Controls.Add(lblTrangThai);
            Controls.Add(pnlHeader);
            KeyPreview = true;
            Name = "frmBaoCao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNoiDung.ResumeLayout(false);
            cardLuoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            cardLoc.ResumeLayout(false);
            cardLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numThamSo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTrangThai;
        private Panel pnlNoiDung;
        private CardPanel cardLuoi;
        private DataGridView dgvBaoCao;
        private Panel pnlKhoang;
        private CardPanel cardLoc;
        private DateTimePicker dtpTu;
        private ComboBox cboLoai;
        private Label lblThamSo;
        private Label lblDen;
        private Label lblTu;
        private Label lblLoai;
        private Button btnXuat;
        private Button btnXem;
        private NumericUpDown numThamSo;
        private DateTimePicker dtpDen;
        private Label lblTieuDe;
    }
}