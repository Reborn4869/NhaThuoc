using System.Reflection;

namespace NhaThuoc.App;

internal static class Theme
{
    public static readonly Color Primary = ColorTranslator.FromHtml("#0F766E");
    public static readonly Color PrimaryDark = ColorTranslator.FromHtml("#115E59");
    public static readonly Color PrimarySoft = ColorTranslator.FromHtml("#CCFBF1");
    public static readonly Color Background = ColorTranslator.FromHtml("#F3F6F8");
    public static readonly Color Card = Color.White;
    public static readonly Color Zebra = ColorTranslator.FromHtml("#F8FAFB");
    public static readonly Color Border = ColorTranslator.FromHtml("#D9E1E7");
    public static readonly Color Text = ColorTranslator.FromHtml("#1F2933");
    public static readonly Color TextMuted = ColorTranslator.FromHtml("#6B7785");
    public static readonly Color Danger = ColorTranslator.FromHtml("#C62828");
    public static readonly Color Warning = ColorTranslator.FromHtml("#B26A00");
    public static readonly Color Success = ColorTranslator.FromHtml("#1B7F3B");

    public static readonly Font Body = new("Segoe UI", 10f);
    public static readonly Font Strong = new("Segoe UI Semibold", 10f);
    public static readonly Font Title = new("Segoe UI Semibold", 16f);
    public static readonly Font Search = new("Segoe UI", 13f);

    /// <summary>Gọi một lần trong constructor của form, ngay sau InitializeComponent().</summary>
    public static void Apply(Form form)
    {
        form.Font = Body;
        form.BackColor = Background;
        form.ForeColor = Text;
        StyleChildren(form.Controls);
    }

    private static void StyleChildren(Control.ControlCollection controls)
    {
        foreach (Control c in controls)
        {
            switch (c)
            {
                case CardPanel: break;                                   // tự vẽ nền riêng
                case Panel: c.BackColor = Color.Transparent; break;      // gồm cả Flow/TableLayoutPanel
                case DataGridView g: StyleGrid(g); break;
                case Button b: StyleButton(b, primary: b.Tag as string == "primary"); break;
                case ComboBox cbo: cbo.FlatStyle = FlatStyle.Flat; cbo.BackColor = Card; break;
                case TextBox t: t.BorderStyle = BorderStyle.FixedSingle; t.BackColor = Card; break;
                case NumericUpDown n: n.BorderStyle = BorderStyle.FixedSingle; break;
                case CheckBox or Label: c.BackColor = Color.Transparent; break;
            }
            if (c.HasChildren) StyleChildren(c.Controls);
        }
    }

    public static void StyleButton(Button b, bool primary)
    {
        b.FlatStyle = FlatStyle.Flat;
        b.UseVisualStyleBackColor = false;
        b.Cursor = Cursors.Hand;
        b.Height = 36;
        b.Font = Strong;
        b.FlatAppearance.BorderSize = primary ? 0 : 1;
        b.FlatAppearance.BorderColor = Border;
        b.BackColor = primary ? Primary : Card;
        b.ForeColor = primary ? Color.White : Text;
        b.FlatAppearance.MouseOverBackColor = primary ? PrimaryDark : PrimarySoft;
        b.FlatAppearance.MouseDownBackColor = primary ? PrimaryDark : PrimarySoft;
    }

    public static void StyleGrid(DataGridView g)
    {
        g.BorderStyle = BorderStyle.None;
        g.BackgroundColor = Card;
        g.EnableHeadersVisualStyles = false;
        g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        g.ColumnHeadersHeight = 46;
        var h = g.ColumnHeadersDefaultCellStyle;
        h.BackColor = Primary;
        h.ForeColor = Color.White;
        h.Font = Strong;
        h.SelectionBackColor = Primary;
        h.SelectionForeColor = Color.White;
        h.Padding = new Padding(8, 0, 0, 0);

        g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        g.GridColor = Border;
        g.RowTemplate.Height = 34;
        g.RowHeadersVisible = false;
        g.AllowUserToAddRows = false;
        g.AllowUserToDeleteRows = false;
        g.AllowUserToResizeRows = false;
        g.ReadOnly = true;
        g.MultiSelect = false;
        g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        g.DefaultCellStyle.BackColor = Card;
        g.DefaultCellStyle.ForeColor = Text;
        g.DefaultCellStyle.SelectionBackColor = PrimarySoft;
        g.DefaultCellStyle.SelectionForeColor = Text;
        g.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
        g.AlternatingRowsDefaultCellStyle.BackColor = Zebra;
        g.AlternatingRowsDefaultCellStyle.SelectionBackColor = PrimarySoft;
        g.AlternatingRowsDefaultCellStyle.SelectionForeColor = Text;

        // Bật double buffer để cuộn bảng mượt, không nhấp nháy
        typeof(DataGridView).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.SetValue(g, true);
    }

    /// <summary>Thanh tiêu đề màu chủ đạo; hint là dòng nhắc phím tắt (có thể null).</summary>
    public static void StyleHeader(Panel panel, Label title, Label? hint = null)
    {
        panel.BackColor = Primary;
        title.Font = Title;
        title.ForeColor = Color.White;
        title.BackColor = Color.Transparent;
        if (hint != null)
        {
            hint.ForeColor = PrimarySoft;
            hint.BackColor = Color.Transparent;
        }
    }

    /// <summary>Thanh trạng thái dưới đáy form.</summary>
    public static void StyleStatus(Label l)
    {
        l.AutoSize = false;
        l.Dock = DockStyle.Bottom;
        l.Height = 30;
        l.TextAlign = ContentAlignment.MiddleLeft;
        l.Padding = new Padding(16, 0, 0, 0);
        l.ForeColor = TextMuted;
        l.BackColor = Background;
    }
}