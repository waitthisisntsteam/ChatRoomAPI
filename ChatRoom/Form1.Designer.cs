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
            MessageBox = new TextBox();
            SendButton = new Button();
            UserOptionDropdown = new ComboBox();
            Chat = new Label();
            ChatBox = new ListBox();
            SuspendLayout();
            // 
            // MessageBox
            // 
            MessageBox.Location = new Point(112, 415);
            MessageBox.Name = "MessageBox";
            MessageBox.Size = new Size(203, 23);
            MessageBox.TabIndex = 0;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(321, 415);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(44, 23);
            SendButton.TabIndex = 1;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // UserOptionDropdown
            // 
            UserOptionDropdown.FormattingEnabled = true;
            UserOptionDropdown.Location = new Point(12, 416);
            UserOptionDropdown.Name = "UserOptionDropdown";
            UserOptionDropdown.Size = new Size(94, 23);
            UserOptionDropdown.TabIndex = 2;
            UserOptionDropdown.Text = "Select User ...";
            UserOptionDropdown.SelectedIndexChanged += UserOptionDropdown_SelectedIndexChanged;
            // 
            // Chat
            // 
            Chat.AutoSize = true;
            Chat.Location = new Point(12, 398);
            Chat.Name = "Chat";
            Chat.Size = new Size(0, 15);
            Chat.TabIndex = 3;
            // 
            // ChatBox
            // 
            ChatBox.FormattingEnabled = true;
            ChatBox.ItemHeight = 15;
            ChatBox.Location = new Point(12, 12);
            ChatBox.Name = "ChatBox";
            ChatBox.Size = new Size(351, 394);
            ChatBox.TabIndex = 5;
            // 
            // ChatRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 450);
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
        private ListBox ChatBox;
    }
}
