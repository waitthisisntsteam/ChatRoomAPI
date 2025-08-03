namespace ChatRoom
{
    partial class TabSelection
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
            SelectionOptions = new ComboBox();
            AddButton = new Button();
            UsernameSearch = new TextBox();
            WithWho = new Label();
            DirectMessageSuccess = new Label();
            SuspendLayout();
            // 
            // SelectionOptions
            // 
            SelectionOptions.FormattingEnabled = true;
            SelectionOptions.Location = new Point(12, 12);
            SelectionOptions.Name = "SelectionOptions";
            SelectionOptions.Size = new Size(192, 23);
            SelectionOptions.TabIndex = 0;
            SelectionOptions.SelectedIndexChanged += SelectionOptions_SelectedIndexChanged;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(210, 12);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(26, 23);
            AddButton.TabIndex = 1;
            AddButton.Text = " +";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // UsernameSearch
            // 
            UsernameSearch.Location = new Point(12, 56);
            UsernameSearch.Name = "UsernameSearch";
            UsernameSearch.Size = new Size(224, 23);
            UsernameSearch.TabIndex = 2;
            UsernameSearch.TextChanged += UsernameSearch_TextChanged;
            // 
            // WithWho
            // 
            WithWho.AutoSize = true;
            WithWho.Location = new Point(12, 38);
            WithWho.Name = "WithWho";
            WithWho.Size = new Size(65, 15);
            WithWho.TabIndex = 3;
            WithWho.Text = "With Who?";
            // 
            // DirectMessageSuccess
            // 
            DirectMessageSuccess.AutoSize = true;
            DirectMessageSuccess.Location = new Point(12, 82);
            DirectMessageSuccess.Name = "DirectMessageSuccess";
            DirectMessageSuccess.Size = new Size(0, 15);
            DirectMessageSuccess.TabIndex = 4;
            // 
            // TabSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 102);
            Controls.Add(DirectMessageSuccess);
            Controls.Add(WithWho);
            Controls.Add(UsernameSearch);
            Controls.Add(AddButton);
            Controls.Add(SelectionOptions);
            Name = "TabSelection";
            Text = "TabSelection";
            Load += TabSelection_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox SelectionOptions;
        private Button AddButton;
        private TextBox UsernameSearch;
        private Label WithWho;
        private Label DirectMessageSuccess;
    }
}