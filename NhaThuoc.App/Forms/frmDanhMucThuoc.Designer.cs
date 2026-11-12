namespace NhaThuoc.App.Forms
{
    partial class frmDanhMucThuoc
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
            cardLuoi = new CardPanel();
            dgvThuoc = new DataGridView();
            cardCongCu = new CardPanel();
            btnNhapCsv = new Button();
            btnAn = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtTim = new TextBox();
            timerTim = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            cardLuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThuoc).BeginInit();
            cardCongCu.SuspendLayout();
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
            lblTieuDe.Size = new Size(117, 20);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Danh mục thuốc";
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
            pnlNoiDung.Controls.Add(cardCongCu);
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
            cardLuoi.Controls.Add(dgvThuoc);
            cardLuoi.Dock = DockStyle.Fill;
            cardLuoi.Location = new Point(16, 80);
            cardLuoi.Name = "cardLuoi";
            cardLuoi.Padding = new Padding(1);
            cardLuoi.Size = new Size(1130, 473);
            cardLuoi.TabIndex = 1;
            // 
            // dgvThuoc
            // 
            dgvThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThuoc.Dock = DockStyle.Fill;
            dgvThuoc.Location = new Point(1, 1);
            dgvThuoc.Name = "dgvThuoc";
            dgvThuoc.RowHeadersWidth = 51;
            dgvThuoc.Size = new Size(1128, 471);
            dgvThuoc.TabIndex = 0;
            // 
            // cardCongCu
            // 
            cardCongCu.BackColor = Color.Transparent;
            cardCongCu.Controls.Add(btnNhapCsv);
            cardCongCu.Controls.Add(btnAn);
            cardCongCu.Controls.Add(btnSua);
            cardCongCu.Controls.Add(btnThem);
            cardCongCu.Controls.Add(txtTim);
            cardCongCu.Dock = DockStyle.Top;
            cardCongCu.Location = new Point(16, 16);
            cardCongCu.Name = "cardCongCu";
            cardCongCu.Padding = new Padding(14);
            cardCongCu.Size = new Size(1130, 64);
            cardCongCu.TabIndex = 0;
            // 
            // btnNhapCsv
            // 
            btnNhapCsv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNhapCsv.Location = new Point(715, 12);
            btnNhapCsv.Name = "btnNhapCsv";
            btnNhapCsv.Size = new Size(94, 29);
            btnNhapCsv.TabIndex = 4;
            btnNhapCsv.Text = "Nhập CSV";
            btnNhapCsv.UseVisualStyleBackColor = true;
            // 
            // btnAn
            // 
            btnAn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAn.Location = new Point(615, 12);
            btnAn.Name = "btnAn";
            btnAn.Size = new Size(94, 29);
            btnAn.TabIndex = 3;
            btnAn.Text = "Ẩn thuốc";
            btnAn.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.Location = new Point(515, 12);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 2;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Location = new Point(415, 12);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 1;
            btnThem.Tag = "primary";
            btnThem.Text = "Thêm thuốc";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // txtTim
            // 
            txtTim.Location = new Point(14, 14);
            txtTim.Name = "txtTim";
            txtTim.Size = new Size(380, 27);
            txtTim.TabIndex = 0;
            // 
            // timerTim
            // 
            timerTim.Interval = 250;
            // 
            // frmDanhMucThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 653);
            Controls.Add(pnlNoiDung);
            Controls.Add(lblTrangThai);
            Controls.Add(pnlHeader);
            KeyPreview = true;
            Name = "frmDanhMucThuoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh mục thuốc";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNoiDung.ResumeLayout(false);
            cardLuoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvThuoc).EndInit();
            cardCongCu.ResumeLayout(false);
            cardCongCu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblTrangThai;
        private Panel pnlNoiDung;
        private CardPanel cardCongCu;
        private Button btnThem;
        private TextBox txtTim;
        private CardPanel cardLuoi;
        private DataGridView dgvThuoc;
        private Button btnNhapCsv;
        private Button btnAn;
        private Button btnSua;
        private System.Windows.Forms.Timer timerTim;
    }
}