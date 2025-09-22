namespace blank
{
    public partial class EditColors : Form
    {
        public EditColors()
        {
            InitializeComponent();

            foreach (var color in ColorData.GetDefined())
                AddUiToPane(color);
        }

        void AddUiToPane(ColorItem color)
        {
            int count = Pane.Controls.Count;
            var last = count > 0 ? Pane.Controls[count - 1] : null;
            int y = (last?.Location.Y + last?.Size.Height) ?? 0;

            var ui = new ColorItemUi();
            ui.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ui.Location = new Point(0, y);
            ui.Width = Pane.Width;
            ui.ColorItem = color;

            ui.RemoveClicked += OnRemove;
            ui.SelectClicked += OnSelect;
            ui.ColorEdited += OnColorEdited;

            Pane.Controls.Add(ui);

            if (color.Color == ColorData.GetCurrentColor())
                OnSelect(ui);
        }

        Color? GetSelectedColor()
        {
            foreach (ColorItemUi ui in Pane.Controls)
                if (ui.IsSelected)
                    return ui.ColorItem.Color;
            return null;
        }

        private void OnAdd(object sender, EventArgs e)
        {
            AddUiToPane(new ColorItem("Custom", Color.Gray));

            FixupSelection();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Close();
        }

        private void OnOK(object sender, EventArgs e)
        {
            Color? currColor = GetSelectedColor();

            List<ColorItem> colors = new();
            foreach (ColorItemUi ui in Pane.Controls)
                colors.Add(ui.ColorItem);

            ColorData.SetDefined(colors);
            ColorData.SetCurrentColor(currColor ?? ColorData.GetDefaultColor());

            Close();
        }

        private void OnReset(object sender, EventArgs e)
        {
            Pane.Controls.Clear();
            foreach (var color in ColorData.GetDefinedDefault())
                AddUiToPane(color);

            UpdatePreview();
            FixupSelection();
        }

        private void OnClose(object sender, FormClosedEventArgs e)
        {
            ProgramUi.Update();
        }

        void UpdatePreview()
        {
            ProgramUi.Update(GetSelectedColor());
        }

        private void OnRemove(ColorItemUi sender)
        {
            int senderIdx = Pane.Controls.IndexOf(sender);

            int nextY = sender.Location.Y;
            for (int i = senderIdx + 1; i < Pane.Controls.Count; i++)
            {
                var ui = (ColorItemUi) Pane.Controls[i];
                ui.Location = ui.Location with { Y = nextY };
                nextY = ui.Location.Y + ui.Size.Height;
            }

            Pane.Controls.Remove(sender);
            FixupSelection();
        }

        private void OnSelect(ColorItemUi sender)
        {
            foreach (ColorItemUi other in Pane.Controls)
                other.IsSelected = false;
            sender.IsSelected = true;

            UpdatePreview();
        }

        private void OnColorEdited(ColorItemUi sender)
        {
            UpdatePreview();
        }

        void FixupSelection()
        {
            if (GetSelectedColor() == null && Pane.Controls.Count > 0)
                OnSelect((ColorItemUi) Pane.Controls[0]);
        }
    }
}
