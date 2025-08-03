using ModelObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom
{
    public partial class TabSelection : Form
    {
        public Chatroom.RoomTypes SelectedRoomType = Chatroom.RoomTypes.Server;
        public bool Continue = false;
        public string OtherUser = string.Empty;

        public TabSelection()
        {
            InitializeComponent();
        }

        private void TabSelection_Load(object sender, EventArgs e)
        {
            SelectionOptions.Items.Clear();
            SelectionOptions.Items.Add("Server");
            SelectionOptions.Items.Add("Direct Messages");
            SelectionOptions.SelectedIndex = 0;
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            if (SelectionOptions.SelectedIndex == 1 && DirectMessageSuccess.Text == "User exists.")
            {
                OtherUser = UsernameSearch.Text;
            }

            Continue = true;
        }

        private void SelectionOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectionOptions.SelectedIndex == 1)
            {
                Size = new Size() { Width = 264, Height = 141 };
                SelectedRoomType = Chatroom.RoomTypes.DirectMessages;
                WithWho.Show();
                UsernameSearch.Show();
            }
            else
            {
                Size = new Size() { Width = 264, Height = 84 };
                SelectedRoomType = Chatroom.RoomTypes.Server;
                WithWho.Hide();
                UsernameSearch.Hide();
            }
        }

        public void Reset()
        {
            Continue = false;
        }

        private async void UsernameSearch_TextChanged(object sender, EventArgs e)
        {
            if (UsernameSearch.Text == string.Empty)
                return;

            var result = await ChatRoomAPIHandler.GetUser(UsernameSearch.Text);
            if (result.Username == "")
                DirectMessageSuccess.Text = "User not found.";
            else
                DirectMessageSuccess.Text = "User exists.";
        }
    }
}
