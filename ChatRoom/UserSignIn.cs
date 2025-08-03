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
    public partial class UserSignIn : Form
    {
        public bool Success = false;
        public string Name = string.Empty;

        public UserSignIn()
        {
            InitializeComponent();
        }

        private async void SignInButton_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text == string.Empty)
                return;

            var result = await ChatRoomAPIHandler.GetUser(UsernameBox.Text);
            if (result.Username == string.Empty)
                UserSuccess.Text = "User does not exist";
            else if (result.Password != PasswordBox.Text)
                UserSuccess.Text = "Password doesn't match user";
            else if (result.Password == PasswordBox.Text)
            {
                Name = result.Username;
                Success = true;
            }
        }

        public void Reset()
        {
            Success = false;
            Name = string.Empty;
            UsernameBox.Text = string.Empty;
            PasswordBox.Text = string.Empty;
            UserSuccess.Text = string.Empty;
        }
    }
}
