namespace NhaThuoc.App.Forms
{
    partial class frmTimThuoc
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
            lblGoiY = new Label();
            lblTieuDe = new Label();
            lblTrangThai = new Label();
            pnlNoiDung = new Panel();
            cardKetQua = new CardPanel();
            dgvKetQua = new DataGridView();
            pnlKhoang = new Panel();
            cardTimKiem = new CardPanel();
            flpLoc = new FlowLayoutPanel();
            cboNhom = new ComboBox();
            cboDang = new ComboBox();
            cboKeDon = new ComboBox();
            cboTonKho = new ComboBox();
            lblGiaTu = new Label();
            numGiaMin = new NumericUpDown();
            lblGiaDen = new Label();
            numGiaMax = new NumericUpDown();
            cboSapXep = new ComboBox();
            cboCheDo = new ComboBox();
            chkNhieuHoatChat = new CheckBox();
            btnChiTiet = new Button();
            btnThayThe = new Button();
            txtTimKiem = new TextBox();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            timerTim = new System.Windows.Forms.Timer(components);
            pnlHeader.SuspendLayout();
            pnlNoiDung.SuspendLayout();
            cardKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            cardTimKiem.SuspendLayout();
            flpLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numGiaMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGiaMax).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblGoiY);
            pnlHeader.Controls.Add(lblTieuDe);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1162, 64);
            pnlHeader.TabIndex = 0;
            // 
            // lblGoiY
            // 
            lblGoiY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGoiY.AutoSize = true;
            lblGoiY.Location = new Point(777, 9);
            lblGoiY.Name = "lblGoiY";
            lblGoiY.Size = new Size(382, 20);
            lblGoiY.TabIndex = 1;
            lblGoiY.Text = "F3 tìm · F4 thuốc cùng hoạt chất · F5 chi tiết · Esc quay lại";
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(16, 14);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(98, 20);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Tra cứu thuốc";
            // 
            // lblTrangThai
            // 
            lblTrangThai.AutoSize = true;
            lblTrangThai.Dock = DockStyle.Bottom;
            lblTrangThai.Location = new Point(0, 633);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(50, 20);
            lblTrangThai.TabIndex = 2;
            lblTrangThai.Text = "label1";
            // 
            // pnlNoiDung
            // 
            pnlNoiDung.Controls.Add(cardKetQua);
            pnlNoiDung.Controls.Add(pnlKhoang);
            pnlNoiDung.Controls.Add(cardTimKiem);
            pnlNoiDung.Dock = DockStyle.Fill;
            pnlNoiDung.Location = new Point(0, 64);
            pnlNoiDung.Name = "pnlNoiDung";
            pnlNoiDung.Padding = new Padding(16);
            pnlNoiDung.Size = new Size(1162, 569);
            pnlNoiDung.TabIndex = 3;
            // 
            // cardKetQua
            // 
            cardKetQua.BackColor = Color.Transparent;
            cardKetQua.Controls.Add(dgvKetQua);
            cardKetQua.Dock = DockStyle.Fill;
            cardKetQua.Location = new Point(16, 168);
            cardKetQua.Name = "cardKetQua";
            cardKetQua.Padding = new Padding(1);
            cardKetQua.Size = new Size(1130, 385);
            cardKetQua.TabIndex = 2;
            // 
            // dgvKetQua
            // 
            dgvKetQua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKetQua.Dock = DockStyle.Fill;
            dgvKetQua.Location = new Point(1, 1);
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.RowHeadersWidth = 51;
            dgvKetQua.Size = new Size(1128, 383);
            dgvKetQua.TabIndex = 0;
            // 
            // pnlKhoang
            // 
            pnlKhoang.Dock = DockStyle.Top;
            pnlKhoang.Location = new Point(16, 156);
            pnlKhoang.Name = "pnlKhoang";
            pnlKhoang.Size = new Size(1130, 12);
            pnlKhoang.TabIndex = 1;
            // 
            // cardTimKiem
            // 
            cardTimKiem.BackColor = Color.Transparent;
            cardTimKiem.Controls.Add(flpLoc);
            cardTimKiem.Controls.Add(cboCheDo);
            cardTimKiem.Controls.Add(chkNhieuHoatChat);
            cardTimKiem.Controls.Add(btnChiTiet);
            cardTimKiem.Controls.Add(btnThayThe);
            cardTimKiem.Controls.Add(txtTimKiem);
            cardTimKiem.Dock = DockStyle.Top;
            cardTimKiem.Location = new Point(16, 16);
            cardTimKiem.Name = "cardTimKiem";
            cardTimKiem.Padding = new Padding(14);
            cardTimKiem.Size = new Size(1130, 140);
            cardTimKiem.TabIndex = 0;
            // 
            // flpLoc
            // 
            flpLoc.Anchor = AnchorStyles.Top;
            flpLoc.Controls.Add(cboNhom);
            flpLoc.Controls.Add(cboDang);
            flpLoc.Controls.Add(cboKeDon);
            flpLoc.Controls.Add(cboTonKho);
            flpLoc.Controls.Add(lblGiaTu);
            flpLoc.Controls.Add(numGiaMin);
            flpLoc.Controls.Add(lblGiaDen);
            flpLoc.Controls.Add(numGiaMax);
            flpLoc.Controls.Add(cboSapXep);
            flpLoc.Location = new Point(14, 100);
            flpLoc.Name = "flpLoc";
            flpLoc.Size = new Size(1099, 34);
            flpLoc.TabIndex = 5;
            flpLoc.WrapContents = false;
            // 
            // cboNhom
            // 
            cboNhom.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhom.FormattingEnabled = true;
            cboNhom.Location = new Point(0, 0);
            cboNhom.Margin = new Padding(0, 0, 8, 0);
            cboNhom.Name = "cboNhom";
            cboNhom.Size = new Size(150, 28);
            cboNhom.TabIndex = 0;
            // 
            // cboDang
            // 
            cboDang.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDang.FormattingEnabled = true;
            cboDang.Location = new Point(158, 0);
            cboDang.Margin = new Padding(0, 0, 8, 0);
            cboDang.Name = "cboDang";
            cboDang.Size = new Size(150, 28);
            cboDang.TabIndex = 1;
            // 
            // cboKeDon
            // 
            cboKeDon.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKeDon.FormattingEnabled = true;
            cboKeDon.Location = new Point(316, 0);
            cboKeDon.Margin = new Padding(0, 0, 8, 0);
            cboKeDon.Name = "cboKeDon";
            cboKeDon.Size = new Size(150, 28);
            cboKeDon.TabIndex = 2;
            // 
            // cboTonKho
            // 
            cboTonKho.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTonKho.FormattingEnabled = true;
            cboTonKho.Location = new Point(474, 0);
            cboTonKho.Margin = new Padding(0, 0, 8, 0);
            cboTonKho.Name = "cboTonKho";
            cboTonKho.Size = new Size(150, 28);
            cboTonKho.TabIndex = 3;
            // 
            // lblGiaTu
            // 
            lblGiaTu.AutoSize = true;
            lblGiaTu.Location = new Point(632, 6);
            lblGiaTu.Margin = new Padding(0, 6, 6, 0);
            lblGiaTu.Name = "lblGiaTu";
            lblGiaTu.Size = new Size(49, 20);
            lblGiaTu.TabIndex = 4;
            lblGiaTu.Text = "Giá từ";
            // 
            // numGiaMin
            // 
            numGiaMin.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numGiaMin.Location = new Point(690, 3);
            numGiaMin.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numGiaMin.Name = "numGiaMin";
            numGiaMin.Size = new Size(100, 27);
            numGiaMin.TabIndex = 5;
            numGiaMin.ThousandsSeparator = true;
            // 
            // lblGiaDen
            // 
            lblGiaDen.AutoSize = true;
            lblGiaDen.Location = new Point(793, 6);
            lblGiaDen.Margin = new Padding(0, 6, 6, 0);
            lblGiaDen.Name = "lblGiaDen";
            lblGiaDen.Size = new Size(34, 20);
            lblGiaDen.TabIndex = 6;
            lblGiaDen.Text = "đến";
            // 
            // numGiaMax
            // 
            numGiaMax.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            numGiaMax.Location = new Point(836, 3);
            numGiaMax.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numGiaMax.Name = "numGiaMax";
            numGiaMax.Size = new Size(100, 27);
            numGiaMax.TabIndex = 7;
            numGiaMax.ThousandsSeparator = true;
            // 
            // cboSapXep
            // 
            cboSapXep.FormattingEnabled = true;
            cboSapXep.Location = new Point(942, 3);
            cboSapXep.Name = "cboSapXep";
            cboSapXep.Size = new Size(150, 28);
            cboSapXep.TabIndex = 8;
            // 
            // cboCheDo
            // 
            cboCheDo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCheDo.FormattingEnabled = true;
            cboCheDo.Location = new Point(458, 60);
            cboCheDo.Name = "cboCheDo";
            cboCheDo.Size = new Size(180, 28);
            cboCheDo.TabIndex = 4;
            // 
            // chkNhieuHoatChat
            // 
            chkNhieuHoatChat.AutoSize = true;
            chkNhieuHoatChat.Location = new Point(14, 60);
            chkNhieuHoatChat.Name = "chkNhieuHoatChat";
            chkNhieuHoatChat.Size = new Size(371, 24);
            chkNhieuHoatChat.TabIndex = 3;
            chkNhieuHoatChat.Text = "Tìm theo nhiều hoạt chất (cách nhau bằng , hoặc +)";
            chkNhieuHoatChat.UseVisualStyleBackColor = true;
            // 
            // btnChiTiet
            // 
            btnChiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChiTiet.Location = new Point(850, 12);
            btnChiTiet.Name = "btnChiTiet";
            btnChiTiet.Size = new Size(110, 29);
            btnChiTiet.TabIndex = 2;
            btnChiTiet.Text = "Chi tiết (F5)";
            btnChiTiet.UseVisualStyleBackColor = true;
            // 
            // btnThayThe
            // 
            btnThayThe.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThayThe.Location = new Point(630, 12);
            btnThayThe.Name = "btnThayThe";
            btnThayThe.Size = new Size(200, 29);
            btnThayThe.TabIndex = 1;
            btnThayThe.Tag = "primary";
            btnThayThe.Text = "Thuốc cùng hoạt chất (F4)";
            btnThayThe.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Location = new Point(14, 14);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(600, 27);
            txtTimKiem.TabIndex = 0;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // timerTim
            // 
            timerTim.Interval = 250;
            // 
            // frmTimThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 653);
            Controls.Add(pnlNoiDung);
            Controls.Add(lblTrangThai);
            Controls.Add(pnlHeader);
            KeyPreview = true;
            Name = "frmTimThuoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tìm kiếm thuốc";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlNoiDung.ResumeLayout(false);
            cardKetQua.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            cardTimKiem.ResumeLayout(false);
            cardTimKiem.PerformLayout();
            flpLoc.ResumeLayout(false);
            flpLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numGiaMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGiaMax).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTieuDe;
        private Label lblGoiY;
        private Label lblTrangThai;
        private Panel pnlNoiDung;
        private CardPanel cardKetQua;
        private DataGridView dgvKetQua;
        private Panel pnlKhoang;
        private CardPanel cardTimKiem;
        private Button btnThayThe;
        private TextBox txtTimKiem;
        private CheckBox chkNhieuHoatChat;
        private Button btnChiTiet;
        private FlowLayoutPanel flpLoc;
        private ComboBox cboCheDo;
        private ComboBox cboNhom;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ComboBox cboDang;
        private ComboBox cboKeDon;
        private ComboBox cboTonKho;
        private Label lblGiaTu;
        private NumericUpDown numGiaMin;
        private Label lblGiaDen;
        private NumericUpDown numGiaMax;
        private ComboBox cboSapXep;
        private System.Windows.Forms.Timer timerTim;
    }
}