namespace ChatRoom
{
    partial class UserSignIn
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
            PasswordBox = new TextBox();
            PasswordLabel = new Label();
            NameLabel = new Label();
            UsernameBox = new TextBox();
            UserSuccess = new Label();
            SignInButton = new Button();
            SuspendLayout();
            // 
            // PasswordBox
            // 
            PasswordBox.Location = new Point(12, 71);
            PasswordBox.Name = "PasswordBox";
            PasswordBox.Size = new Size(224, 23);
            PasswordBox.TabIndex = 7;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(12, 53);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(60, 15);
            PasswordLabel.TabIndex = 6;
            PasswordLabel.Text = "Password:";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(12, 9);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(63, 15);
            NameLabel.TabIndex = 5;
            NameLabel.Text = "Username:";
            // 
            // UsernameBox
            // 
            UsernameBox.Location = new Point(12, 27);
            UsernameBox.Name = "UsernameBox";
            UsernameBox.Size = new Size(224, 23);
            UsernameBox.TabIndex = 4;
            // 
            // UserSuccess
            // 
            UserSuccess.AutoSize = true;
            UserSuccess.Location = new Point(12, 97);
            UserSuccess.Name = "UserSuccess";
            UserSuccess.Size = new Size(0, 15);
            UserSuccess.TabIndex = 8;
            // 
            // SignInButton
            // 
            SignInButton.Location = new Point(12, 115);
            SignInButton.Name = "SignInButton";
            SignInButton.Size = new Size(224, 23);
            SignInButton.TabIndex = 9;
            SignInButton.Text = "Sign In";
            SignInButton.UseVisualStyleBackColor = true;
            SignInButton.Click += SignInButton_Click;
            // 
            // UserSignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 146);
            Controls.Add(SignInButton);
            Controls.Add(UserSuccess);
            Controls.Add(PasswordBox);
            Controls.Add(PasswordLabel);
            Controls.Add(NameLabel);
            Controls.Add(UsernameBox);
            Name = "UserSignIn";
            Text = "UserSignIn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PasswordBox;
        private Label PasswordLabel;
        private Label NameLabel;
        private TextBox UsernameBox;
        private Label UserSuccess;
        private Button SignInButton;
    }
}