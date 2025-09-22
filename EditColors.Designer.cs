namespace blank
{
    partial class EditColors
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
            OKBtn = new Button();
            Pane = new Panel();
            AddBtn = new Button();
            CancelBtn = new Button();
            ResetBtn = new Button();
            Sep = new Label();
            SuspendLayout();
            // 
            // OKBtn
            // 
            OKBtn.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
            OKBtn.Location = new Point(212, 418);
            OKBtn.Margin = new Padding(2, 1, 2, 1);
            OKBtn.Name = "OKBtn";
            OKBtn.Size = new Size(81, 22);
            OKBtn.TabIndex = 0;
            OKBtn.Text = "OK";
            OKBtn.UseVisualStyleBackColor = true;
            OKBtn.Click += OnOK;
            // 
            // Pane
            // 
            Pane.Anchor =  AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Pane.AutoScroll = true;
            Pane.Location = new Point(6, 6);
            Pane.Margin = new Padding(2, 1, 2, 1);
            Pane.Name = "Pane";
            Pane.Size = new Size(372, 374);
            Pane.TabIndex = 1;
            // 
            // AddBtn
            // 
            AddBtn.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left;
            AddBtn.Location = new Point(6, 382);
            AddBtn.Margin = new Padding(2, 1, 2, 1);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(81, 22);
            AddBtn.TabIndex = 2;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += OnAdd;
            // 
            // CancelBtn
            // 
            CancelBtn.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
            CancelBtn.Location = new Point(297, 418);
            CancelBtn.Margin = new Padding(2, 1, 2, 1);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(81, 22);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += OnCancel;
            // 
            // ResetBtn
            // 
            ResetBtn.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
            ResetBtn.Location = new Point(297, 382);
            ResetBtn.Margin = new Padding(2, 1, 2, 1);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(81, 22);
            ResetBtn.TabIndex = 4;
            ResetBtn.Text = "Reset";
            ResetBtn.UseVisualStyleBackColor = true;
            ResetBtn.Click += OnReset;
            // 
            // Sep
            // 
            Sep.Anchor =  AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Sep.BorderStyle = BorderStyle.Fixed3D;
            Sep.Location = new Point(6, 411);
            Sep.Margin = new Padding(2, 0, 2, 0);
            Sep.Name = "Sep";
            Sep.Size = new Size(372, 1);
            Sep.TabIndex = 5;
            // 
            // EditColors
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelBtn;
            ClientSize = new Size(384, 445);
            Controls.Add(ResetBtn);
            Controls.Add(Sep);
            Controls.Add(CancelBtn);
            Controls.Add(AddBtn);
            Controls.Add(Pane);
            Controls.Add(OKBtn);
            Margin = new Padding(2, 1, 2, 1);
            Name = "EditColors";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Colors";
            FormClosed += OnClose;
            ResumeLayout(false);
        }

        #endregion
        private Button OKBtn;
        private Panel Pane;
        private Button AddBtn;
        private Button CancelBtn;
        private Button ResetBtn;
        private Label Sep;
    }
}