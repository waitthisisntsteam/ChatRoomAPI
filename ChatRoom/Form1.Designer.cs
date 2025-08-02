namespace ChatRoom
{
    partial class ChatRoom
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
            MessageBox = new TextBox();
            SendButton = new Button();
            UserOptionDropdown = new ComboBox();
            Chat = new Label();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            ChatBox = new ListBox();
            TabControl = new TabControl();
            AddTabButton = new Button();
            NewTabNameBox = new TextBox();
            SuspendLayout();
            // 
            // MessageBox
            // 
            MessageBox.Enabled = false;
            MessageBox.Location = new Point(112, 440);
            MessageBox.Name = "MessageBox";
            MessageBox.Size = new Size(203, 23);
            MessageBox.TabIndex = 0;
            // 
            // SendButton
            // 
            SendButton.Enabled = false;
            SendButton.Location = new Point(321, 440);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(44, 23);
            SendButton.TabIndex = 1;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // UserOptionDropdown
            // 
            UserOptionDropdown.Enabled = false;
            UserOptionDropdown.FormattingEnabled = true;
            UserOptionDropdown.Location = new Point(12, 440);
            UserOptionDropdown.Name = "UserOptionDropdown";
            UserOptionDropdown.Size = new Size(94, 23);
            UserOptionDropdown.TabIndex = 2;
            UserOptionDropdown.Text = "Select User ...";
            UserOptionDropdown.SelectedIndexChanged += UserOptionDropdown_SelectedIndexChanged;
            // 
            // Chat
            // 
            Chat.AutoSize = true;
            Chat.Location = new Point(12, 421);
            Chat.Name = "Chat";
            Chat.Size = new Size(0, 15);
            Chat.TabIndex = 3;
            // 
            // UpdateTimer
            // 
            UpdateTimer.Enabled = true;
            UpdateTimer.Interval = 500;
            UpdateTimer.Tick += UpdateTimer_Tick;
            // 
            // ChatBox
            // 
            ChatBox.Enabled = false;
            ChatBox.FormattingEnabled = true;
            ChatBox.ItemHeight = 15;
            ChatBox.Location = new Point(12, 40);
            ChatBox.Name = "ChatBox";
            ChatBox.Size = new Size(351, 394);
            ChatBox.TabIndex = 5;
            // 
            // TabControl
            // 
            TabControl.Location = new Point(12, 12);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(203, 22);
            TabControl.TabIndex = 6;
            TabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // AddTabButton
            // 
            AddTabButton.Enabled = false;
            AddTabButton.Location = new Point(321, 12);
            AddTabButton.Name = "AddTabButton";
            AddTabButton.Size = new Size(44, 23);
            AddTabButton.TabIndex = 7;
            AddTabButton.Text = "New";
            AddTabButton.UseVisualStyleBackColor = true;
            AddTabButton.Click += AddTabButton_Click;
            // 
            // NewTabNameBox
            // 
            NewTabNameBox.Location = new Point(221, 12);
            NewTabNameBox.Name = "NewTabNameBox";
            NewTabNameBox.Size = new Size(94, 23);
            NewTabNameBox.TabIndex = 8;
            NewTabNameBox.TextChanged += NewTabNameBox_TextChanged;
            // 
            // ChatRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 475);
            Controls.Add(NewTabNameBox);
            Controls.Add(AddTabButton);
            Controls.Add(TabControl);
            Controls.Add(ChatBox);
            Controls.Add(Chat);
            Controls.Add(UserOptionDropdown);
            Controls.Add(SendButton);
            Controls.Add(MessageBox);
            Name = "ChatRoom";
            Text = "ChatRoom";
            Load += ChatRoom_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox MessageBox;
        private Button SendButton;
        private ComboBox UserOptionDropdown;
        private Label Chat;
        private System.Windows.Forms.Timer UpdateTimer;
        private ListBox ChatBox;
        private TabControl TabControl;
        private Button AddTabButton;
        private TextBox NewTabNameBox;
    }
}
