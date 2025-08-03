namespace ChatRoom
{
    partial class CreateTab
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
            label1 = new Label();
            ChatroomBox = new TextBox();
            ChatroomResult = new Label();
            CreateOrJoinButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Chatroom Name:";
            // 
            // ChatroomBox
            // 
            ChatroomBox.Location = new Point(12, 27);
            ChatroomBox.Name = "ChatroomBox";
            ChatroomBox.Size = new Size(224, 23);
            ChatroomBox.TabIndex = 1;
            ChatroomBox.TextChanged += ChatroomBox_TextChanged;
            // 
            // ChatroomResult
            // 
            ChatroomResult.AutoSize = true;
            ChatroomResult.Location = new Point(12, 53);
            ChatroomResult.Name = "ChatroomResult";
            ChatroomResult.Size = new Size(0, 15);
            ChatroomResult.TabIndex = 2;
            // 
            // CreateOrJoinButton
            // 
            CreateOrJoinButton.Location = new Point(12, 67);
            CreateOrJoinButton.Name = "CreateOrJoinButton";
            CreateOrJoinButton.Size = new Size(224, 23);
            CreateOrJoinButton.TabIndex = 3;
            CreateOrJoinButton.Text = "Add";
            CreateOrJoinButton.UseVisualStyleBackColor = true;
            CreateOrJoinButton.Click += CreateOrJoinButton_Click;
            // 
            // CreateTab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 102);
            Controls.Add(CreateOrJoinButton);
            Controls.Add(ChatroomResult);
            Controls.Add(ChatroomBox);
            Controls.Add(label1);
            Name = "CreateTab";
            Text = "CreateTab";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ChatroomBox;
        private Label ChatroomResult;
        private Button CreateOrJoinButton;
    }
}