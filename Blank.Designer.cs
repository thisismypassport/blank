namespace blank
{
    partial class Blank
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ColorLbl = new Label();
            PopupMenu = new ContextMenuStrip(components);
            PopupCloseBtn = new ToolStripMenuItem();
            PopupCloseSep = new ToolStripSeparator();
            PopupEditSep = new ToolStripSeparator();
            PopupEditBtn = new ToolStripMenuItem();
            PopupAlwaysOnTop = new ToolStripMenuItem();
            PopupScreenSep = new ToolStripSeparator();
            PopupMenu.SuspendLayout();
            SuspendLayout();
            // 
            // ColorLbl
            // 
            ColorLbl.BackColor = Color.Black;
            ColorLbl.ContextMenuStrip = PopupMenu;
            ColorLbl.Dock = DockStyle.Fill;
            ColorLbl.Location = new Point(0, 0);
            ColorLbl.Margin = new Padding(2, 0, 2, 0);
            ColorLbl.Name = "ColorLbl";
            ColorLbl.Size = new Size(431, 211);
            ColorLbl.TabIndex = 0;
            ColorLbl.Click += OnClick;
            ColorLbl.DoubleClick += OnCloseClick;
            // 
            // PopupMenu
            // 
            PopupMenu.ImageScalingSize = new Size(32, 32);
            PopupMenu.Items.AddRange(new ToolStripItem[] { PopupCloseBtn, PopupCloseSep, PopupEditSep, PopupEditBtn, PopupAlwaysOnTop, PopupScreenSep });
            PopupMenu.Name = "PopupMenu";
            PopupMenu.Size = new Size(153, 88);
            PopupMenu.Closed += OnPopupClose;
            PopupMenu.Opened += OnPopupOpen;
            PopupMenu.ItemClicked += OnPopupItemClick;
            // 
            // PopupCloseBtn
            // 
            PopupCloseBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PopupCloseBtn.Name = "PopupCloseBtn";
            PopupCloseBtn.Size = new Size(152, 22);
            PopupCloseBtn.Text = "Close";
            PopupCloseBtn.Click += OnCloseClick;
            // 
            // PopupCloseSep
            // 
            PopupCloseSep.Name = "PopupCloseSep";
            PopupCloseSep.Size = new Size(149, 6);
            // 
            // PopupEditSep
            // 
            PopupEditSep.Name = "PopupEditSep";
            PopupEditSep.Size = new Size(149, 6);
            // 
            // PopupEditBtn
            // 
            PopupEditBtn.Name = "PopupEditBtn";
            PopupEditBtn.Size = new Size(152, 22);
            PopupEditBtn.Text = "Edit Colors...";
            PopupEditBtn.Click += OnEdit;
            // 
            // PopupAlwaysOnTop
            // 
            PopupAlwaysOnTop.Name = "PopupAlwaysOnTop";
            PopupAlwaysOnTop.Size = new Size(152, 22);
            PopupAlwaysOnTop.Text = "Always On Top";
            PopupAlwaysOnTop.Click += OnAlwaysOnTop;
            // 
            // PopupScreenSep
            // 
            PopupScreenSep.Name = "PopupScreenSep";
            PopupScreenSep.Size = new Size(149, 6);
            // 
            // Blank
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 211);
            ControlBox = false;
            Controls.Add(ColorLbl);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 1, 2, 1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Blank";
            StartPosition = FormStartPosition.Manual;
            Text = "Blank";
            WindowState = FormWindowState.Maximized;
            PopupMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label ColorLbl;
        private ContextMenuStrip PopupMenu;
        private ToolStripMenuItem PopupCloseBtn;
        private ToolStripSeparator PopupCloseSep;
        private ToolStripSeparator PopupEditSep;
        private ToolStripMenuItem PopupEditBtn;
        private ToolStripSeparator PopupScreenSep;
        private ToolStripMenuItem PopupAlwaysOnTop;
    }
}
