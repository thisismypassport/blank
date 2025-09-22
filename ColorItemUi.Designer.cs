namespace blank
{
    partial class ColorItemUi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NameText = new TextBox();
            ColorBtn = new Button();
            DeleteBtn = new Button();
            ColorLbl = new Label();
            Radio = new RadioButton();
            SuspendLayout();
            // 
            // NameText
            // 
            NameText.Location = new Point(20, 5);
            NameText.Margin = new Padding(2, 1, 2, 1);
            NameText.Name = "NameText";
            NameText.Size = new Size(131, 23);
            NameText.TabIndex = 1;
            // 
            // ColorBtn
            // 
            ColorBtn.ImageAlign = ContentAlignment.MiddleLeft;
            ColorBtn.Location = new Point(194, 5);
            ColorBtn.Margin = new Padding(2, 1, 2, 1);
            ColorBtn.Name = "ColorBtn";
            ColorBtn.Size = new Size(81, 22);
            ColorBtn.TabIndex = 2;
            ColorBtn.Text = "Edit Color";
            ColorBtn.UseVisualStyleBackColor = true;
            ColorBtn.Click += OnEditColor;
            // 
            // DeleteBtn
            // 
            DeleteBtn.Anchor =  AnchorStyles.Top | AnchorStyles.Right;
            DeleteBtn.Location = new Point(332, 5);
            DeleteBtn.Margin = new Padding(2, 1, 2, 1);
            DeleteBtn.Name = "DeleteBtn";
            DeleteBtn.Size = new Size(23, 22);
            DeleteBtn.TabIndex = 3;
            DeleteBtn.Text = "X";
            DeleteBtn.UseVisualStyleBackColor = true;
            DeleteBtn.Click += OnDelete;
            // 
            // ColorLbl
            // 
            ColorLbl.Location = new Point(174, 8);
            ColorLbl.Margin = new Padding(2, 0, 2, 0);
            ColorLbl.Name = "ColorLbl";
            ColorLbl.Size = new Size(17, 15);
            ColorLbl.TabIndex = 4;
            // 
            // Radio
            // 
            Radio.AutoSize = true;
            Radio.Location = new Point(2, 9);
            Radio.Margin = new Padding(2, 1, 2, 1);
            Radio.Name = "Radio";
            Radio.Size = new Size(14, 13);
            Radio.TabIndex = 5;
            Radio.TabStop = true;
            Radio.UseVisualStyleBackColor = true;
            Radio.Click += OnRadioClick;
            // 
            // ColorItemUi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Radio);
            Controls.Add(ColorLbl);
            Controls.Add(DeleteBtn);
            Controls.Add(ColorBtn);
            Controls.Add(NameText);
            Margin = new Padding(2, 1, 2, 1);
            Name = "ColorItemUi";
            Size = new Size(357, 32);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameText;
        private Button ColorBtn;
        private Button DeleteBtn;
        private Label ColorLbl;
        private RadioButton Radio;
    }
}
