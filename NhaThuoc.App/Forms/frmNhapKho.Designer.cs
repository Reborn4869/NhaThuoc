namespace NhaThuoc.App.Forms
{
    partial class frmNhapKho
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
            dgvDong = new DataGridView();
            pnlDay = new Panel();
            btnXoaDong = new Button();
            btnLuuPhieu = new Button();
            pnlK2 = new Panel();
            cardThemDong = new CardPanel();
            lblHan = new Label();
            lblGia = new Label();
            lblSL = new Label();
            btnThemDong = new Button();
            numGia = new NumericUpDown();
            numSL = new NumericUpDown();
            dtpHan = new DateTimePicker();
            dtpNSX = new DateTimePicker();
            txtSoLo = new TextBox();
            lblThuocChon = new Label();
            lstGoiY = new ListBox();
            txtTimThuoc = new TextBox();
            pnlK1 = new Panel();
            cardPhieu = new CardPanel();
            txtGhiChu = new TextBox();
            cboNCC = new ComboBox();
            timerTim = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            cardLuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDong).BeginInit();
            pnlDay.SuspendLayout();
            cardThemDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numGia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSL).BeginInit();
            cardPhieu.SuspendLayout();
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
            lblTieuDe.Size = new Size(73, 20);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Nhập kho";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Dock = DockStyle.Bottom;
            lblTrangThai.Location = new Point(0, 683);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(50, 20);
            lblTrangThai.TabIndex = 1;
            lblTrangThai.Text = "label1";
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.Controls.Add(cardLuoi);
            pnlNoiDung.Controls.Add(pnlDay);
            pnlNoiDung.Controls.Add(pnlK2);
            pnlNoiDung.Controls.Add(cardThemDong);
            pnlNoiDung.Controls.Add(pnlK1);
            pnlNoiDung.Controls.Add(cardPhieu);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(0, 64);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Padding = new Padding(16);
            pnlNoiDung.Size = new Size(1162, 619);
            pnlNoiDung.TabIndex = 2;
            // 
            // cardLuoi
            // 
            cardLuoi.BackColor = Color.Transparent;
            cardLuoi.Controls.Add(dgvDong);
            cardLuoi.Dock = DockStyle.Fill;
            cardLuoi.Location = new Point(16, 294);
            cardLuoi.Name = "cardLuoi";
            cardLuoi.Padding = new Padding(1);
            cardLuoi.Size = new Size(1130, 257);
            cardLuoi.TabIndex = 5;
            // 
            // dgvDong
            // 
            dgvDong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDong.Dock = DockStyle.Fill;
            dgvDong.Location = new Point(1, 1);
            dgvDong.Name = "dgvDong";
            dgvDong.RowHeadersWidth = 51;
            dgvDong.Size = new Size(1128, 255);
            dgvDong.TabIndex = 0;
            // 
            // pnlDay
            // 
            pnlDay.Controls.Add(btnXoaDong);
            pnlDay.Controls.Add(btnLuuPhieu);
            pnlDay.Dock = DockStyle.Bottom;
            pnlDay.Location = new Point(16, 551);
            pnlDay.Name = "pnlDay";
            pnlDay.Size = new Size(1130, 52);
            pnlDay.TabIndex = 4;
            // 
            // btnXoaDong
            // 
            btnXoaDong.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoaDong.Location = new Point(190, 20);
            btnXoaDong.Name = "btnXoaDong";
            btnXoaDong.Size = new Size(170, 29);
            btnXoaDong.TabIndex = 1;
            btnXoaDong.Text = "Xóa dòng đang chọn";
            btnXoaDong.UseVisualStyleBackColor = true;
            // 
            // btnLuuPhieu
            // 
            btnLuuPhieu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLuuPhieu.Location = new Point(24, 20);
            btnLuuPhieu.Name = "btnLuuPhieu";
            btnLuuPhieu.Size = new Size(160, 29);
            btnLuuPhieu.TabIndex = 0;
            btnLuuPhieu.Tag = "primary";
            btnLuuPhieu.Text = "Lưu phiếu nhập";
            btnLuuPhieu.UseVisualStyleBackColor = true;
            // 
            // pnlK2
            // 
            pnlK2.Dock = DockStyle.Top;
            pnlK2.Location = new Point(16, 282);
            pnlK2.Name = "pnlK2";
            pnlK2.Size = new Size(1130, 12);
            pnlK2.TabIndex = 3;
            // 
            // cardThemDong
            // 
            cardThemDong.BackColor = Color.Transparent;
            cardThemDong.Controls.Add(lblHan);
            cardThemDong.Controls.Add(lblGia);
            cardThemDong.Controls.Add(lblSL);
            cardThemDong.Controls.Add(btnThemDong);
            cardThemDong.Controls.Add(numGia);
            cardThemDong.Controls.Add(numSL);
            cardThemDong.Controls.Add(dtpHan);
            cardThemDong.Controls.Add(dtpNSX);
            cardThemDong.Controls.Add(txtSoLo);
            cardThemDong.Controls.Add(lblThuocChon);
            cardThemDong.Controls.Add(lstGoiY);
            cardThemDong.Controls.Add(txtTimThuoc);
            cardThemDong.Dock = DockStyle.Top;
            cardThemDong.Location = new Point(16, 92);
            cardThemDong.Name = "cardThemDong";
            cardThemDong.Padding = new Padding(14);
            cardThemDong.Size = new Size(1130, 190);
            cardThemDong.TabIndex = 2;
            // 
            // lblHan
            // 
            lblHan.AutoSize = true;
            lblHan.Location = new Point(520, 59);
            lblHan.Name = "lblHan";
            lblHan.Size = new Size(39, 20);
            lblHan.TabIndex = 11;
            lblHan.Text = "HSD";
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Location = new Point(520, 118);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(60, 20);
            lblGia.TabIndex = 10;
            lblGia.Text = "Giá bán";
            // 
            // lblSL
            // 
            lblSL.AutoSize = true;
            lblSL.Location = new Point(350, 118);
            lblSL.Name = "lblSL";
            lblSL.Size = new Size(69, 20);
            lblSL.TabIndex = 9;
            lblSL.Text = "Số lượng";
            // 
            // btnThemDong
            // 
            btnThemDong.Location = new Point(690, 114);
            btnThemDong.Name = "btnThemDong";
            btnThemDong.Size = new Size(94, 29);
            btnThemDong.TabIndex = 8;
            btnThemDong.Tag = "primary";
            btnThemDong.Text = "Thêm dòng";
            btnThemDong.UseVisualStyleBackColor = true;
            // 
            // numGia
            // 
            numGia.Location = new Point(520, 143);
            numGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numGia.Name = "numGia";
            numGia.Size = new Size(150, 27);
            numGia.TabIndex = 7;
            numGia.ThousandsSeparator = true;
            // 
            // numSL
            // 
            numSL.Location = new Point(350, 143);
            numSL.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numSL.Name = "numSL";
            numSL.Size = new Size(150, 27);
            numSL.TabIndex = 6;
            numSL.ThousandsSeparator = true;
            // 
            // dtpHan
            // 
            dtpHan.Format = DateTimePickerFormat.Short;
            dtpHan.Location = new Point(520, 82);
            dtpHan.Name = "dtpHan";
            dtpHan.Size = new Size(150, 27);
            dtpHan.TabIndex = 5;
            // 
            // dtpNSX
            // 
            dtpNSX.Format = DateTimePickerFormat.Short;
            dtpNSX.Location = new Point(350, 82);
            dtpNSX.Name = "dtpNSX";
            dtpNSX.ShowCheckBox = true;
            dtpNSX.Size = new Size(150, 27);
            dtpNSX.TabIndex = 4;
            // 
            // txtSoLo
            // 
            txtSoLo.Location = new Point(350, 46);
            txtSoLo.Name = "txtSoLo";
            txtSoLo.Size = new Size(150, 27);
            txtSoLo.TabIndex = 3;
            // 
            // lblThuocChon
            // 
            lblThuocChon.AutoSize = true;
            lblThuocChon.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblThuocChon.Location = new Point(350, 14);
            lblThuocChon.Name = "lblThuocChon";
            lblThuocChon.Size = new Size(137, 20);
            lblThuocChon.TabIndex = 2;
            lblThuocChon.Text = "(chưa chọn thuốc)";
            // 
            // lstGoiY
            // 
            lstGoiY.FormattingEnabled = true;
            lstGoiY.Location = new Point(14, 46);
            lstGoiY.Name = "lstGoiY";
            lstGoiY.Size = new Size(320, 124);
            lstGoiY.TabIndex = 1;
            // 
            // txtTimThuoc
            // 
            txtTimThuoc.Location = new Point(14, 14);
            txtTimThuoc.Name = "txtTimThuoc";
            txtTimThuoc.Size = new Size(320, 27);
            txtTimThuoc.TabIndex = 0;
            // 
            // pnlK1
            // 
            pnlK1.Dock = DockStyle.Top;
            pnlK1.Location = new Point(16, 80);
            pnlK1.Name = "pnlK1";
            pnlK1.Size = new Size(1130, 12);
            pnlK1.TabIndex = 1;
            // 
            // cardPhieu
            // 
            cardPhieu.BackColor = Color.Transparent;
            cardPhieu.Controls.Add(txtGhiChu);
            cardPhieu.Controls.Add(cboNCC);
            cardPhieu.Dock = DockStyle.Top;
            cardPhieu.Location = new Point(16, 16);
            cardPhieu.Name = "cardPhieu";
            cardPhieu.Padding = new Padding(14);
            cardPhieu.Size = new Size(1130, 64);
            cardPhieu.TabIndex = 0;
            // 
            // txtGhiChu
            // 
            txtGhiChu.Location = new Point(330, 16);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(300, 27);
            txtGhiChu.TabIndex = 2;
            // 
            // cboNCC
            // 
            cboNCC.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNCC.FormattingEnabled = true;
            cboNCC.Location = new Point(14, 16);
            cboNCC.Name = "cboNCC";
            cboNCC.Size = new Size(300, 28);
            cboNCC.TabIndex = 1;
            // 
            // timerTim
            // 
            timerTim.Interval = 250;
            // 
            // frmNhapKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 703);
            Controls.Add(pnlNoiDung);
            Controls.Add(lblTrangThai);
            Controls.Add(pnlHeader);
            KeyPreview = true;
            Name = "frmNhapKho";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhập kho";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNoiDung.ResumeLayout(false);
            cardLuoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDong).EndInit();
            pnlDay.ResumeLayout(false);
            cardThemDong.ResumeLayout(false);
            cardThemDong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numGia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSL).EndInit();
            cardPhieu.ResumeLayout(false);
            cardPhieu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblTrangThai;
        private Panel pnlNoiDung;
        private CardPanel cardThemDong;
        private TextBox txtTimThuoc;
        private Panel pnlK1;
        private CardPanel cardPhieu;
        private TextBox txtGhiChu;
        private ComboBox cboNCC;
        private DateTimePicker dtpNSX;
        private TextBox txtSoLo;
        private Label lblThuocChon;
        private ListBox lstGoiY;
        private Panel pnlK2;
        private Button btnThemDong;
        private NumericUpDown numGia;
        private NumericUpDown numSL;
        private DateTimePicker dtpHan;
        private CardPanel cardLuoi;
        private DataGridView dgvDong;
        private Panel pnlDay;
        private Button btnXoaDong;
        private Button btnLuuPhieu;
        private System.Windows.Forms.Timer timerTim;
        private Label lblGia;
        private Label lblSL;
        private Label lblHan;
    }
}