namespace blank
{
    public partial class ColorItemUi : UserControl
    {
        Color Color;

        public event Action<ColorItemUi>? RemoveClicked;
        public event Action<ColorItemUi>? SelectClicked;
        public event Action<ColorItemUi>? ColorEdited;

        public ColorItemUi()
        {
            InitializeComponent();
        }

        public ColorItem ColorItem
        {
            get => new ColorItem(NameText.Text, Color);
            set
            {
                Color = value.Color;
                NameText.Text = value.Name;
                ColorLbl.Image = ColorImages.Get(this, value.Color, full: true);
            }
        }

        public bool IsSelected
        {
            get => Radio.Checked;
            set => Radio.Checked = value;
        }

        private void OnEditColor(object sender, EventArgs e)
        {
            var newColor = Utils.ChooseColorWithPreview(this, Color, color => ProgramUi.Update(color));
            ProgramUi.Update();

            if (newColor != null)
                ColorItem = new ColorItem(ColorItem.Name, newColor.Value);

            ColorEdited?.Invoke(this); // also used to undo preview, so call even on cancel
        }

        private void OnDelete(object sender, EventArgs e)
        {
            RemoveClicked?.Invoke(this);
        }

        private void OnRadioClick(object sender, EventArgs e)
        {
            SelectClicked?.Invoke(this);
        }
    }
}
