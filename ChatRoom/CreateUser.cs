using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom
{
    public partial class CreateUser : Form
    {
        public bool Create = false;
        public string Name = string.Empty;

        public CreateUser()
        {
            InitializeComponent();
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            var result = await ChatRoomAPIHandler.GetUser(UsernameBox.Text);
            if (result.Username == string.Empty && PasswordBox.Text == ConfirmPasswordBox.Text)
            {
                await ChatRoomAPIHandler.PostNewUser(UsernameBox.Text, PasswordBox.Text);

                Name = UsernameBox.Text;
                Create = true;
            }
        }

        private async void UsernameBox_TextChanged(object sender, EventArgs e)
        {
            var result = await ChatRoomAPIHandler.GetUser(UsernameBox.Text);
            if (!(result.Username == string.Empty))
                UserSuccess.Text = "User already exists";
        }

        private void ConfirmPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (!(PasswordBox.Text == ConfirmPasswordBox.Text))
                UserSuccess.Text = "Passwords must match.";
            else
                UserSuccess.Text = string.Empty;
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (!(PasswordBox.Text == ConfirmPasswordBox.Text))
                UserSuccess.Text = "Passwords must match.";
            else
                UserSuccess.Text = string.Empty;
        }

        public void Reset()
        {
            Create = false;
            Name = string.Empty;
            UsernameBox.Text = string.Empty;
            PasswordBox.Text = string.Empty;
            ConfirmPasswordBox.Text = string.Empty;
            UserSuccess.Text = string.Empty;
        }
    }
}
