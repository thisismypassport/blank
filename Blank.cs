namespace blank
{
    public partial class Blank : Form
    {
        bool SuppressActivateOnPopupClose;

        public Blank(Point center)
        {
            Location = center;
            InitializeComponent();
            Update(withTopMost: true);
        }

        public Point Center =>
            new Point(Location.X + Size.Width / 2, Location.Y + Size.Height / 2);

        private void OnCloseClick(object sender, EventArgs e)
        {
            Utils.ActivateLastWindow(ProgramUi.GetBlankScreens());
            Application.Exit();
        }

        private void OnClick(object sender, EventArgs e)
        {
            Utils.ActivateLastWindow(ProgramUi.GetBlankScreens());
        }

        private void OnPopupClose(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (SuppressActivateOnPopupClose)
                SuppressActivateOnPopupClose = false;
            else
                Utils.ActivateLastWindow(ProgramUi.GetBlankScreens());
        }

        private void OnPopupItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == PopupEditBtn || e.ClickedItem?.Tag is Screen)
                SuppressActivateOnPopupClose = true;
        }

        private void OnEdit(object sender, EventArgs e)
        {
            var edit = new EditColors();
            edit.TopMost = TopMost;
            edit.ShowDialog(this);

            Utils.ActivateLastWindow(ProgramUi.GetBlankScreens());
        }

        private void OnPopupOpen(object sender, EventArgs e)
        {
            PopupAlwaysOnTop.Checked = ColorData.GetIsAlwaysOnTop();
            PopulatePopupMenuColors();
            PopulatePopupMenuScreens();
        }

        void PopulatePopupMenuColors()
        {
            int start = PopupMenu.Items.IndexOf(PopupCloseSep) + 1;
            int end = PopupMenu.Items.IndexOf(PopupEditSep);

            while (start < end)
                PopupMenu.Items.RemoveAt(--end);

            foreach (var color in ColorData.GetDefined())
            {
                var button = new ToolStripMenuItem(color.Name, ColorImages.Get(this, color.Color), (s, e) =>
                {
                    ColorData.SetCurrentColor(color.Color);
                    ProgramUi.Update();
                });
                button.Tag = color;
                button.Checked = ColorData.GetCurrentColor() == color.Color;

                PopupMenu.Items.Insert(start++, button);
            }
        }

        void PopulatePopupMenuScreens()
        {
            int start = PopupMenu.Items.IndexOf(PopupScreenSep) + 1;
            int end = PopupMenu.Items.Count;

            while (start < end)
                PopupMenu.Items.RemoveAt(--end);

            var blankScreens = ProgramUi.GetBlankScreensDictionary();

            int screenId = 1;
            foreach (var screen in Screen.AllScreens)
            {
                var button = new ToolStripMenuItem($"Screen #{screenId++}", null, (s, e) =>
                {
                    ProgramUi.AddOrRemoveBlankScreen(screen);
                });
                button.Tag = screen;
                button.Checked = blankScreens.ContainsKey(screen);
                if (blankScreens.TryGetValue(screen, out Blank? blank) && blank == this)
                    button.Font = new Font(button.Font, FontStyle.Bold);

                PopupMenu.Items.Insert(start++, button);
            }
        }

        public void Update(Color? overrideColor = null, bool withTopMost = false)
        {
            ColorLbl.BackColor = overrideColor ?? ColorData.GetCurrentColor();
            if (withTopMost)
                TopMost = ColorData.GetIsAlwaysOnTop();
        }

        private void OnAlwaysOnTop(object sender, EventArgs e)
        {
            ColorData.SetIsAlwaysOnTop(!PopupAlwaysOnTop.Checked);
            ProgramUi.Update(withTopmost: true);
        }
    }
}
