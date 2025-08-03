namespace ChatRoom
{
    partial class CreateUser
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
            UsernameBox = new TextBox();
            NameLabel = new Label();
            PasswordLabel = new Label();
            PasswordBox = new TextBox();
            ConfirmPassword = new Label();
            ConfirmPasswordBox = new TextBox();
            CreateButton = new Button();
            UserSuccess = new Label();
            SuspendLayout();
            // 
            // UsernameBox
            // 
            UsernameBox.Location = new Point(12, 27);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(224, 23);
            UsernameBox.TabIndex = 0;
            UsernameBox.TextChanged += UsernameBox_TextChanged;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(12, 9);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(63, 15);
            NameLabel.TabIndex = 1;
            NameLabel.Text = "Username:";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(12, 53);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(60, 15);
            PasswordLabel.TabIndex = 2;
            PasswordLabel.Text = "Password:";
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(12, 71);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(224, 23);
            PasswordBox.TabIndex = 3;
            PasswordBox.TextChanged += PasswordBox_TextChanged;
            // 
            // ConfirmPassword
            // 
            ConfirmPassword.AutoSize = true;
            ConfirmPassword.Location = new Point(15, 97);
            ConfirmPassword.Name = "ConfirmPassword";
            ConfirmPassword.Size = new Size(107, 15);
            ConfirmPassword.TabIndex = 4;
            ConfirmPassword.Text = "Confirm Password:";
            // 
            // ConfirmPasswordBox
            // 
            ConfirmPasswordBox.Location = new Point(12, 115);
            ConfirmPasswordBox.Name = "ConfirmPasswordBox";
            ConfirmPasswordBox.Size = new Size(224, 23);
            ConfirmPasswordBox.TabIndex = 5;
            ConfirmPasswordBox.TextChanged += ConfirmPasswordBox_TextChanged;
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(12, 165);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(224, 23);
            CreateButton.TabIndex = 6;
            CreateButton.Text = "Register";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += CreateButton_Click;
            // 
            // UserSuccess
            // 
            UserSuccess.AutoSize = true;
            UserSuccess.Location = new Point(15, 147);
            UserSuccess.Name = "UserSuccess";
            UserSuccess.Size = new Size(0, 15);
            UserSuccess.TabIndex = 7;
            // 
            // CreateUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 200);
            Controls.Add(UserSuccess);
            Controls.Add(CreateButton);
            Controls.Add(ConfirmPasswordBox);
            Controls.Add(ConfirmPassword);
            Controls.Add(PasswordBox);
            Controls.Add(PasswordLabel);
            Controls.Add(NameLabel);
            Controls.Add(UsernameBox);
            Name = "CreateUser";
            Text = "CreateUser";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UsernameBox;
        private Label NameLabel;
        private Label PasswordLabel;
        private TextBox PasswordBox;
        private Label ConfirmPassword;
        private TextBox ConfirmPasswordBox;
        private Button CreateButton;
        private Label UserSuccess;
    }
}